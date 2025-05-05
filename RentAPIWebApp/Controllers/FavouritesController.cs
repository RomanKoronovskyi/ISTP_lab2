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
    public class FavouritesController : ControllerBase
    {
        private readonly RentAPIContext _context;

        public FavouritesController(RentAPIContext context)
        {
            _context = context;
        }

        // GET: api/Favourites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Favourites>>> GetFavourites()
        {
            return await _context.Favourites.ToListAsync();
        }

        // GET: api/Favourites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Favourites>> GetFavourites(int id)
        {
            var favourites = await _context.Favourites.FindAsync(id);

            if (favourites == null)
            {
                return NotFound();
            }

            return favourites;
        }

        // PUT: api/Favourites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFavourites(int id, Favourites favourites)
        {
            if (id != favourites.Id)
            {
                return BadRequest();
            }

            _context.Entry(favourites).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FavouritesExists(id))
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

        // POST: api/Favourites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Favourites>> PostFavourites(Favourites favourites)
        {
            _context.Favourites.Add(favourites);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFavourites", new { id = favourites.Id }, favourites);
        }

        // DELETE: api/Favourites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFavourites(int id)
        {
            var favourites = await _context.Favourites.FindAsync(id);
            if (favourites == null)
            {
                return NotFound();
            }

            _context.Favourites.Remove(favourites);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FavouritesExists(int id)
        {
            return _context.Favourites.Any(e => e.Id == id);
        }
    }
}
