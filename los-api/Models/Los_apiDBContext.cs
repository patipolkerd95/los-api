using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace los_api.Models
{
    public class Los_apiDBContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public Los_apiDBContext(DbContextOptions<Los_apiDBContext> options) : base(options)
        {

        }
    }
}
