
namespace InterviewAngular.Server.Models;
public class ProductSpecification
{
    public string Id { get; set; }
    public string ProductId { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }

    public Product Product { get; set; }
}
