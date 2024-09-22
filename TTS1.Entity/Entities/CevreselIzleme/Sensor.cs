using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTS.Core.Entities;
using TTS.Entity.Entities.Identity;

namespace TTS.Entity.Entities.CevreselIzleme
{
    public class Sensor : EntityBase
    {
        public Sensor()
        {
        }
        public Sensor(string name, string type, Guid fieldId, DateTime createdDate, string createdBy)
        {
            Name = name;
            Type = type;
            FieldId = fieldId;
            CreatedDate = createdDate;
            CreatedBy = createdBy;
        }


        public string Name { get; set; }
        public string Type { get; set; }
        public Guid FieldId { get; set; }
        public Field Field { get; set; }

        public Guid? ImageId {  get; set; }
        public Image Image {  get; set; }

        public double? BatteryLevel { get; set; } = 0;
        public ICollection<SensorData> SensorData { get; set; }
    }
}
