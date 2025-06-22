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
        public DbSet<CreateCliente> Clientes { get; set; }
        public DbSet<CreateReservas> Reservas { get; set; }

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

            // 3) PacoteTurístico ↔ Cidades (N:N)
            modelBuilder.Entity<CreatePacotesTurisco>()
                .HasMany(pt => pt.Cidades)
                .WithMany(c => c.PacotesTuristicos)
                .UsingEntity<Dictionary<string, object>>(   
                    "PacoteCidade",
                    pc => pc
                        .HasOne<CreateCidade>()
                        .WithMany()
                        .HasForeignKey("CidadeId"),
                    pc => pc
                        .HasOne<CreatePacotesTurisco>()
                        .WithMany()
                        .HasForeignKey("PacoteTuriscoId")
                );

            // 4) Cliente → Reservas (1:N)
            modelBuilder.Entity<CreateCliente>()
                .HasMany(c => c.Reservas)
                .WithOne(r => r.Cliente)
                .HasForeignKey(r => r.ClienteId);

            // 5) PacoteTurístico → Reservas (1:N)
            modelBuilder.Entity<CreatePacotesTurisco>()
                .HasMany(pt => pt.Reservas)
                .WithOne(r => r.PacoteTuristico)
                .HasForeignKey(r => r.PacoteTuristicoId);
        }
    }
}
