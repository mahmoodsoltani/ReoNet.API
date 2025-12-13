using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReoNet.Api.Models;
using ReoNet.Api.Data;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Authorize]

[Route("api/[controller]")]
public class OrderStatusController : ControllerBase
{
    private readonly AppDbContext _context;

    public OrderStatusController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("by-service-category/{srlServiceCategory}")]
    public async Task<IActionResult> GetByServiceCategory(int srlServiceCategory)
    {
        try
        {
            var statuses = await _context.ReonetOrderStatuses
                .Where(x => x.SrlServicecategory == srlServiceCategory)
                .Select(x => new
                {
                    x.Srl,
                    x.Title,
                    x.Code
                })
                .ToListAsync();

            return Ok(statuses);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}
