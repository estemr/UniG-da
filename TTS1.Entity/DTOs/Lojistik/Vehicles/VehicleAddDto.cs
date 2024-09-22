using Microsoft.AspNetCore.Http;

namespace TTS.Entity.DTOs.Lojistik.Vehicles
{
    public class VehicleAddDto
    {
        public string Plate { get; set; }
        public string Model { get; set; }
        public string DriverName { get; set; }
    }
}
