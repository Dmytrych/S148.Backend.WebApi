namespace S148.Backend.Shopping.Extensibility.Models.Service;

public class DeliveryInfoServiceModel
{
    public int Id { get; set; }
    
    public string CityName { get; set; }
    
    public string CityType { get; set; }
    
    public string CityRef { get; set; }

    public int NovaPoshtaDeliveryInfo { get; set; }

    public int UkrposhtaDeliveryInfo { get; set; }
}