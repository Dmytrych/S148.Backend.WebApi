using Microsoft.EntityFrameworkCore;
using S148.Backend.Domain.Dto;
using S148.Backend.Domain.ProductSeeding;

namespace S148.Backend.Domain;

public class DatabaseContext : DbContext, IDatabaseContext
{
    private readonly IEntitySeeder<Product> entitySeeder;
    
    public DatabaseContext(
        DbContextOptions<DatabaseContext> options,
        IEntitySeeder<Product> entitySeeder)
        : base(options)
    {
        this.entitySeeder = entitySeeder;
    }

    public DbSet<Order> Orders { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<OrderDetails> OrderDetails { get; set; }
    
    public DbSet<DeliveryInfo> DeliveryInfo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderDetails>().HasKey(t => new {t.OrderId, t.ProductId});

        entitySeeder.Seed(modelBuilder.Entity<Product>());
    }
}