using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace los_api.Models
{
    public class CheckStockModelView
    {
        public int? productId { get; set; }
        public string productName { get; set; }
        public string imageUrl { get; set; }
        public int? stockId { get; set; }
        public decimal? productPice { get; set; }
        public decimal? stockAmount{ get; set; }
    }
}
