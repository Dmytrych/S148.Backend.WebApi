﻿using S148.Backend.Extensibility;
using S148.Backend.Shopping.Extensibility.OrderPlacement.Models;

namespace S148.Backend.Shopping.Service.Validators;

public interface IOrderContentValidator
{
    OperationResult Validate(IReadOnlyCollection<ProductOrderingInfo> products);
}