using Food_Delivery_Core.DTO;

namespace Food_Delivery_Core.Models
{
    public class User
    {
    

        public long Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
        public string FullName { get; set; }
        public string Adress { get; set; }
        public DateTime DoB { get; set; }
        public string UserType { get; set; }

        public bool IsVerified  { get; set; }

        public User()
        {

        }
        public User (RegisterDTO data)
        {
            Id = 0;
            Username = data.Username;
            Password = data.Password.GetHashCode().ToString();
            Adress = data.Adress;
            UserType = data.UserType;
            DoB = data.DoB;
            FullName = data.FullName;
            Email = data.Email;
            IsVerified = false;
        }

    }
}
