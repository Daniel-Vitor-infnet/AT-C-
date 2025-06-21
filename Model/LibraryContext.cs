using Microsoft.EntityFrameworkCore;

namespace AT.Model
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext() { }

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        public DbSet<CreateCidade> Cidades { get; set; }
        public DbSet<CreateCliente> Cliente { get; set; }
        public DbSet<CreatePacotesTurisco> PacotesTuriscos { get; set; }
        public DbSet<CreatePaisDestino> PaisesDestino { get; set; }
        public DbSet<CreateReservas> Reservas { get; set; }


    }
}
