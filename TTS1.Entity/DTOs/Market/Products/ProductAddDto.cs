using TTS.Entity.DTOs.UretimIslemleri.Stages;

namespace TTS.Entity.DTOs.Market.Products
{
    public class ProductAddDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Unit { get; set; }

    }
}
