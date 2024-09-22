using TTS.Entity.DTOs.CevreselIzleme.Sensors;

namespace TTS.Entity.DTOs.CevreselIzleme.SensorDatas
{
    public class SensorDataDto
    {
        public Guid Id { get; set; }
        public SensorDto Sensor { get; set; }

        public string Value { get; set; }
        public string Unit { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
