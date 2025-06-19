using Microsoft.EntityFrameworkCore;

namespace AT.Model
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext() { }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<CreateCliente> Cliente { get; set; }
    }
}
