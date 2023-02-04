using Microsoft.EntityFrameworkCore.Metadata.Builders;
using S148.Backend.Domain.Dto;

namespace S148.Backend.Domain.Seeders;

public interface IEmbeddedImageSeeder
{
    void Seed(EntityTypeBuilder<Image> imageEntityBuilder);
}