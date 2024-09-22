using TTS.Entity.Entities.Identity;

namespace TTS.Entity.DTOs.Lojistik.Vehicles
{
    public class VehicleDto
    {
        public Guid Id { get; set; }
        public string Plate { get; set; }
        public string Model { get; set; }
        public string DriverName { get; set; }
    }
}
