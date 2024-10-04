using LibApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibApp.Configurations
{
    public class LibraryConfig : IEntityTypeConfiguration<Library>
    {
        public void Configure(EntityTypeBuilder<Library> builder)
        {
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.Address).IsRequired();
        }
    }
}
