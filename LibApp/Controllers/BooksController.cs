using LibApp.Data;
using LibApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
 

namespace LibApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly LibDBContext _dbContext;

        public BooksController(LibDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetBooks()
        {
            var books = await _dbContext.Books.ToListAsync();

            if (books == null)
            {
                return NotFound();
            }

            return books;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetTodoItem(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return book;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostTodoItem(Book item)
        {
            _dbContext.Books.Add(item);
            await _dbContext.SaveChangesAsync();
            return Ok(item);
        }
    }
}
