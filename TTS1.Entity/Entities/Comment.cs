using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTS.Core.Entities;
using TTS.Entity.Entities.Market;

namespace TTS.Entity.Entities
{
    public class Comment : EntityBase
    {
        public Comment() { }
        public Comment(string title, string content, Guid productId, string createdBy) 
        {
            Title = title;
            Content = content;
            ProductId = productId;
            CreatedBy = createdBy;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
