using TTS.Entity.DTOs.Market.Products;

namespace TTS.Entity.DTOs.Yorum
{
    public class CommentDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CreatedBy { get; set; }
        public ProductDto Product { get; set; }
    }
}
