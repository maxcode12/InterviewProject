namespace EBusiness.API.Models;

public class PageRolePremission 
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public string? FkPage { get; set; }
    public string? FkRole { get; set; }
    public bool Create { get; set; }
    public bool Update { get; set; }
    public bool Delete { get; set; }
    public bool Read { get; set; }
}
