using System.ComponentModel.DataAnnotations.Schema;

namespace S148.Backend.Domain.Dto;

public class Order
{
    public int Id { get; set; }

    public Customer Customer { get; set; }

    [ForeignKey("Customer")]
    public int CustomerId { get; set; }

    public Product Product { get; set; }

    [ForeignKey("Product")]
    public int ProductId { get; set; }
}