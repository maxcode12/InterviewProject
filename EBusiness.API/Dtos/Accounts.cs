using System.ComponentModel.DataAnnotations;

namespace EBusiness.API.Dtos;

public class Accounts
{
}

//User Register Dto
public class UserRegisterDto
{
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
   


}

//User Login Dto

public class UserLoginDto
{
    [EmailAddress]
    public string Email { get; set; }
    public string Password { get; set; }
}

//User Update Dto
public class UserUpdateDto
{
    [EmailAddress]
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public string PhoneNumber { get; set; }
}

//Find User by Email Dto
public class FindUserByEmailDto
{
    [EmailAddress]
    public string Email { get; set; }
}

