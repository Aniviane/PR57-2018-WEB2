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
    public class DishesController : ControllerBase
    {
        private readonly DataContext _context;

        public DishesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Dishes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dish>>> GetDishes()
        {
          if (_context.Dishes == null)
          {
              return NotFound();
          }
            return await _context.Dishes.ToListAsync();
        }

        // GET: api/Dishes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dish>> GetDish(long id)
        {
          if (_context.Dishes == null)
          {
              return NotFound();
          }
            var dish = await _context.Dishes.FindAsync(id);

            if (dish == null)
            {
                return NotFound();
            }

            return dish;
        }

        // PUT: api/Dishes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDish(long id, Dish dish)
        {
            if (id != dish.Id)
            {
                return BadRequest();
            }

            _context.Entry(dish).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DishExists(id))
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

        // POST: api/Dishes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Dish>> PostDish(DishDTO dish)
        {
          if (_context.Dishes == null)
          {
              return Problem("Entity set 'DataContext.Dishes'  is null.");
          }
            Dish newDish = new Dish(dish);
            _context.Dishes.Add(newDish);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDish", new { id = newDish.Id }, newDish);
        }

        // DELETE: api/Dishes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDish(long id)
        {
            if (_context.Dishes == null)
            {
                return NotFound();
            }
            var dish = await _context.Dishes.FindAsync(id);
            if (dish == null)
            {
                return NotFound();
            }

            _context.Dishes.Remove(dish);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DishExists(long id)
        {
            return (_context.Dishes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
