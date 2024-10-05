using LibApp.Data;
using LibApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly LibDBContext _dbContext;

        public CustomersController(LibDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> PostToDoItem(Customer item )
        {
            _dbContext.Customers.Add(item);
            await _dbContext.SaveChangesAsync();
            return Ok(item);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetToDoItem(int id)
        {
            var customer = await _dbContext.Customers.FindAsync(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }
    }
}
