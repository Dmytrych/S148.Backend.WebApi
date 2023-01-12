using S148.Backend.Extensibility.NovaPoshta.Models;

namespace S148.Backend.Extensibility.NovaPoshta.ParameterCreators;

public class CityParameterCreator : IParameterCreator<LimitedCityParameters, CityFilter>
{
    public LimitedCityParameters Create(CityFilter filter)
    {
        var parameters = new LimitedCityParameters();
        if (filter.Limit > 0)
        {
            parameters.Limit = filter.Limit;
        }
        
        if (!filter.CityId.IsNullOrEmpty())
        {
            parameters.Ref = filter.CityId;
        }
        
        if (!filter.CityName.IsNullOrEmpty())
        {
            parameters.FindByString = filter.CityName;
        }

        return parameters;
    }
}