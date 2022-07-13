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
using Microsoft.AspNetCore.Authorization;

namespace Food_Delivery_Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
       
        private readonly IOrderInterface _orderService;

        public OrdersController( IOrderInterface orderInterface)
        {
            
            _orderService = orderInterface;
        }

        // GET: api/Orders
        [HttpGet]
        public ActionResult<IEnumerable<OrderDTO>> GetOrders()
        {
            return Ok(_orderService.GetOrders());
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public ActionResult<OrderDTO> GetOrder(long id)
        {

            return Ok(_orderService.GetById(id));
        }

        //// PUT: api/Orders/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutOrder(long id, Order order)
        //{
        //    if (id != order.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(order).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrderExists(id))
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

        // POST: api/Orders
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<OrderDTO> PostOrder(OrderDTO order)
        {
            return Ok(_orderService.AddOrder(order));

           
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(long id)
        {
            _orderService.DeleteOrder(id);
            return Ok();
        }


        [HttpPut, Authorize]
        public IActionResult UpdateOrder(UpdateOrderDTO dto)
        {
            _orderService.UpdateOrder(dto);
            return Ok();
        }
       
    }
}
