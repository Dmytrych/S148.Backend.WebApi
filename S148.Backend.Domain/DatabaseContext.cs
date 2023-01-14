using Microsoft.EntityFrameworkCore;
using S148.Backend.Domain.Dto;

namespace S148.Backend.Domain;

public class DatabaseContext : DbContext, IDatabaseContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
    { }
    
    public DbSet<Order> Orders { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<OrderDetails> OrderDetails { get; set; }
    
    public DbSet<DeliveryInfo> DeliveryInfo { get; set; }

    public DbSet<NovaPoshtaDeliveryInfo> NovaPoshtaDeliveryInfo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderDetails>().HasKey(t => new {t.OrderId, t.ProductId});

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1,Name = "S148 - 200мл", UnitPrice = 200 },
            new Product { Id = 2,Name = "S148 - 20мл", UnitPrice = 50 });
    }
}