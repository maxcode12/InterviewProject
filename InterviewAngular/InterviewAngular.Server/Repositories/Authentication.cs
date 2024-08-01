using InterviewAngular.Server.Context;
using InterviewAngular.Server.DTOs.Accounts;
using InterviewAngular.Server.Interfaces;
using InterviewAngular.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace InterviewAngular.Server.Repositories;

public class Authentication : IAuthentication
{
    private readonly EBusinessDBContext _context;
    public Authentication(EBusinessDBContext context)
    {
        _context = context;
    }
    public async Task<User> RegisterAsync(UserRegistrationDTO user)
    {
        var userEmailExists = await _context.Users.
            AnyAsync(u => u.Email == user.Email);
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
        //return user;
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == user.Email);
    }

    public async Task<User> LoginAsync(UserLoginDTO login)
    {

        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Email == login.Email 
              && u.Password == login.Password);
        return user;
    }

    public async Task<UserDTO> GetUserAsync(string email)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        return new UserDTO
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email
        };
    }

}
