using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentAPIWebApp.Models;

namespace RentAPIWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RealtorsController : ControllerBase
    {
        private readonly RentAPIContext _context;

        public RealtorsController(RentAPIContext context)
        {
            _context = context;
        }

        // GET: api/Realtors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Realtors>>> GetRealtors()
        {
            return await _context.Realtors.ToListAsync();
        }

        // GET: api/Realtors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Realtors>> GetRealtors(int id)
        {
            var realtors = await _context.Realtors.FindAsync(id);

            if (realtors == null)
            {
                return NotFound();
            }

            return realtors;
        }

        // PUT: api/Realtors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRealtors(int id, Realtors realtors)
        {
            if (id != realtors.Id)
            {
                return BadRequest();
            }

            _context.Entry(realtors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RealtorsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Realtors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Realtors>> PostRealtors(Realtors realtors)
        {
            _context.Realtors.Add(realtors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRealtors", new { id = realtors.Id }, realtors);
        }

        // DELETE: api/Realtors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRealtors(int id)
        {
            var realtors = await _context.Realtors.FindAsync(id);
            if (realtors == null)
            {
                return NotFound();
            }

            _context.Realtors.Remove(realtors);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RealtorsExists(int id)
        {
            return _context.Realtors.Any(e => e.Id == id);
        }
        // PATCH: api/Realtors/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchRealtors(int id, [FromBody] JsonElement updates)
        {
            var realtor = await _context.Realtors.FindAsync(id);
            if (realtor == null)
            {
                return NotFound();
            }

            var json = updates.GetRawText();
            var patchDoc = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);

            foreach (var entry in patchDoc)
            {
                var property = typeof(Realtors).GetProperty(entry.Key);
                if (property != null)
                {
                    var value = Convert.ChangeType(entry.Value.ToString(), property.PropertyType);
                    property.SetValue(realtor, value);
                }
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // HEAD: api/Realtors/5
        [HttpHead("{id}")]
        public async Task<IActionResult> HeadRealtors(int id)
        {
            var exists = await _context.Realtors.AnyAsync(r => r.Id == id);

            if (!exists)
            {
                return NotFound();
            }

            Response.ContentLength = 0; // Явно вказуємо, що немає тіла
            return Ok(); // 200 OK без контенту
        }

        // OPTIONS: api/Realtors/5
        [HttpOptions("{id}")]
        public IActionResult OptionsRealtors(int id)
        {
            Response.Headers.Add("Allow", "GET, PUT, PATCH, DELETE, HEAD, OPTIONS");
            return Ok();
        }
    }
}
