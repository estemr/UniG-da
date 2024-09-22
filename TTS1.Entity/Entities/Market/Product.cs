using TTS.Core.Entities;
using TTS.Entity.Entities.Lojistik;
using TTS.Entity.Entities.UretimIslemleri;

namespace TTS.Entity.Entities.Market
{
    public class Product : EntityBase
    {
        public Product() {}
        public Product(string name, decimal price, string unit, string createdBy)
        {
            Name = name;
            Price = price;
            Unit = unit;
            CreatedBy = createdBy;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }

        public ICollection<Sale> Sale { get; set; }
        public ICollection<Stage> Stages { get; set; }
        public ICollection<Transport> Transports { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
