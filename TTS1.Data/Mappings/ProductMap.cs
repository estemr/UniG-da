using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TTS.Entity.Entities.Market;

namespace TTS.Data.Mappings
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(new Product
            {
                Id = Guid.Parse("971F7086-05E6-4C7A-92A8-216C924AFFDB"),
                Name = "Fındık",
                Price = 130,
                Unit = "Kg"
                
            },
            new Product
            {
                Id = Guid.Parse("64EF8E12-5802-4295-B902-AB9E3F9F03BD"),
                Name = "Kestane",
                Price = 250,
                Unit = "Tane"
            });
        }
    }
}
