using LibApp.Data;
using LibApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public async Task<ActionResult<Library>> PostTodoItem(Library item)
        {
            _dbContext.Libraries.Add(item);
            await _dbContext.SaveChangesAsync();
            return Ok(item);
        }
    }
}
