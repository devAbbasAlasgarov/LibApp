using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using LibApp.Configurations;
namespace LibApp.Model
{
    [EntityTypeConfiguration(typeof(BookConfig))]
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishDate { get; set; }
        public string ISSN { get; set; } = null!;
        public int PageCount { get; set; }

    }
}