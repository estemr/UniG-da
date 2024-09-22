using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TTS.Entity.Entities.Lojistik;

namespace TTS.Data.Mappings
{
    public class VehicleMap : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasData(new Vehicle
            {
                Id = Guid.Parse("7E52C16F-83F5-4FED-83D4-D64E1EDC4098"),
                Plate = "81 AH 975",
                Model = "Renault Clio 2006",
                DriverName = "Esat Emir Albayrakoğlu",
            },
            new Vehicle
            {
                Id = Guid.Parse("CD55A1FB-E592-4679-8BCA-5883DEC0163F"),
                Plate = "06 DSA 100",
                Model = "Toyota Corolla 2005",
                DriverName = "Melih Albayrakoğlu",
            });
        }
    }
}
