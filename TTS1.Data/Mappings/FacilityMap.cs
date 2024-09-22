using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TTS.Entity.Entities.UretimIslemleri;

namespace TTS.Data.Mappings
{
    public class FacilityMap : IEntityTypeConfiguration<Facility>
    {
        public void Configure(EntityTypeBuilder<Facility> builder)
        {
            builder.HasData(new Facility
            {
                Id = Guid.Parse("93580E2A-268C-4FAB-A91D-76791940D6C6"),
                Name = "TMO",
                Location = "Düzce"

            },
            new Facility
            {
                Id = Guid.Parse("308AA8DC-7E56-4EF9-8A23-B21FAD372CD4"),
                Name = "Albayrakoğlu Tarım İşletmesi",
                Location = "Ankara"
            });
        }
    }
}
