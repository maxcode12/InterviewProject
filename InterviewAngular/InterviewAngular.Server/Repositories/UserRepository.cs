using InterviewAngular.Server.Context;
using InterviewAngular.Server.Interfaces;
using InterviewAngular.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewAngular.Server.Repositories;

public class UserRepository : IUserRepository
{
    private readonly EBusinessDBContext _context;
    public UserRepository(EBusinessDBContext context)
    {
        _context = context;
    }
    public async Task<User> CreateAsync(User user)
    {
        
        var userEmailExists = await _context.Users.AnyAsync(u => u.Email == user.Email);
        if (userEmailExists)
        {
            throw new Exception("Email already exists");
        }
        else
        {
            var createdUser = new User
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            _context.Users.Add(createdUser);
            await _context.SaveChangesAsync();
           
        }
        return user;
    }

    public Task<User> DeleteAsync(User user)
    {
        var userToDelete = _context.Users.Find(user.Id);
        if (userToDelete != null)
        {
            _context.Users.Remove(userToDelete);
            _context.SaveChanges();
        }
        return Task.FromResult(user);
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        var users = await _context.Users.ToListAsync();
        return users;
    }

    public Task<User> GetByAsync(string id)
    {
        var user = _context.Users.Find(id);
        return Task.FromResult(user);
    }

    public Task<User> UpdateAsync(User user)
    {
        // Find the user to update
        var userToUpdate = _context.Users.Find(user.Id);

        // If the user exists, update the properties
        if (userToUpdate != null)
        {
            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Email = user.Email;
            _context.SaveChanges();
        }
        return Task.FromResult(user);
    }
}
