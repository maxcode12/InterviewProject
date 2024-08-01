
namespace EBusiness.API.Server.Models;
public class UserRole
{
    public string UserId { get; set; }
    public string RoleId { get; set; }

    public User Users { get; set; }
    public Role Roles { get; set; }
   
}
