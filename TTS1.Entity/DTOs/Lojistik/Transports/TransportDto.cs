using TTS.Entity.DTOs.CevreselIzleme.Fields;
using TTS.Entity.DTOs.Lojistik.Packages;
using TTS.Entity.DTOs.Lojistik.Vehicles;
using TTS.Entity.DTOs.Market.Products;
using TTS.Entity.DTOs.UretimIslemleri.Facilities;

namespace TTS.Entity.DTOs.Lojistik.Transports
{
    public class TransportDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }

        public ProductDto Product { get; set; }
        public FieldDto Field { get; set; }
        public VehicleDto Vehicle { get; set; }
        public FacilityDto Facility { get; set; }
        public PackageDto Package { get; set; }

        
    }
}
