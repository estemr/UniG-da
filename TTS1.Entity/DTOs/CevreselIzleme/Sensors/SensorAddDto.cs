using Microsoft.AspNetCore.Http;
using TTS.Entity.DTOs.CevreselIzleme.Fields;

namespace TTS.Entity.DTOs.CevreselIzleme.Sensors
{
    public class SensorAddDto
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public Guid FieldId { get; set; }
 
        public IList<FieldDto> Fields { get; set; }
    }
}
