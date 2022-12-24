using S148.Backend.Extensibility.NovaPoshta.Models;
using S148.Backend.Extensibility.StringUtils;

namespace S148.Backend.Extensibility.NovaPoshta.ParameterCreators;

public class WarehouseParameterCreator : IParameterCreator<LimitedWarehouseParameters, WarehouseFilter>
{
    public LimitedWarehouseParameters Create(WarehouseFilter filter)
    {
        var parameters = new LimitedWarehouseParameters();
        if (filter.Limit > 0)
        {
            parameters.Limit = filter.Limit;
            parameters.Page = filter.Page;
        }

        if (filter.WarehouseId != null)
        {
            parameters.WarehouseId = filter.WarehouseId.Value.ToString();
        }

        if (!filter.CityId.IsNullOrEmpty())
        {
            parameters.CityRef = filter.CityId;
        }
        
        if (!filter.CityName.IsNullOrEmpty())
        {
            parameters.CityName = filter.CityName;
        }

        return parameters;
    }
}