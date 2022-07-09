using Food_Delivery_Core.DTO;
using Food_Delivery_Core.Models;
using Food_Delivery_Core.Mapping;
using Food_Delivery_Core.Data;
using Food_Delivery_Core.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Food_Delivery_Core.Services
{
    public class UserService : IUserInterface
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public UserService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public RegisterDTO AddUser(RegisterDTO registerDTO)
        {
            User u = _mapper.Map<User>(registerDTO);

            //var b = (_context.Users?.Any(e => e.Username == registerDTO.Username)).GetValueOrDefault();
            u.Password = u.Password.GetHashCode().ToString();

            _context.Users.Add(u);
            _context.SaveChanges();


            var l = u.Id;

            return _mapper.Map<RegisterDTO>(u);

        }

        public void DeleteUser(long Id)
        {

           
            var user =_context.Users.Find(Id);

            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
           
        }

        public RegisterDTO GetById(long id)
        {
          
            var user = _context.Users.Find(id);

            if (user == null)
            {
                return null;
            }

            return _mapper.Map<RegisterDTO>(user);
        }

        public List<RegisterDTO> GetUsers()
        {
            if (_context.Users == null)
            {
                return null;
            }
            return _mapper.Map<List<RegisterDTO>>(_context.Users.ToList());
        }

        public List<string> Login(UserLoginDto userLoginDto)
        {
           

            var users = _context.Users;
            User? u = null;
            u = users.Where(o => o.Username == userLoginDto.Username && o.Password == userLoginDto.Password.GetHashCode().ToString()).First();

            if (u == null)
            {
                return null;
            }

            return new List<string>{ u.Id.ToString(), u.UserType};
        }

        public RegisterDTO UpdateUser(long id, RegisterDTO register)
        {
           

            var user = _mapper.Map<User>(register);

                _context.Entry(user).State = EntityState.Modified;

                try
                    {
                        _context.SaveChanges();
                    }
                    catch (DbUpdateConcurrencyException)
                   {
                      if (_context.Users.Where(x => x.Id == id) == null)
                      {
                           return null;
                        }
                      else
                     {
                           throw;
                       }
                    }

            return _mapper.Map<RegisterDTO>(user); 
        }
    }
}
