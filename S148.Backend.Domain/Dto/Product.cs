using System.ComponentModel.DataAnnotations.Schema;

namespace S148.Backend.Domain.Dto;

public class Product
{
    public int Id { get; set; }

    public string Name { get; set; }

    public decimal UnitPrice { get; set; }
}