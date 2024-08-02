using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EBusiness.API.Server.Models;

public class User : IdentityUser
{
    public string userId { get; set; } = Guid.NewGuid().ToString();
    [Required]
    [StringLength(150)]
    public string FirstName { get; set; } = string.Empty;
    [StringLength(150)]
    public string LastName { get; set; } = string.Empty;
     
    public ICollection<Order> Orders { get; set; }
}
