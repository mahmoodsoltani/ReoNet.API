using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReoNet.Api.Models;
using ReoNet.Api.Data;
using Microsoft.AspNetCore.Authorization;

[ApiController]
// [Authorize]

[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrdersController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomerOrders([FromQuery] OrderQueryRequest request)
    {
        var query = _context
            .ReonetOrderMasters.Include(m => m.OrderDetails) // شامل جزئیات سفارش
            .Where(m => m.SrlCustomer == request.CustomerId)
            .AsQueryable();

        // فیلتر تاریخ
        if (!string.IsNullOrEmpty(request.StartDate))
        {
            query = query.Where(m => string.Compare(m.OrderDate, request.StartDate) >= 0);
        }
        if (!string.IsNullOrEmpty(request.EndDate))
        {
            query = query.Where(m => string.Compare(m.OrderDate, request.EndDate) <= 0);
        }

        // مرتب‌سازی
        query = request.SortBy?.ToLower() switch
        {
            "totalprice"
                => request.SortDesc
                    ? query.OrderByDescending(m => m.TotalPrice)
                    : query.OrderBy(m => m.TotalPrice),
            "deliverydate"
                => request.SortDesc
                    ? query.OrderByDescending(m => m.DeliveryDate)
                    : query.OrderBy(m => m.DeliveryDate),
            "ordernumber"
                => request.SortDesc
                    ? query.OrderByDescending(m => m.OrderNumber)
                    : query.OrderBy(m => m.OrderNumber),
            _
                => request.SortDesc
                    ? query.OrderByDescending(m => m.OrderDate)
                    : query.OrderBy(m => m.OrderDate),
        };

        var orders = await query.ToListAsync();

        return Ok(orders);
    }

    [HttpGet("orderdetail")]
    public async Task<IActionResult> GetCustomerOrderDeatilss([FromQuery] OrderQueryRequest request)
    {
        var query = _context
            .ReonetOrderMasters.Include(o => o.OrderDetails)
            .ThenInclude(d => d.Service)
            .Include(o => o.OrderDetails)
            .ThenInclude(d => d.Status)
             .Include(o => o.OrderDetails)
        .ThenInclude(d => d.Images)
            .Where(m => m.SrlCustomer == request.CustomerId)
            .AsQueryable();

        if (!string.IsNullOrEmpty(request.StartDate))
            query = query.Where(m => string.Compare(m.OrderDate, request.StartDate) >= 0);

        if (!string.IsNullOrEmpty(request.EndDate))
            query = query.Where(m => string.Compare(m.OrderDate, request.EndDate) <= 0);

        query = query.Where(order =>
            order.OrderDetails.Any(detail => detail.SrlOrderstatus == request.status)
        );

        query = request.SortBy?.ToLower() switch
        {
            "totalprice"
                => request.SortDesc
                    ? query.OrderByDescending(m => m.TotalPrice)
                    : query.OrderBy(m => m.TotalPrice),
            "deliverydate"
                => request.SortDesc
                    ? query.OrderByDescending(m => m.DeliveryDate)
                    : query.OrderBy(m => m.DeliveryDate),
            "ordernumber"
                => request.SortDesc
                    ? query.OrderByDescending(m => m.OrderNumber)
                    : query.OrderBy(m => m.OrderNumber),
            _
                => request.SortDesc
                    ? query.OrderByDescending(m => m.OrderDate)
                    : query.OrderBy(m => m.OrderDate),
        };

        var orders = await query.ToListAsync();

        var flatList = orders
            .SelectMany(order =>
                order.OrderDetails.Select(detail => new
                {
                    order.Srl,
                    order.OrderNumber,
                    order.OrderDate,

                    detail.Barcode,
                    detail.Width,
                    detail.Length,
                    detail.Area,
                    detail.Totalprice,
                    detail.Discount,
                    detail.Deliverydate,
                    detail.Status?.Title,
                    detail.Service?.Name,
                    detail.Price,
                    detail.Description,
                     Images = detail.Images?.Select(img => new
                    {
                        img.Srl,
                        img.File_Path,
                        img.Stage,
                        img.Media_Type,
                        img.Created_At,
                        img.Public_id

                    }).ToList()

                })
            )
            .ToList();

        return Ok(flatList);
    }

   [HttpGet("get-srl")]
public async Task<IActionResult> GetSrlByBarcode([FromQuery] string barcode)
{
    if (string.IsNullOrWhiteSpace(barcode))
        return BadRequest(new { success = false, message = "Barcode is required" });

    var detail = await _context.ReonetOrderDetails
        .Where(d => d.Barcode == barcode)
        .FirstOrDefaultAsync();

    if (detail == null)
        return Ok(new { success = false, srl = -1 });

    return Ok(new { success = true, srl = detail.Srl });
}
    [HttpGet("get-detail-by-barcode")]
    public async Task<IActionResult> GetOrderDetailByBarcode([FromQuery] string barcode)
    {
        if (string.IsNullOrWhiteSpace(barcode))
            return BadRequest(new { success = false, message = "Barcode is required" });

        // جستجوی OrderDetail با Service, Status و Images
        var detail = await _context.ReonetOrderDetails
            .Include(d => d.Service)
            .Include(d => d.Status)
            .Include(d => d.Images)
            .Include(d => d.ReonetMaster) // در صورت نیاز اطلاعات Master
            .Where(d => d.Barcode == barcode)
            .FirstOrDefaultAsync();

        if (detail == null)
            return NotFound(new { success = false, message = "Order detail not found" });

        // ایجاد خروجی JSON مشابه flatList قبلی
        var result = new
        {
            detail.Srl,
            detail.Barcode,
            detail.Width,
            detail.Length,
            detail.Area,
            detail.Totalprice,
            detail.Discount,
            detail.Deliverydate,
            Status = detail.Status?.Title,
            Service = detail.Service?.Name,
            detail.Price,
            detail.Description,
            detail.SrlOrderstatus,
            Master = detail.ReonetMaster != null ? new
            {
                detail.ReonetMaster.Srl,
                detail.ReonetMaster.OrderNumber,
                detail.ReonetMaster.OrderDate,
                detail.ReonetMaster.TotalPrice,
                detail.ReonetMaster.DeliveryDate
            } : null,
            Images = detail.Images?.Select(img => new
            {
                img.File_Path,
                img.Stage,
                img.Media_Type,
                img.Created_At,
                img.Public_id
            }).ToList()
        };

        return Ok(result);
    }
     [HttpPost("update-status")]
    public async Task<IActionResult> UpdateStatus([FromBody] UpdateOrderStatusDto dto)
    {
        if (dto == null || dto.Srl <= 0 || dto.StatusId <= 0)
            return BadRequest(new { message = "Invalid data" });

        // پیدا کردن فرش (OrderDetail)
        var order = await _context.ReonetOrderDetails
            .FirstOrDefaultAsync(x => x.Srl == dto.Srl);

        if (order == null)
            return NotFound(new { message = "Order not found" });

        // بررسی معتبر بودن وضعیت
        var status = await _context.ReonetOrderStatuses
            .FirstOrDefaultAsync(x => x.Srl == dto.StatusId);

        if (status == null)
            return BadRequest(new { message = "Invalid status" });

        // آپدیت وضعیت
        order.SrlOrderstatus = dto.StatusId;

        await _context.SaveChangesAsync();

        return Ok(new
        {
            success = true,
            statusId = dto.StatusId,
            statusTitle = status.Title
        });
    }
    public class UpdateOrderStatusDto
{
    public int Srl { get; set; }        // Srl_OrderDetail
    public int StatusId { get; set; }   // Srl وضعیت
}

}
