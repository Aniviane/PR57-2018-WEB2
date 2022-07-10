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
using Food_Delivery_Core.Services;
using Food_Delivery_Core.Services.Interfaces;

namespace Food_Delivery_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        
        private readonly IRestaurantInterface _restaurantService;

        public RestaurantsController( IRestaurantInterface restaurantInterface)
        {
          
            _restaurantService = restaurantInterface;
        }

        // GET: api/Restaurants
        [HttpGet]
        public ActionResult<IEnumerable<RestaurantDTO>> GetRestoraunts()
        {

            return Ok(_restaurantService.GetRestaurants());
        }

        // GET: api/Restaurants/5
        [HttpGet("{id}")]
        public ActionResult<RestaurantDTO> GetRestaurant(long id)
        {

            return Ok(_restaurantService.GetById(id));
        }

        //// PUT: api/Restaurants/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutRestaurant(long id, Restaurant restaurant)
        //{
        //    if (id != restaurant.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(restaurant).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!RestaurantExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Restaurants
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<RestaurantDTO> PostRestaurant(RestaurantDTO restaurant)
        {
            return Ok(_restaurantService.AddRestaurant(restaurant));
        }

        // DELETE: api/Restaurants/5
        [HttpDelete("{id}")]
        public IActionResult DeleteRestaurant(long id)
        {
            _restaurantService.DeleteRestaurant(id);
            return NoContent();
        }
    }
       
}
