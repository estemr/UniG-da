using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TTS.Entity.Entities.CevreselIzleme;

namespace TTS.Data.Mappings
{
    public class FieldMap : IEntityTypeConfiguration<Field>
    {
        public void Configure(EntityTypeBuilder<Field> builder)
        {
            builder.HasData(new Field
            {
                Id = Guid.Parse("2C953EE3-F4D1-4766-857F-94327E2B6138"),
                Name = "Taşlık Tarla",
                Location = "Suncuk Köyü",
                Size = 3.0,
                SoilType = "Kumlu",
                UserId = Guid.Parse("B497F1B4-3299-4CB9-94AF-E3A1A6C7AC8E"),
                CreatedBy = "Admin Test 1",
            },
            new Field
            {
                Id = Guid.Parse("2A5899EC-8B12-491C-9A4A-4E59C122D67D"),
                Name = "Güney Tarla",
                Location = "Erdemli Köyü",
                Size = 2.5,
                SoilType = "Killi",
                UserId = Guid.Parse("989AFD35-55A6-40A2-92B7-725A9B0E8822"),
                CreatedBy = "Admin Test 2",
            });
        }
    }
}
