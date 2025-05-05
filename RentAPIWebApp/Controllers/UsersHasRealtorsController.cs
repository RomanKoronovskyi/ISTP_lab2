using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RentAPIWebApp.Models;

namespace RentAPIWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersHasRealtorsController : ControllerBase
    {
        private readonly RentAPIContext _context;

        public UsersHasRealtorsController(RentAPIContext context)
        {
            _context = context;
        }

        // GET: api/UsersHasRealtors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsersHasRealtors>>> GetUsersHasRealtors()
        {
            return await _context.UsersHasRealtors.ToListAsync();
        }

        // GET: api/UsersHasRealtors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsersHasRealtors>> GetUsersHasRealtors(int id)
        {
            var usersHasRealtors = await _context.UsersHasRealtors.FindAsync(id);

            if (usersHasRealtors == null)
            {
                return NotFound();
            }

            return usersHasRealtors;
        }

        // PUT: api/UsersHasRealtors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsersHasRealtors(int id, UsersHasRealtors usersHasRealtors)
        {
            if (id != usersHasRealtors.Id)
            {
                return BadRequest();
            }

            _context.Entry(usersHasRealtors).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersHasRealtorsExists(id))
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

        // POST: api/UsersHasRealtors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsersHasRealtors>> PostUsersHasRealtors(UsersHasRealtors usersHasRealtors)
        {
            _context.UsersHasRealtors.Add(usersHasRealtors);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsersHasRealtors", new { id = usersHasRealtors.Id }, usersHasRealtors);
        }

        // DELETE: api/UsersHasRealtors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsersHasRealtors(int id)
        {
            var usersHasRealtors = await _context.UsersHasRealtors.FindAsync(id);
            if (usersHasRealtors == null)
            {
                return NotFound();
            }

            _context.UsersHasRealtors.Remove(usersHasRealtors);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsersHasRealtorsExists(int id)
        {
            return _context.UsersHasRealtors.Any(e => e.Id == id);
        }
    }
}
