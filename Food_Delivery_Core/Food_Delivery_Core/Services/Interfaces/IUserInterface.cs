using Food_Delivery_Core.DTO;
namespace Food_Delivery_Core.Services.Interfaces
{
    public interface IUserInterface
    {
        List<string> Login(UserLoginDto userLoginDto);
        List<RegisterDTO> GetUsers();
        RegisterDTO GetById(long id);

        RegisterDTO AddUser(RegisterDTO registerDTO);

        RegisterDTO UpdateUser(long id, RegisterDTO register);

        void VerifyUser(long id);

        void DeleteUser(long Id);
    }
}
