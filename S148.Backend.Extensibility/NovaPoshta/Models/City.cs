namespace S148.Backend.Extensibility.NovaPoshta.Models;

public class City
{
    public string Description { get; set; }

    public string DescriptionRu { get; set; }

    public Guid Ref { get; set; }

    public string Delivery1 { get; set; }

    public string Delivery2 { get; set; }

    public string Delivery3 { get; set; }

    public string Delivery4 { get; set; }

    public string Delivery5 { get; set; }

    public string Delivery6 { get; set; }

    public string Delivery7 { get; set; }

    public Guid Area { get; set; }
    
    public string AreaDescription { get; set; }

    public string SettlementType { get; set; }

    public string IsBranch { get; set; }

    public string PreventEntryNewStreetsUser { get; set; }

    public string[] Conglomerates { get; set; }

    public string CityID { get; set; }

    public string SettlementTypeDescriptionRu { get; set; }

    public string SettlementTypeDescription { get; set; }
}