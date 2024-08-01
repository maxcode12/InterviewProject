using InterviewAngular.Server.Models;

namespace InterviewAngular.Server.Interfaces;

public interface IUserRepository
{
    Task<User> CreateAsync(User user);
    Task<User> UpdateAsync(User user);
    Task<User> DeleteAsync(User user);
    Task<User> GetByAsync(string id);
    Task<IEnumerable<User>> GetAllAsync();

}
