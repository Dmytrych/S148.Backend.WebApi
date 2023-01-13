using S148.Backend.Extensibility.NovaPoshta.Models;
using S148.Backend.Extensibility.NovaPoshta.OnlineSettlementSearch;

namespace S148.Backend.Extensibility.NovaPoshta.ParameterCreators;

public class QuickCityParameterCreator : IParameterCreator<LimitedQuickCityParameters, QuickCityFilter>
{
    private const string RequiredParameterErrorMessage = "The city request '{0}' parameter can not be empty";
    
    public LimitedQuickCityParameters Create(QuickCityFilter filter)
    {
        var parameters = new LimitedQuickCityParameters();
        if (filter.Limit > 0)
        {
            parameters.Limit = filter.Limit;
        }
        else
        {
            throw new ArgumentException(String.Format(RequiredParameterErrorMessage, nameof(parameters.Limit)));
        }
        
        if (filter.Page > 0)
        {
            parameters.Page = filter.Page;
        }
        else
        {
            throw new ArgumentException(String.Format(RequiredParameterErrorMessage, nameof(parameters.Page)));
        }
        
        if (!filter.CityName.IsNullOrEmpty())
        {
            parameters.CityName = filter.CityName;
        }

        return parameters;
    }
}