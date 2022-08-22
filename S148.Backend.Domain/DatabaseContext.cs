using Microsoft.EntityFrameworkCore;
using S148.Backend.Domain.Dto;

namespace S148.Backend.Domain;

public class DatabaseContext : DbContext, IDatabaseContext
{
    public DbSet<Order> Orders { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Product> Products { get; set; }

    public DbSet<OrderDetails> OrderDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            @"User ID=postgres;Password=karambol;Host=localhost;Port=5433;Database=S148_Server;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderDetails>().HasKey(t => new {t.OrderId, t.ProductId});

        modelBuilder.Entity<Product>().HasData(
            new Product { Id = 1,Name = "S148 - 200мл", UnitPrice = 200 },
            new Product { Id = 2,Name = "S148 - 20мл", UnitPrice = 50 });
    }
}