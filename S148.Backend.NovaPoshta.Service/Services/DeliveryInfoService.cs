﻿using NovaPoshtaApi;
using S148.Backend.NovaPoshta.Extensibility.Repositories;
using S148.Backend.NovaPoshta.Extensibility.Services;

namespace S148.Backend.NovaPoshta.Service.Services;

public class DeliveryInfoService : IDeliveryInfoService
{
    private readonly INovaPoshtaInfoRepository infoRepository;
    
    public DeliveryInfoService(INovaPoshtaInfoRepository infoRepository)
    {
        this.infoRepository = infoRepository;
    }
    
    public async Task<IReadOnlyCollection<City>> GetCitiesAsync(string nameFilter)
    {
        return (await infoRepository.GetCitiesByName(nameFilter)).ToList();
    }

    public async Task<IReadOnlyCollection<Warehouse>> GetWarehousesAsync(string cityId, string cityName, int limit)
        => (await infoRepository.GetWarehouses(cityId, cityName, limit)).ToList();
}