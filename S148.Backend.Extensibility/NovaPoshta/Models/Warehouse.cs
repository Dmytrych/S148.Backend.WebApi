using NovaPoshtaApi;

namespace S148.Backend.Extensibility.NovaPoshta.Models;

public class Warehouse
{
    public string SiteKey { get; set; }

    public string Description { get; set; }

    public string DescriptionRu { get; set; }

    public string Phone { get; set; }

    public string TypeOfWarehouse { get; set; }

    public Guid Ref { get; set; }

    public int Number { get; set; }

    public Guid CityRef { get; set; }

    public string CityDescription { get; set; }

    public string CityDescriptionRu { get; set; }

    public string Longitude { get; set; }

    public string Latitude { get; set; }

    public string PostFinance { get; set; }

    public string BicycleParking { get; set; }

    public string POSTTerminal { get; set; }

    public string InternationalShipping { get; set; }

    public int TotalMaxWeightAllowed { get; set; }

    public int PlaceMaxWeightAllowed { get; set; }

    public Schedule Reception { get; set; }

    public Schedule Delivery { get; set; }

    public Schedule Schedule { get; set; }
}