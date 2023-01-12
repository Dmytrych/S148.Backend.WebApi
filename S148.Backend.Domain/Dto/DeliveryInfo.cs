using System.ComponentModel.DataAnnotations.Schema;

namespace S148.Backend.Domain.Dto;

public class DeliveryInfo
{
    public int Id { get; set; }

    [ForeignKey("NovaPoshtaDeliveryInfo")]
    public int NovaPoshtaDeliveryInfoId { get; set; }

    public int NovaPoshtaDeliveryInfo { get; set; }
}