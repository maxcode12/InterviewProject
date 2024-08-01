using EBusiness.API.Enums;

namespace EBusiness.API.Server.Models;
public class Order
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime OrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public OrderStatus OrderStatus { get; set; }
    public string ShippingAddress { get; set; }
    public string BillingAddress { get; set; }
    public string ShippingMethod { get; set; }
    public decimal ShippingCost { get; set; }
    public string PaymentMethod { get; set; }
    public string OrderNumber { get; set; } // Unique order identifier
    public DateTime? ShippedDate { get; set; }
    public DateTime? DeliveredDate { get; set; }

    //Navigation properties
    public string UserId { get; set; }
    public User User{ get; set;}
    public ICollection<OrderDetail> OrderDetails { get; set; }
}
