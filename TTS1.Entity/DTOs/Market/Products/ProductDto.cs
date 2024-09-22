namespace TTS.Entity.DTOs.Market.Products
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public decimal Price { get; set; }
        public string CreatedBy { get; set; }
    }
}
