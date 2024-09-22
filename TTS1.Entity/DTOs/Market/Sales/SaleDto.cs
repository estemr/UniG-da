using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TTS.Entity.DTOs.Market.Products;

namespace TTS.Entity.DTOs.Market.Sales
{
    public class SaleDto
    {
        public Guid Id { get; set; }
        public decimal ProductCount { get; set; }
        public DateTime SaleDate { get; set; } = DateTime.Now;
        public ProductDto Product { get; set; }
    }
}
