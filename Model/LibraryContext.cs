using AT.Model;
using Microsoft.EntityFrameworkCore;

namespace AT.Model
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options) { }

        public DbSet<CreatePaisDestino> PaisDestinos { get; set; }
        public DbSet<CreateCidade> Cidades { get; set; }
        public DbSet<CreatePacotesTurisco> PacotesTuristicos { get; set; }
        public DbSet<CreateReservas> Reservas { get; set; }

        public DbSet<CreateCliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1) País → Cidades (1:N)
            modelBuilder.Entity<CreatePaisDestino>()
                .HasMany(p => p.Cidades)
                .WithOne(c => c.PaisDestino)
                .HasForeignKey(c => c.PaisDestinoId);

            // 2) PacoteTurístico → País (N:1)
            modelBuilder.Entity<CreatePacotesTurisco>()
                .HasOne(pt => pt.PaisDestino)
                .WithMany(p => p.PacotesTuristicos)
                .HasForeignKey(pt => pt.PaisDestinoId);

            // 3) PacoteTurístico → Cidade (N:1)
            modelBuilder.Entity<CreatePacotesTurisco>()
                .HasOne(pt => pt.Cidade)
                .WithMany(c => c.PacotesTuristicos)
                .HasForeignKey(pt => pt.CidadeId);

            // 4) PacoteTurístico → Reservas (1:N)
            modelBuilder.Entity<CreatePacotesTurisco>()
                .HasMany(pt => pt.Reservas)
                .WithOne(r => r.PacoteTuristico)
                .HasForeignKey(r => r.PacoteTuristicoId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
