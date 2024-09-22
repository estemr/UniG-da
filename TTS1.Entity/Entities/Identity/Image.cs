using TTS.Core.Entities;
using TTS.Entity.Entities.CevreselIzleme;
using TTS.Entity.Entities.Lojistik;
using TTS.Entity.Enums;

namespace TTS.Entity.Entities.Identity
{
    public class Image : EntityBase
    {
        public Image() { }
        public Image(string fileName, string fileType, string createdBy)
        {
            FileName = fileName;
            FileType = fileType;
            CreatedBy = createdBy;
        }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public ImageType ImageType { get; set; }
        public ICollection<AppUser> Users { get; set; }
        public ICollection<Sensor> Sensors { get; set; }
        public ICollection<Vehicle> Vehicle { get; set; }
    }
}
