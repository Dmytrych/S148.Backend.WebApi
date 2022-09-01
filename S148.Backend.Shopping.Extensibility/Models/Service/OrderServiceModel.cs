using S148.Backend.Domain.Dto;

namespace S148.Backend.Shopping.Extensibility.Models.Service;

public class OrderServiceModel
{
    public int Id { get; set; }

    public int CustomerId { get; set; }
    
    public int DeliveryInfoId { get; set; }
}