using NovaPoshtaApi;

namespace S148.Backend.Extensibility.NovaPoshta;

public class LimitedCityParameters : CityParameters
{
    public int Limit { get; set; }
    
    public string Ref { get; set; }
}