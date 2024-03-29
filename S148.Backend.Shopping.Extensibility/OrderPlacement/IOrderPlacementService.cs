﻿using ErrorOr;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;

namespace S148.Backend.Shopping.Extensibility.OrderPlacement;

public interface IOrderPlacementService<in TDeliveryData>
    where TDeliveryData : IOrderData
{
    ErrorOr<OrderPlacementResponse> Create(TDeliveryData orderData);
}