using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using S148.Backend.Domain.Dto;

namespace S148.Backend.Domain;

public interface IDatabaseContext
{
    DbSet<Order> Orders { get; set; }

    DbSet<Customer> Customers { get; set; }

    DbSet<Product> Products { get; set; }

    public DbSet<Image> Images { get; set; }

    DbSet<OrderDetails> OrderDetails { get; set; }
    
    DbSet<DeliveryInfo> DeliveryInfo { get; set; }

    DatabaseFacade Database { get; }

    int SaveChanges();
}