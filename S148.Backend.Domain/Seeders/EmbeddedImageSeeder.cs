using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using S148.Backend.Domain.Dto;

namespace S148.Backend.Domain.Seeders;

public class EmbeddedImageSeeder : IEmbeddedImageSeeder
{
    private const string ProductImagesStorePathToken = "ProductImagesStorePath";
    
    private readonly IConfiguration configuration;
    
    public EmbeddedImageSeeder(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    
    public void Seed(EntityTypeBuilder<Image> imageEntityBuilder)
    {
        var images = ReadImages();
        imageEntityBuilder.HasData(images);
    }
    
    private IReadOnlyCollection<Image> ReadImages()
    {
        var imageStorePath = configuration[ProductImagesStorePathToken];
        var fileNames = Directory.GetFiles(imageStorePath);
        var productImagePaths = fileNames.Where(fileName => Path.HasExtension(fileName) && Path.GetExtension(fileName) == ".png").ToList();

        var loadedImages = new List<Image>();
        for (int i = 1; i < productImagePaths.Count + 1; i++)
        {
            var file = File.OpenRead(productImagePaths[i - 1]);
            var fileBytes = new BinaryReader(file).ReadBytes((int)file.Length);
            loadedImages.Add(new Image
            {
                Id = i,
                Extension = Path.GetExtension(productImagePaths[i - 1]),
                Name = Path.GetFileNameWithoutExtension(productImagePaths[i - 1]),
                MD5Checksum = Encoding.Default.GetString(MD5.Create().ComputeHash(fileBytes)),
                Content = fileBytes
            });
        }
        return loadedImages;
    }
}