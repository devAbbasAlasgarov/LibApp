using LibApp.Configurations;
using Microsoft.EntityFrameworkCore;

namespace LibApp.Models
{
    [EntityTypeConfiguration(typeof(LibraryConfig))]
    public class Library
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Employee { get; set; }
        public string Address { get; set; }

    }
}
