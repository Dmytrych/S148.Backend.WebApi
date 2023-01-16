﻿using S148.Backend.Extensibility;
using S148.Backend.Extensibility.Messaging;
using S148.Backend.NovaPoshta.Extensibility.Repositories;
using S148.Backend.Shopping.Extensibility.Models.Service;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;

namespace S148.Backend.Shopping.Service.OrderPlacement;

public class NovaPoshtaDeliveryInfoFactory : INovaPoshtaDeliveryInfoFactory
{
    private readonly INovaPoshtaInfoRepository novaPoshtaInfoRepository;

    private readonly IOperationResultFactory operationResultFactory;
    
    public NovaPoshtaDeliveryInfoFactory(
        IOperationResultFactory operationResultFactory,
        INovaPoshtaInfoRepository novaPoshtaInfoRepository)
    {
        this.novaPoshtaInfoRepository = novaPoshtaInfoRepository;
        this.operationResultFactory = operationResultFactory;
    }
    
    public async Task<OperationResult<NovaPoshtaDeliveryInfoServiceModel>> CreateAsync(NovaPoshtaOrderData deliveryData)
    {
        var foundCity = await novaPoshtaInfoRepository.GetCityByIdAsync(deliveryData.CityGuidRef);
        if (!foundCity.IsValid || foundCity.Result == null)
        {
            return operationResultFactory.FromStatusCode<NovaPoshtaDeliveryInfoServiceModel>(ShoppingProcessResultCodeNames.CityNotFound);
        }

        var foundWarehouse =
            await novaPoshtaInfoRepository.GetWarehouseByNumberAsync(foundCity.Result.Ref, deliveryData.WarehouseNumber);
        if (!foundWarehouse.IsValid || foundWarehouse.Result == null)
        {
            return operationResultFactory.FromStatusCode<NovaPoshtaDeliveryInfoServiceModel>(ShoppingProcessResultCodeNames.WarehouseNotFound);
        }

        return new OperationResult<NovaPoshtaDeliveryInfoServiceModel>(new NovaPoshtaDeliveryInfoServiceModel
        {
            AreaName = foundCity.Result.AreaDescription,
            AreaRef = foundCity.Result.Area,
            CityName = foundCity.Result.Description,
            CityRef = foundCity.Result.Ref,
            CityType = foundCity.Result.SettlementTypeDescription,
            WarehouseDescription = foundWarehouse.Result.Description,
            WarehouseNumber = foundWarehouse.Result.Number
        });
    }
}