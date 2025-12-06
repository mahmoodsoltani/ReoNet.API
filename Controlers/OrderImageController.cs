using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReoNet.Api.Data;
using ReoNet.Api.Models;
using Microsoft.AspNetCore.Authorization;

[Route("api/[controller]")]
[ApiController]

public class ReonetOrderImageController : ControllerBase
{
    private readonly AppDbContext _context;

    public ReonetOrderImageController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/ReonetOrderImage
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReonetOrderImage>>> GetImages()
    {
        return await _context.Reonet_OrderImages.ToListAsync();
    }

    // GET: api/ReonetOrderImage/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ReonetOrderImage>> GetImage(int id)
    {
        var item = await _context.Reonet_OrderImages.FindAsync(id);

        if (item == null)
            return NotFound();

        return item;
    }

    // GET: api/ReonetOrderImage/byOrderDetail/123
    [HttpGet("byOrderDetail/{orderDetailId}")]
    public async Task<ActionResult<IEnumerable<ReonetOrderImage>>> GetImagesByOrderDetail(int orderDetailId)
    {
        var images = await _context.Reonet_OrderImages
            .Where(x => x.Srl_OrderDetail == orderDetailId)
            .ToListAsync();

        return images;
    }

    // POST: api/ReonetOrderImage/add
    [HttpPost("add")]
    public async Task<ActionResult<ReonetOrderImage>> AddImage(ReonetOrderImage model)
    {
        _context.Reonet_OrderImages.Add(model);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetImagesByOrderDetail), 
            new { orderDetailId = model.Srl_OrderDetail }, model);
    }

    // PUT: api/ReonetOrderImage/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutImage(int id, ReonetOrderImage model)
    {
        if (id != model.Srl)
            return BadRequest();

        _context.Entry(model).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Reonet_OrderImages.Any(e => e.Srl == id))
                return NotFound();
            else
                throw;
        }

        return NoContent();
    }

    // DELETE: api/ReonetOrderImage/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteImage(int id)
    {
        var item = await _context.Reonet_OrderImages.FindAsync(id);

        if (item == null)
            return NotFound();

        _context.Reonet_OrderImages.Remove(item);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/ReonetOrderImage/byOrderDetail/123
    [HttpDelete("byOrderDetail/{orderDetailId}")]
    public async Task<IActionResult> DeleteImagesByOrderDetail(int orderDetailId)
    {
        var images = await _context.Reonet_OrderImages
            .Where(x => x.Srl_OrderDetail == orderDetailId)
            .ToListAsync();

        if (!images.Any())
            return NotFound();

        _context.Reonet_OrderImages.RemoveRange(images);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
