using System;

namespace S148.Backend.Domain.Dto;

public class NovaPoshtaDeliveryInfo
{
    public int Id { get; set; }
    
    public string CityName { get; set; }
    
    public string CityType { get; set; }
    
    public Guid CityRef { get; set; }

    public string AreaName { get; set; }
    
    public Guid AreaRef { get; set; }
    
    public string WarehouseInfo { get; set; }
    
    public bool CourierDelivery { get; set; }
    
    public string CourierDeliveryInfo { get; set; }
}