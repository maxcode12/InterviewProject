using InterviewAngular.Server.DTOs.Accounts;
using InterviewAngular.Server.Models;

namespace InterviewAngular.Server.Interfaces
{
    public interface IAuthentication
    {
        Task<User> RegisterAsync(UserRegistrationDTO user);
        Task<User> LoginAsync(UserLoginDTO login);
        Task<UserDTO> GetUserAsync(string email);
    }
}
