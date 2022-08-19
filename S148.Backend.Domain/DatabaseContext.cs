using Microsoft.EntityFrameworkCore;
using S148.Backend.Domain.Dto;

namespace S148.Backend.Domain;

public class DatabaseContext : DbContext, IDatabaseContext
{
    public DbSet<Order> Orders { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(
            @"host=localhost port=5432");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}