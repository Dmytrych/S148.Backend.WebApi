using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace S148.Backend.Domain.ProductSeeding;

public interface IEntitySeeder<TEntity>
where TEntity : class
{
    void Seed(EntityTypeBuilder<TEntity> entityTypeBuilder);
}