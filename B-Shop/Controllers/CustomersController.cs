using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;
using Core.Domain.DomainModel;
using DataAccess.Repository;

namespace B_Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomersController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet]
        public IActionResult GetCustomerAsync()
        {
            var result = new ObjectResult(_customerRepository.GetCustomer())
            {
                StatusCode = (int)HttpStatusCode.OK
            };
            Request.HttpContext.Response.Headers.Add("Count", _customerRepository.CountCustomer().ToString());
            Request.HttpContext.Response.Headers.Add("CreatorApi", "Mr.Alireza");
            if (result.Value == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
   
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {
            if (await CustomerExists(id))
            {
                var customer = await _customerRepository.GetCustomer(id);
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }
        }

        private async Task<bool> CustomerExists(int customerId)
        {
            var result = await _customerRepository.CustomerExists(customerId);
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(customer);
            }
            await _customerRepository.PostCustomer(customer);
            return CreatedAtAction("GetCustomer", new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer([FromRoute] int id, [FromBody] Customer customer)
        {
            await _customerRepository.PutCustomer(id, customer);
            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            var customer = await _customerRepository.DeleteCustomer(id);
            return Ok();
        }
    }
}