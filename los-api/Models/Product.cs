using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace los_api.Models
{
    public class Product
    {
        //id,name,imageUrl,price
        public int? id { get; set; }
        [Required]
        public string name { get; set; }

        public string imageUrl { get; set; }

        public decimal? price { get; set; }
    }
}
