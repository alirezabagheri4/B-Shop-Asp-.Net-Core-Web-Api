using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Model;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace B_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ShopContext _context;
        public CustomersController(ShopContext context) => _context = context;

        [HttpGet]
        public IActionResult GetCustomer()
        {
            Request.HttpContext.Response.Headers.Add("Count", _context.Customer.Count().ToString());
            Request.HttpContext.Response.Headers.Add("CreatorApi", "Mr.Alireza");
            var result = new ObjectResult(_context.Customer)
            {
                StatusCode = (int)HttpStatusCode.OK
            };
            if (result.Value == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {
            if (CustomerExists(id))
            {
                var customer = await _context.Customer.SingleOrDefaultAsync(c => c.Id == id);
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }
        }

        private bool CustomerExists(int customerId)
        {
            var result = _context.Customer.Any(x => x.Id == customerId);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(customer);
            }
            _context.Customer.Add(customer);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer([FromRoute] int id, [FromBody] Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
