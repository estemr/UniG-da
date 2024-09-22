using TTS.Entity.DTOs.CevreselIzleme.Fields;
namespace TTS.Entity.DTOs.CevreselIzleme.Sensors
{
    public class SensorDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public FieldDto Field { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public double? BatteryLevel { get; set; }
        public bool IsDeleted { get; set; }
    }
}
