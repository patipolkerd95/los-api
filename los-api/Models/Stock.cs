using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace los_api.Models
{
    public class Stock
    {
        public int? id { get; set; } //id,productId,amount
        [Required]
        public int? productId { get; set; }

        public decimal? amount { get; set; }
    }
}
