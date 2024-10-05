using LibApp.Model;
using LibApp.Models;
using Microsoft.EntityFrameworkCore;

namespace LibApp.Data
{
    public class LibDBContext:DbContext
    {
        public LibDBContext(DbContextOptions<LibDBContext> options) : base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<Customer> Customers { get; set; }
        
    }
}
