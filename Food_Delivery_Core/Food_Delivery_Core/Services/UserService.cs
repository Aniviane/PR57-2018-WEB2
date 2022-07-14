using Food_Delivery_Core.DTO;
using Food_Delivery_Core.Models;
using Food_Delivery_Core.Mapping;
using Food_Delivery_Core.Data;
using Food_Delivery_Core.Services.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using MailKit;
using MimeKit;
using Org.BouncyCastle.Crypto.Generators;

namespace Food_Delivery_Core.Services
{
    public class UserService : IUserInterface
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private string key = "_Food_Delivery";
        public UserService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public RegisterDTO AddUser(RegisterDTO registerDTO)
        {
            User u = _mapper.Map<User>(registerDTO);

            //var b = (_context.Users?.Any(e => e.Username == registerDTO.Username)).GetValueOrDefault();
            u.Password = BCrypt.Net.BCrypt.HashPassword(u.Password);
            
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
            u = users.Where(o => o.Email == userLoginDto.Username).First();

            if (u == null)
            {
                return null;
            }

            


            if (!BCrypt.Net.BCrypt.Verify(userLoginDto.Password, u.Password))
            {
                return new List<string> { "WRONG PASSWORD" };
            }

            List < Claim > claims = new List<Claim>();

            claims.Add(new Claim(ClaimTypes.Role, u.UserType));
            claims.Add(new Claim(ClaimTypes.SerialNumber, u.Id.ToString()));
            SymmetricSecurityKey secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("babababababababababababababababababababababababababababababababab"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokenOptions = new JwtSecurityToken(
                issuer: "https://localhost:7036/",
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: signinCredentials
                ); ;
            string token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

           

            return new List<string>{ u.Id.ToString(), u.UserType, token,u.Username, u.IsVerified.ToString()};
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






        public void VerifyUser(long id)
        {
            var users = _context.Users;
                if (users.Where(o => o.Id == id) != null) {
                var user = users.Find(id);
                user.IsVerified = true;
                _context.SaveChanges();
            }


        }




        private void SendEmail(string mail)
        {
           var email = new MimeMessage();
            

        }
    } 

}
