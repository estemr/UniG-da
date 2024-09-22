using TTS.Core.Entities;
using TTS.Entity.Entities.Market;

namespace TTS.Entity.Entities.Lojistik
{
    public class Package : EntityBase
    {
        public Package() { }
        public Package(string type, int number, DateTime packagingDate, string createdBy)
        {
            Type = type;
            Number = number;
            PackagingDate = packagingDate;
            CreatedBy = createdBy;
        }

        public string Type { get; set; }
        public int Number { get; set; }

        public DateTime PackagingDate { get; set; } = DateTime.Now;

        public IList<Transport> Transports { get; set; }
    }
}
