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
    public class OrdersController : ControllerBase
    {
        private readonly MyDBContext _context;

        public OrdersController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/Products

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrderss()
        {
            return await _context.Orders.ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }
        [HttpGet("myorder/{id}")]
        public async Task<ActionResult<IEnumerable<Product>>> GetMyOrder(int id)
        {
            var order = await _context.Products.Where(t => t.OrderId == id).ToListAsync();

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.OrderId)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

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


        [HttpPost]
        public async Task<ActionResult<Order>> PostProduct(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteProduct(int id)
        {

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }

        private bool UserExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}

