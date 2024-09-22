using Microsoft.AspNetCore.Http;
using TTS.Entity.DTOs.CevreselIzleme.Fields;
using TTS.Entity.Entities.Identity;

namespace TTS.Entity.DTOs.CevreselIzleme.Sensors
{
    public class SensorUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public Guid FieldId { get; set; }

        public IList<FieldDto> Fields { get; set; }
    }
}
