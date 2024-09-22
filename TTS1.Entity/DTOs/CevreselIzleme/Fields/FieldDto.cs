using TTS.Entity.DTOs.Users;

namespace TTS.Entity.DTOs.CevreselIzleme.Fields
{
    public class FieldDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string SoilType { get; set; }
        public double Size { get; set; }
        public string CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
