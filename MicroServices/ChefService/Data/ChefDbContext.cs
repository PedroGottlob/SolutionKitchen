using Microsoft.EntityFrameworkCore;
using ChefService.Models;

namespace ChefService.Data
{
    public class ChefDbContext : DbContext
    {
        public ChefDbContext(DbContextOptions<ChefDbContext> options) : base(options) {}

        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Prato> Pratos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações do modelo Pedido
            modelBuilder.Entity<Pedido>()
                .HasKey(p => p.Id);

            // Configurações do modelo Prato
            modelBuilder.Entity<Prato>()
                .HasKey(p => p.Id);
        }
    }
}
