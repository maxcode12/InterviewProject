using EBusiness.API.Common;

namespace EBusiness.API.Dtos;

public class LoginResponse : BaseResponse
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
}
