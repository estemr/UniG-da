using Microsoft.AspNetCore.Http;
using TTS.Entity.Entities.Identity;

namespace TTS.Entity.DTOs.CevreselIzleme.Fields
{
    public class FieldUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public double Size { get; set; }
        public string SoilType { get; set; }
    }
}
