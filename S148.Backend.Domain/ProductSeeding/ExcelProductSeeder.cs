using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using S148.Backend.Domain.Dto;
using S148.Backend.Extensibility;

namespace S148.Backend.Domain.ProductSeeding;

public class ExcelProductSeeder : IEntitySeeder<Product>
{
    private readonly IConfiguration configuration;

    public ExcelProductSeeder(IConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public void Seed(EntityTypeBuilder<Product> entityTypeBuilder)
    {
        try
        {
            using var fileReader =
                new StreamReader(new FileStream(configuration[ConfigurationTokens.ProductFilePathToken], FileMode.Open,
                    FileAccess.Read));

            var loadedProducts = JsonSerializer.Deserialize<IReadOnlyCollection<Product>>(fileReader.ReadToEnd());

            if (LoadedProductsContainMistakes(loadedProducts))
            {
                throw new ArgumentException("The product validation failed. Please, check the given file");
            }

            entityTypeBuilder.HasData(loadedProducts);
        }
        catch (Exception e)
        {
            throw new ArgumentException("Could not load products list", e);
        }
    }

    private bool LoadedProductsContainMistakes(IReadOnlyCollection<Product> products)
        => products
            .Any(product =>
                product.Id == null
                || product.Name.IsNullOrEmpty()
                || product.ImageName.IsNullOrEmpty()
                || product.UnitPrice <= 0);
}