namespace EBusiness.API.Server.Models;
public class Cart
{
    public string Id { get; set; }
    public string UserId { get; set; }

    public User User { get; set; }
    public ICollection<CartItem> CartItems{get; set;}
}
