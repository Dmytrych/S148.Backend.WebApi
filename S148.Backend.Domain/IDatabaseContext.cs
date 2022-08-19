using Microsoft.EntityFrameworkCore;
using S148.Backend.Domain.Dto;

namespace S148.Backend.Domain;

public interface IDatabaseContext
{
    public DbSet<Order> Orders { get; set; }

    public DbSet<Customer> Customers { get; set; }

    public DbSet<Product> Products { get; set; }
}