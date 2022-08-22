using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace S148.Backend.Domain.Dto;

public class Order
{
    public Order()
    {
        OrderDetails = new List<OrderDetails>();
    }

    public int Id { get; set; }

    public Customer Customer { get; set; }

    [ForeignKey("Customer")]
    public int CustomerId { get; set; }

    public ICollection<OrderDetails> OrderDetails { get; set; }
}