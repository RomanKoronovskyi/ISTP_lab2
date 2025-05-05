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
    public class UsersController : ControllerBase
    {
        private readonly RentAPIContext _context;

        public UsersController(RentAPIContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);

            if (users == null)
            {
                return NotFound();
            }

            return users;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsers(int id, Users users)
        {
            if (id != users.Id)
            {
                return BadRequest();
            }

            _context.Entry(users).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Users>> PostUsers(Users users)
        {
            _context.Users.Add(users);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsers", new { id = users.Id }, users);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsers(int id)
        {
            var users = await _context.Users.FindAsync(id);
            if (users == null)
            {
                return NotFound();
            }

            _context.Users.Remove(users);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsersExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
        // PATCH: api/Users/5
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchUsers(int id, [FromBody] JsonElement updates)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();

            var json = updates.GetRawText();
            var patchDoc = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(json);

            foreach (var entry in patchDoc)
            {
                var property = typeof(Users).GetProperty(entry.Key);
                if (property != null)
                {
                    var value = Convert.ChangeType(entry.Value.ToString(), property.PropertyType);
                    property.SetValue(user, value);
                }
            }

            await _context.SaveChangesAsync();
            return NoContent();
        }

        // HEAD: api/Users/5
        [HttpHead("{id}")]
        public async Task<IActionResult> HeadUsers(int id)
        {
            var exists = await _context.Users.AnyAsync(u => u.Id == id);
            if (!exists)
                return NotFound();

            Response.ContentLength = 0;
            return Ok();
        }

        // OPTIONS: api/Users/5
        [HttpOptions("{id}")]
        public IActionResult OptionsUsers(int id)
        {
            Response.Headers.Add("Allow", "GET, PUT, PATCH, DELETE, HEAD, OPTIONS");
            return Ok();
        }

    }
}
