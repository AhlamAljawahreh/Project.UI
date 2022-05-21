using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.DataModels;
using Microsoft.AspNetCore.Authorization;

namespace Project.Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyDBContext _context;

        public ProductsController(MyDBContext context)
        {
            _context = context;
        }
        //get all products
        // GET: api/Products

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
         
            return await _context.Products.ToListAsync();
        }


        //get one product by id 
        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // edit product by id 
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id,Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //create new product 
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }

        //delete one product by id
        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        private bool UserExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
