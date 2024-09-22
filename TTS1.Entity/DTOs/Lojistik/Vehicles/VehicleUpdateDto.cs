using Microsoft.AspNetCore.Http;
using TTS.Entity.Entities.Identity;

namespace TTS.Entity.DTOs.Lojistik.Vehicles
{
    public class VehicleUpdateDto
    {
        public Guid Id { get; set; }
        public string Plate { get; set; }
        public string Model { get; set; }
        public string DriverName { get; set; }
    }
}
