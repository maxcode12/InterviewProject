namespace EBusiness.API.Dtos;

public class RegistrationResponse
{
    public bool Flag { get; set; }
    public string Message { get; set; }
    public UserRegisterDto _userRegisterDto { get; set; }
    public IEnumerable<string> Errors { get; set; }
   
}
