using TTS.Core.Entities;

namespace TTS.Entity.Entities.CevreselIzleme
{
    public class SensorData : EntityBase
    {
        public SensorData(){}
        public SensorData(Guid sensorId, string value, string unit, DateTime timestamp, string createdBy)
        {
            SensorId = sensorId;
            Value = value;
            Unit = unit;
            Timestamp = timestamp;
            CreatedBy = createdBy;
        }
        public Guid SensorId { get; set; }
        public Sensor Sensor { get; set; }

        public string Value { get; set; }
        public string Unit { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.Now;
    }
}
