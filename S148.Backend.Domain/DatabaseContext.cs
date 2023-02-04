using Microsoft.EntityFrameworkCore;
using S148.Backend.Domain.Dto;
using S148.Backend.Domain.Seeders;

namespace S148.Backend.Domain;

public class DatabaseContext : DbContext, IDatabaseContext
{
    private readonly IEmbeddedImageSeeder embeddedImageSeeder;

    public DatabaseContext(DbContextOptions<DatabaseContext> options, IEmbeddedImageSeeder embeddedImageSeeder)
        : base(options)
    {
        this.embeddedImageSeeder = embeddedImageSeeder;
    }
    
    public DbSet<Order> Orders { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Product> Products { get; set; }
    
    public DbSet<Image> Images { get; set; }

    public DbSet<OrderDetails> OrderDetails { get; set; }
    
    public DbSet<DeliveryInfo> DeliveryInfo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderDetails>().HasKey(t => new {t.OrderId, t.ProductId});

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1,Name = "S148 - 200мл", UnitPrice = 200 },
            new Product { Id = 2,Name = "S148 - 20мл", UnitPrice = 50 });
        
        embeddedImageSeeder.Seed(modelBuilder.Entity<Image>());
    }
}