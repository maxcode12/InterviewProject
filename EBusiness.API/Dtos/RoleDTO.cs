namespace EBusiness.API.Dtos;
public class RoleDTO
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
}
public class CreateRoleDTO
{
    public string Name { get; set; }
}
public class RolePermissionDTO
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Page { get; set; }
    public string Module { get; set; }
    public string UserId { get; set; }
    public string Role { get; set; }
    public string RoleId { get; set; }
    public bool Create { get; set; }
    public bool Update { get; set; }
    public bool Delete { get; set; }
    public bool Read { get; set; }
}
public class PageModuleDTO
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string Page { get; set; }
    public string Module { get; set; }
}