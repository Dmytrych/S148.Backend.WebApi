using System.ComponentModel.DataAnnotations.Schema;

namespace S148.Backend.Domain.Dto;

public class OrderDetails
{
    public Product Product { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; }

    public Order Order { get; set; }

    [ForeignKey("Order")]
    public int OrderId { get; set; }

    public float UnitPrice { get; set; }

    public int Quantity { get; set; }

    public float? Discount { get; set; }
    
    public string Description { get; set; }
}