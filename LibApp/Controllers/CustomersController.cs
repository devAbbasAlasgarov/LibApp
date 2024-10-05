using LibApp.Data;
using LibApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetCustomers()
        {
            var customers = await _dbContext.Customers.ToListAsync();

            if (customers == null)
            {
                return NotFound();
            }

            return customers;
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

        [HttpPost]
        public async Task<ActionResult<Customer>> PostToDoItem(Customer item)
        {
            _dbContext.Customers.Add(item);
            await _dbContext.SaveChangesAsync();
            return Ok(item);
        }
    }
}
