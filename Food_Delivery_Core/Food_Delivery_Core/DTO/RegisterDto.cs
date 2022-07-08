namespace Food_Delivery_Core.DTO
{
    public class RegisterDto
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
        public string FullName { get; set; }
        public string Adress { get; set; }
        public DateTime DoB { get; set; }
        public string UserType { get; set; }



    }
}
