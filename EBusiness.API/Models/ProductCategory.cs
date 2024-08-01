
namespace EBusiness.API.Server.Models;
public class ProductCategory
{
    public string Id { get; set; }
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; }
}
