using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Food_Delivery_Core.Data;
using Food_Delivery_Core.Models;
using Food_Delivery_Core.DTO;

namespace Food_Delivery_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly DataContext _context;

        public RestaurantsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Restaurants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Restaurant>>> GetRestoraunts()
        {
          if (_context.Restoraunts == null)
          {
              return NotFound();
          }
            return await _context.Restoraunts.ToListAsync();
        }

        // GET: api/Restaurants/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> GetRestaurant(long id)
        {
          if (_context.Restoraunts == null)
          {
              return NotFound();
          }
            var restaurant = await _context.Restoraunts.FindAsync(id);

            if (restaurant == null)
            {
                return NotFound();
            }

            return restaurant;
        }

        // PUT: api/Restaurants/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRestaurant(long id, Restaurant restaurant)
        {
            if (id != restaurant.Id)
            {
                return BadRequest();
            }

            _context.Entry(restaurant).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RestaurantExists(id))
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

        // POST: api/Restaurants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Restaurant>> PostRestaurant(RestaurantDTO restaurant)
        {
          if (_context.Restoraunts == null)
          {
              return Problem("Entity set 'DataContext.Restoraunts'  is null.");
          }
            Restaurant newRestaurant = new Restaurant(restaurant);
            _context.Restoraunts.Add(newRestaurant);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRestaurant", new { id = newRestaurant.Id }, newRestaurant);
        }

        // DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(long id)
        {
            if (_context.Restoraunts == null)
            {
                return NotFound();
            }
            var restaurant = await _context.Restoraunts.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            _context.Restoraunts.Remove(restaurant);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RestaurantExists(long id)
        {
            return (_context.Restoraunts?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
