using TTS.Entity.DTOs.CevreselIzleme.Fields;
using TTS.Entity.DTOs.Lojistik.Packages;
using TTS.Entity.DTOs.Lojistik.Vehicles;
using TTS.Entity.DTOs.Market.Products;
using TTS.Entity.DTOs.UretimIslemleri.Facilities;

namespace TTS.Entity.DTOs.Lojistik.Transports
{
    public class TransportAddDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Timestamp { get; set; }
        public Guid FacilityId { get; set; }
        public Guid FieldId { get; set; }
        public Guid VehicleId { get; set; }
        public Guid PackageId { get; set; }
        public Guid ProductId { get; set; }

        public IList<ProductDto> Products { get; set; }
        public IList<FacilityDto> Facilities { get; set; }
        public IList<FieldDto> Fields { get; set; }
        public IList<VehicleDto> Vehicles { get; set; }
        public IList<PackageDto> Packages { get; set; }

    }
}
