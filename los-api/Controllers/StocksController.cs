using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using los_api.Models;
using System.Collections;

namespace los_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly Los_apiDBContext _context;

        public StocksController(Los_apiDBContext context)
        {
            _context = context;
        }

        //CRUD  2.2 Stock table with following fields id, productId, amount
        // GET: api/Stocks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stock>>> GetStocks()
        {
            return await _context.Stocks.ToListAsync();
        }

        // GET: api/Stocks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stock>> GetStock(int id)
        {
            var stock = await _context.Stocks.FindAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return stock;
        }

        //3.Create a get stock api by specified productId as a parameter and get product detail and stock available as a result
        [Route("CheckStock/{id}")]
        [HttpGet]
        public async Task<IQueryable> GetCheckbyProduct(int id)
        {
            var product = _context.Products.ToList();
            var stock =  _context.Stocks.ToList();
            var checkstock = from prd in _context.Products
                             join stk in _context.Stocks
                             on prd.id equals stk.productId 
                             where prd.id == id
                             //from stk in ppp
                             select new 
                             { productId = prd.id, productName = prd.name, imageUrl = prd.imageUrl, stockId = stk.id , productPice = prd.price, stockAmount = stk.amount };
        
            return checkstock;
        }

        
        [HttpPost]
        public async Task<ActionResult<Stock>> PostStock(Stock stock)
        {
            var isStock = _context.Stocks.Find(stock.id);
            if (isStock != null)
            {
                isStock.productId = stock.productId;
                isStock.amount = stock.amount;

            }
            else
            {
                _context.Stocks.Add(stock);
            }
            
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStock", new { id = stock.id }, stock);
        }

        // DELETE: api/Stocks/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Stock>> DeleteStock(int id)
        {
            var stock = await _context.Stocks.FindAsync(id);
            if (stock == null)
            {
                return NotFound();
            }

            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();

            return stock;
        }

        private bool StockExists(int id)
        {
            return _context.Stocks.Any(e => e.id == id);
        }
    }
}
