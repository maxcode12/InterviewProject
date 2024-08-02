using EBusiness.API.Dtos;
using EBusiness.API.Server.Models;
using System.Diagnostics.CodeAnalysis;

namespace EBusiness.API.Interfaces;

public interface IAuthenticateUser
{
    Task<RegistrationResponse> RegisterUser(UserRegisterDto userRegisterDto);
    //Task<Response<object>> LoginUser(UserLoginDto userLoginDto);
    Task<User> UpdateUser(UserUpdateDto userUpdateDto);
    Task<User> FindUserByEmail(FindUserByEmailDto findUserByEmailDto);
    Task<LoginResponse> LoginUser([NotNull] UserLoginDto userLoginDto);
}
