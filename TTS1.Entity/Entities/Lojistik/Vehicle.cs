using TTS.Core.Entities;
using TTS.Entity.Entities.Identity;

namespace TTS.Entity.Entities.Lojistik
{
    public class Vehicle : EntityBase
    {
        public Vehicle(){}
        public Vehicle(string plate, string model, string driverName, string createdBy)
        {
            Plate = plate;
            Model = model;
            DriverName = driverName;
            CreatedBy = createdBy;
        }

        public string Plate {  get; set; }
        public string Model { get; set; }
        public string DriverName { get; set; }

        public ICollection<Transport> Transports { get; set; }
    }
}
