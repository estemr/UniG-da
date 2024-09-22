using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTS.Entity.DTOs.Market.Products;

namespace TTS.Entity.DTOs.Yorum
{
    public class CommentUpdateDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string CreatedBy { get; set; }
        public Guid ProductId { get; set; }
        public IList<ProductDto> Products { get; set; }
    }
}
