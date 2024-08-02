using EBusiness.API.Context;
using EBusiness.API.Dtos;
using EBusiness.API.Interfaces;
using EBusiness.API.Server.Models;
using EBusiness.API.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace EBusiness.API.Repositories;

public class AuthenticateUser : IAuthenticateUser
{
    private readonly EBuisinessContextDB2024 _context;
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;


    private readonly IOptions<JwtSettings> _jwtSettings;

    public AuthenticateUser(EBuisinessContextDB2024 context,
        UserManager<User> userManager,
        SignInManager<User> signInManager,
        IOptions<JwtSettings> jwtSettings)
    {
        _context = context;
        _userManager = userManager;
        _signInManager = signInManager;
        _jwtSettings = jwtSettings;
    }


    public async Task<User> FindUserByEmail(FindUserByEmailDto findUserByEmailDto)
    {

        var result = await _context.Users
             .Where(x => x.Email == findUserByEmailDto.Email).FirstOrDefaultAsync();
        return result;
    }

    public async Task<LoginResponse> LoginUser([NotNull]UserLoginDto userLoginDto)
    {
        var response = new LoginResponse();
       var useremail = await _userManager.FindByEmailAsync(userLoginDto.Email);
        if (useremail == null)
        {
            response.Success = false;
            response.Message = "User Not Found";
            return response;
        }
      

        var result = await _signInManager.CheckPasswordSignInAsync(useremail, userLoginDto.Password, false);
        if (!result.Succeeded)
        {
            response.Success = false;
            response.Message = "Invalid Password";
            return response;
        }

       var jwtSecurityToken = await GenerateJwtToken(useremail);
       var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
       
        response.Id = useremail.Id;
        response.Email = useremail.Email;
        response.AccessToken = token;
        response.RefreshToken = token;
        response.Success = true;
        response.Message = "Login Successful";


        return response;

    }

    private async Task<JwtSecurityToken> GenerateJwtToken(User user)
    {
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);
        var roleClaims = new List<Claim>();
        foreach (var role in roles)
        {
            roleClaims.Add(new Claim(ClaimTypes.Role, role));
        }
        var claims = new[]
        {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                new Claim("id", user.Id),
            }
        .Union(userClaims)
        .Union(roleClaims);
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Value.Key));
        var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
        var jwtSecurityToken = new JwtSecurityToken(
            issuer: _jwtSettings.Value.Issuer,
            audience: _jwtSettings.Value.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtSettings.Value.DurationInMinutes),
            signingCredentials: signingCredentials);

        return jwtSecurityToken;

    }

    public async Task<RegistrationResponse> RegisterUser(UserRegisterDto userRegisterDto)
    {
        var userexist = await _userManager.FindByEmailAsync(userRegisterDto.Email); 
        if (userexist != null)
            return new RegistrationResponse{
                Flag= false,
                Message = "User Already Exists",
                Errors = new [] { "Email Already taken" }
            };
       var  result =  _context.Users.Add(new User
        {
            Email = userRegisterDto.Email,
            UserName = userRegisterDto.Email,
            FirstName = userRegisterDto.FirstName,
            LastName = userRegisterDto.LastName,
            PhoneNumber = userRegisterDto.PhoneNumber,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            TwoFactorEnabled = true,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(userRegisterDto.Password)
        });
        await _userManager.CreateAsync(result.Entity, userRegisterDto.Password);

        await _context.SaveChangesAsync();
        if (result == null)
            return new RegistrationResponse
            {
                Flag = false,
                Message = "User Registration Failed",
                Errors = new[] { "Empty" }
            };
        
        else
        {
            await _userManager.AddToRoleAsync(result.Entity, "Admin");
        
        }
        
        var jwtSecurityToken = await GenerateJwtToken(result.Entity);
        var token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        var user = new UserRegisterDto
        {
            Email = result.Entity.Email,
            FirstName = result.Entity.FirstName,
            LastName = result.Entity.LastName,
            PhoneNumber = result.Entity.PhoneNumber,
            Password = BCrypt.Net.BCrypt.HashPassword(userRegisterDto.Password)
        };

        return new RegistrationResponse
        {
            Flag = true,
            Message = "User Successfully Registered",
            _userRegisterDto = user
        };
       
    }

    public Task<User> UpdateUser(UserUpdateDto userUpdateDto)
    {
        throw new NotImplementedException();
    }
}
