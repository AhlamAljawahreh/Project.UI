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


        //to get all Orders
        // GET: api/Orders

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrderss()
        {
            return await _context.Orders.ToListAsync();
        }

        //to get one order using id
        // GET: api/Orders/5
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

        //to get all products in one order
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
        //to edit order by id
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


        //to create new order 
        [HttpPost]
        public async Task<ActionResult<Order>> PostProduct(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.OrderId }, order);
        }

        //to delete order by ad 
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteProduct(int id)
        {

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            var products = await _context.Products.Where(t => t.OrderId == id).ToListAsync();
            //delete all products have the order id as FK to delete order .
            foreach (var item in products)
            {
                _context.Products.Remove(item);

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

