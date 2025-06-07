using globalsolution.Models;
using Microsoft.EntityFrameworkCore;

namespace globalsolution.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Tabelas
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<PedidoAjuda> PedidosAjuda { get; set; }
        public DbSet<Abrigo> Abrigos { get; set; }
        public DbSet<UsuarioAbrigado> UsuariosAbrigados { get; set; }
        public DbSet<Relato> Relatos { get; set; }
        public DbSet<Voluntario> Voluntarios { get; set; }
        public DbSet<Doacao> Doacoes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Email)
                .IsUnique();

            modelBuilder.Entity<Voluntario>()
                .HasIndex(v => v.IdUsuario)
                .IsUnique();

            modelBuilder.Entity<PedidoAjuda>()
                .Property(p => p.Latitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<PedidoAjuda>()
                .Property(p => p.Longitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<Relato>()
                .Property(r => r.Latitude)
                .HasPrecision(9, 6);

            modelBuilder.Entity<Relato>()
                .Property(r => r.Longitude)
                .HasPrecision(9, 6);
        }
    }
}
