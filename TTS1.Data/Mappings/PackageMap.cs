using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TTS.Entity.Entities.Lojistik;

namespace TTS.Data.Mappings
{
    public class PackageMap : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
            builder.HasData(new Package
            {
                Id = Guid.Parse("3082F889-EFAC-4A83-8EDA-622DFE90C5B4"),
                Type = "Kutu",
                Number = 1,
                PackagingDate = DateTime.Now,
            },
            new Package
            {
                Id = Guid.Parse("B411F8DF-5816-4BA7-A86B-1D96C699B02C"),
                Type = "Torba",
                Number = 2,
                PackagingDate = DateTime.Now,
            });
        }
    }
}
