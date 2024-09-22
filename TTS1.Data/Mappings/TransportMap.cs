using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TTS.Entity.Entities.Lojistik;

namespace TTS.Data.Mappings
{
    public class TransportMap : IEntityTypeConfiguration<Transport>
    {
        public void Configure(EntityTypeBuilder<Transport> builder)
        {
            builder.HasData(new Transport
            {
                Id = Guid.Parse("F214B7D2-B956-438F-A439-397D51529E1F"),
                Name = "Fındık Transfer",
                VehicleId = Guid.Parse("7E52C16F-83F5-4FED-83D4-D64E1EDC4098"),
                FacilityId = Guid.Parse("93580E2A-268C-4FAB-A91D-76791940D6C6"),
                Timestamp = DateTime.Now,
                FieldId = Guid.Parse("2C953EE3-F4D1-4766-857F-94327E2B6138"),
                PackageId = Guid.Parse("3082F889-EFAC-4A83-8EDA-622DFE90C5B4"),
                ProductId = Guid.Parse("971F7086-05E6-4C7A-92A8-216C924AFFDB"),
            },
            new Transport
            {
                Id = Guid.Parse("CB6DE695-3D05-4439-89C9-30493779ABE9"),
                Name = "Kestane Transfer",
                VehicleId = Guid.Parse("CD55A1FB-E592-4679-8BCA-5883DEC0163F"),
                FacilityId = Guid.Parse("308AA8DC-7E56-4EF9-8A23-B21FAD372CD4"),
                Timestamp = DateTime.Now,
                FieldId = Guid.Parse("2A5899EC-8B12-491C-9A4A-4E59C122D67D"),
                PackageId = Guid.Parse("B411F8DF-5816-4BA7-A86B-1D96C699B02C"),
                ProductId = Guid.Parse("64EF8E12-5802-4295-B902-AB9E3F9F03BD"),
            });
        }
    }
}
