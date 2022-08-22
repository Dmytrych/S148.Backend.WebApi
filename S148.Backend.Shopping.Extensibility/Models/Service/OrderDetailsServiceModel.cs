namespace S148.Backend.Shopping.Extensibility.Models.Service;

public class OrderDetailsServiceModel
{
    public int ProductId { get; set; }

    public int OrderId { get; set; }

    public float UnitPrice { get; set; }

    public int Quantity { get; set; }
}