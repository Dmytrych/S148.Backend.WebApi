﻿namespace S148.Backend.Shopping.Extensibility.Models.Service;

public class NovaPoshtaDeliveryInfoServiceModel
{
    public int Id { get; set; }
    
    public string CityName { get; set; }
    
    public string CityType { get; set; }
    
    public Guid CityRef { get; set; }

    public string AreaName { get; set; }
    
    public Guid AreaRef { get; set; }
    
    public int WarehouseNumber { get; set; }
    
    public string WarehouseDescription { get; set; }
}