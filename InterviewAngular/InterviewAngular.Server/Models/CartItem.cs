
namespace InterviewAngular.Server.Models;
public class CartItem
{
    public string Id { get; set; }
    public string CartId { get; set; }
    public string ProductId { get; set; }
    public int Quantity { get; set; }
    public decimal Price{ get; set; }
    public Cart Cart{ get; set; }
    public Product Product { get; set; }
}