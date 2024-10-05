using LibApp.Data;
using LibApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrariesController : ControllerBase
    {
        private readonly LibDBContext _dbContext;

        public LibrariesController(LibDBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Library>>> GetLibraries()
        {
            var libraries = await _dbContext.Libraries.ToListAsync();

            if (libraries == null)
            {
                return NotFound();
            }

            return libraries;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Library>> GetToDoItem(int id)
        {
            var library = await _dbContext.Libraries.FindAsync(id);

            if (library == null)
            {
                return NotFound();
            }
            return library;
        }

        [HttpPost]
        public async Task<ActionResult<Library>> PostTodoItem(Library item)
        {
            _dbContext.Libraries.Add(item);
            await _dbContext.SaveChangesAsync();
            return Ok(item);
        }
    }
}
