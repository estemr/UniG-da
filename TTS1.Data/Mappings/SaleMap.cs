using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TTS.Entity.Entities.Market;

namespace TTS.Data.Mappings
{
    public class SaleMap : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.HasData(new Sale
            {
                Id = Guid.Parse("769256CE-A7B0-48E8-853B-08A8A4257639"),
                ProductId = Guid.Parse("971F7086-05E6-4C7A-92A8-216C924AFFDB"),
                ProductCount = 1,
                SaleDate = DateTime.Now,
                UserId = Guid.Parse("B497F1B4-3299-4CB9-94AF-E3A1A6C7AC8E"),
            },
            new Sale
            {
                Id = Guid.Parse("DFE84775-A1A2-4DF3-A910-873C86876138"),
                ProductId = Guid.Parse("64EF8E12-5802-4295-B902-AB9E3F9F03BD"),
                ProductCount = 2,
                SaleDate = DateTime.Now,
                UserId = Guid.Parse("989AFD35-55A6-40A2-92B7-725A9B0E8822"),
            });
        }
    }
}
