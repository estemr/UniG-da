using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTS.Core.Entities;
using TTS.Entity.Entities.Identity;

namespace TTS.Entity.Entities.Market
{
    public class Sale : EntityBase
    {
        public Sale() { }

        public Sale(Guid productId, decimal productCount, DateTime saleDate, Guid userId)
        {
            ProductId = productId;
            ProductCount = productCount;
            SaleDate = saleDate;
            UserId = userId;
        }

        public Guid ProductId { get; set; }
        public Product Product { get; set; }

        public decimal ProductCount { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;

        public Guid UserId { get; set; }
        public AppUser User { get; set; }
    }
}
