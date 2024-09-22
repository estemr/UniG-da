using TTS.Entity.DTOs.Market.Products;

namespace TTS.Entity.DTOs.UretimIslemleri.Stages
{
    public class StageDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Parameter { get; set; }
        public DateTime Timestamp { get; set; }

        public ProductDto Product { get; set; }


    }
}
