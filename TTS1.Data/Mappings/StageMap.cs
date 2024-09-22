using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TTS.Entity.Entities.UretimIslemleri;

namespace TTS.Data.Mappings
{
    public class StageMap : IEntityTypeConfiguration<Stage>
    {
        public void Configure(EntityTypeBuilder<Stage> builder)
        {
            builder.HasData(new Stage
            {
                Id = Guid.Parse("B9CDD9CA-B23C-4B0F-BD23-28ECBEB6BE66"),
                Name = "Kurutmaya bırakıldı",
                Parameter = "Kurutma",
                Timestamp = DateTime.Now,
                ProductId = Guid.Parse("971F7086-05E6-4C7A-92A8-216C924AFFDB"),

            },
            new Stage
            {
                Id = Guid.Parse("30A9512B-ED73-4338-988C-5B43BC810DE0"),
                Name = "Ayıklandı",
                Parameter = "Ayıklama",
                Timestamp = DateTime.Now,
                ProductId = Guid.Parse("64EF8E12-5802-4295-B902-AB9E3F9F03BD"),
            });
        }
    }
}
