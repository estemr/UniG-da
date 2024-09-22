using TTS.Core.Entities;
using TTS.Entity.Entities.CevreselIzleme;
using TTS.Entity.Entities.Market;
using TTS.Entity.Entities.UretimIslemleri;

namespace TTS.Entity.Entities.Lojistik
{
    public class Transport : EntityBase
    {
        public Transport() { }

        public Transport(string name,Guid vehicleId, Guid fielId, Guid facilityId, Guid packageId, Guid productId, DateTime timestamp, string createdBy)
        {
            Name = name;
            VehicleId = vehicleId;
            FieldId = fielId;
            FacilityId = facilityId;
            PackageId = packageId;
            ProductId = productId;
            Timestamp = timestamp;
            CreatedBy = createdBy;
        }

        public string Name { get; set; }
        public DateTime Timestamp { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public Guid VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

        public Guid FieldId { get; set; }
        public Field Field { get; set; }

        public Guid FacilityId { get; set; }
        public Facility Facility { get; set; }

        public Guid PackageId { get; set; }
        public Package Package { get; set; }


    }
}
