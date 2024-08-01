
namespace InterviewAngular.Server.Models;
public class ProductBrand
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public ICollection<Product> Products { get; set; }
}