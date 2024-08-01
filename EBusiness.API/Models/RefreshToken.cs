using EBusiness.API.Server.Models;

namespace EBusiness.API.Models;

public class RefreshToken
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public string Token { get; set; }
    public DateTime Expires { get; set; }
    public bool IsUsed { get; set; }
    public bool IsRevoked { get; set; }

    public User User { get; set; }
}
