using TTS.Core.Entities;
using TTS.Entity.Entities.Market;

namespace TTS.Entity.Entities.UretimIslemleri
{
    public class Stage : EntityBase
    {

        public Stage() { }

        public Stage(string name, string parameter, DateTime timestamp, Guid productId, string createdBy)
        {
            Name = name;
            Parameter = parameter;
            Timestamp = timestamp;
            ProductId = productId;
            CreatedBy = createdBy;
        }

        public string Name { get; set; }
        public string Parameter { get; set; }
        public DateTime Timestamp { get; set; }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }


    }
}
