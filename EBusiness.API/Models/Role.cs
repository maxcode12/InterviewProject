using System.ComponentModel.DataAnnotations;

namespace EBusiness.API.Server.Models;

public class Role
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    public ICollection<UserRole> UserRoles { get; set; } 
}