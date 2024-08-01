using InterviewAngular.Server.DTOs.Accounts;
using InterviewAngular.Server.Interfaces;
using InterviewAngular.Server.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InterviewAngular.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationControllers : ControllerBase
{
    private readonly IAuthentication _auth;

    public AuthenticationControllers(IAuthentication auth)
    {
        _auth = auth;
    }

    [HttpGet("GetUserByEmail")]
    public async Task<ActionResult<IEnumerable<User>>> Get(string email)
    {
        var users = await _auth.GetUserAsync(email);
        return Ok(users);
    }

    [HttpPost("Register")]
    public async Task<ActionResult<User>> Register(UserRegistrationDTO user)
    {
        var createdUser = await _auth.RegisterAsync(user);
        return Ok(createdUser);
    }

    [HttpPost("Login")] 
    public async Task<ActionResult<User>> Login(UserLoginDTO login)
    {
        var user = await _auth.LoginAsync(login);
        return Ok(user);
    }
   
}
