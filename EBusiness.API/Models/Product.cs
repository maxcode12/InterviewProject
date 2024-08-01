using System.ComponentModel.DataAnnotations;

namespace EBusiness.API.Server.Models;

public class Product
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    
    [Required]
    [StringLength(50)]
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public decimal Price {get; set;}
    public string SKU { get; set; }
    public int QuantityInStock { get; set; }
    public decimal CostPrice { get; set; }
    public bool IsFeatured { get; set; }
    public bool IsNew { get; set; }
    public bool IsOnSale { get; set; }
    public decimal Discount { get; set; }
    public string ProductBrandId { get; set; }
    public ICollection<ProductImage> Images { get; set; }
    public ICollection<ProductCategory> Categories { get; set; }
    public ICollection<ProductSpecification> Specifications { get; set; }
    public ProductBrand ProductBrand { get; set; }
    public ICollection<OrderDetail> OrderDetails { get; set; }
    public ICollection<CartItem> CartItems { get; set; }
}
