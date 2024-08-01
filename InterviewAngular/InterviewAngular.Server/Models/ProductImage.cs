
namespace InterviewAngular.Server.Models;
public class ProductImage
{
    public string Id { get; set; }
    public string ProductId { get; set; }
    public string ImageUrl { get; set; }

    public Product Product { get; set; }
}
