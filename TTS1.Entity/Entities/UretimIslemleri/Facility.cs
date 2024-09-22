using TTS.Core.Entities;
using TTS.Entity.Entities.Lojistik;

namespace TTS.Entity.Entities.UretimIslemleri
{
    public class Facility : EntityBase
    {
        public Facility(){}

        public Facility(string name, string  location, string createdBy)
        {
            Name = name;
            Location = location;
            CreatedBy = createdBy;
        }

        public string Name { get; set; }
        public string Location { get; set; }

        public ICollection<Transport> Transports { get; set; }
        public ICollection<Stage> Stages { get; set; }
    }
}
