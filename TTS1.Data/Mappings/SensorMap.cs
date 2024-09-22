using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TTS.Entity.Entities.CevreselIzleme;

namespace TTS.Data.Mappings
{
    public class SensorMap : IEntityTypeConfiguration<Sensor>
    {
        public void Configure(EntityTypeBuilder<Sensor> builder)
        {
            builder.HasData(new Sensor
            {
                Id = Guid.Parse("FDE368EE-2228-43EE-B3CC-1EA8932843A5"),
                Name = "Taşlıkbaş Sensör",
                FieldId = Guid.Parse("2C953EE3-F4D1-4766-857F-94327E2B6138"),
                Type = "Fotokapan",
                BatteryLevel = 0,
                ImageId = Guid.Parse("E5008BC7-140D-4DD9-A739-5EBF8EE01FA8"),
                CreatedDate = DateTime.Now,
            },
            new Sensor
            {
                Id = Guid.Parse("0123F278-FF34-44D0-AF18-F7F5882ED35A"),
                Name = "Güney Tarla Sensör",
                FieldId = Guid.Parse("2A5899EC-8B12-491C-9A4A-4E59C122D67D"),
                Type = "Toprak Nem Sensörü",
                BatteryLevel = 0,
                ImageId = Guid.Parse("D4A15540-AFAE-449E-B942-08B0E4E8F09C"),
                CreatedDate = DateTime.Now,
            });
        }
    }
}
