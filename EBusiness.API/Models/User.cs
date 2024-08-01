using System.ComponentModel.DataAnnotations;

namespace EBusiness.API.Server.Models;

public class User
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [Required]
    [StringLength(150)]
    public string FirstName { get; set; } = string.Empty;
    [StringLength(150)]
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    [EmailAddress]
    [StringLength(256)]
    public string Email { get; set; } = string.Empty;
    [Required]
    [StringLength(20, MinimumLength =8)]
    [DataType(DataType.Password)]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]+$", ErrorMessage = "Password must contain at least one lowercase, one uppercase, one number, and one special character.")]
    public string Password { get; set; } = string.Empty;

    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<Order> Orders { get; set; }
}
