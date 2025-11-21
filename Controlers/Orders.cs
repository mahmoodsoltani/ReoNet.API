using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReoNet.Api.Models;
using ReoNet.Api.Data;

[ApiController]
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
}
