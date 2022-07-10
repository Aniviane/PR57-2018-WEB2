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
    public class UsersController : ControllerBase
    {
        
        private readonly IUserInterface _userService;

        public UsersController( IUserInterface userInterface)
        {
           
            _userService = userInterface;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegisterDTO>>> GetUsers()
        {
            //if (_context.Users == null)
            //{
            //    return NotFound();
            //}
            //  return await _context.Users.ToListAsync();
            return Ok(_userService.GetUsers());
        }


        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RegisterDTO>> GetUser(long id)
        {
            //if (_context.Users == null)
            //{
            //    return NotFound();
            //}
            //  var user = await _context.Users.FindAsync(id);

            //  if (user == null)
            //  {
            //      return NotFound();
            //  }

            //  return user;
            var ret = _userService.GetById(id);
            if (ret == null) return NotFound();
            else return ret;

        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutUser(long id, User user)
        //{
        //    if (id != user.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RegisterDTO>> RegisterUser(RegisterDTO user)
        {
            //if (_context.Users == null)
            //{
            //    return Problem("Entity set 'DataContext.Users'  is null.");
            //}
            //  var b = (_context.Users?.Any(e => e.Username == user.Username)).GetValueOrDefault();
            //  if(b)
            //  {
            //      return Problem("Another User with that Username exists");
            //  }
            //  User newUser = new User(user);

            //  _context.Users.Add(newUser);
            //  await _context.SaveChangesAsync();

            //  return CreatedAtAction("GetUser", new { id = newUser.Id }, user);

            return Ok(_userService.AddUser(user));
        }


        [HttpPost("/Login")]
        public async Task<ActionResult<string>> Login(UserLoginDto user)
        {
            //if (_context.Users == null)
            //{
            //    return NotFound();
            //}

            //var users = _context.Users;
            //User? u = null;
            //u = users.Where(o => o.Username == user.Username && o.Password.GetHashCode().ToString() == user.Password).First();

            //if (u == null)
            //{
            //    return NotFound();
            //}

            //return Ok(u.UserType);
            if (_userService.Login(user) == null) return NotFound();
            return Ok(_userService.Login(user));
        }

       






        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(long id) { 
        //{
        //    if (_context.Users == null)
        //    {
        //        return NotFound();
        //    }
        //    var user = await _context.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Users.Remove(user);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
       
            _userService.DeleteUser(id);
            return NoContent();
        }

       
    }
}
