using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTS.Entity.Entities.CevreselIzleme;

namespace TTS.Data.Mappings
{
    public class SensorDataMap : IEntityTypeConfiguration<SensorData>
    {
        public void Configure(EntityTypeBuilder<SensorData> builder)
        {

            builder.HasData(new SensorData
            {
                Id = Guid.NewGuid(),
                Value = "Fotokapan kayıtlarına göre bir canlı kayıtlara girmiştir.",
                SensorId = Guid.Parse("FDE368EE-2228-43EE-B3CC-1EA8932843A5"),
                Timestamp = DateTime.Now,
                Unit = "°C"
            },
            new SensorData
            {
                Id = Guid.NewGuid(),
                Value = "Toprak nemi 12 bar olarak ölçülmüştür.",
                SensorId = Guid.Parse("0123F278-FF34-44D0-AF18-F7F5882ED35A"),
                Timestamp = DateTime.Now,
                Unit = "pH"
            });
        }
    }
}
