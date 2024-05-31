using Microsoft.EntityFrameworkCore;
using Vente.Models;

namespace Vente.Data
{
    public class VenteContext : DbContext
    {
        public VenteContext (DbContextOptions<VenteContext> options)
            : base(options)
        {
        }

        public DbSet<Panier> Panier { get; set; }

        public DbSet<Article> Article { get; set; }

        public DbSet<Historique> Historique { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Panier>()
                .HasMany(e => e.Articles)
                .WithMany(e => e.Paniers);
        }
    }
}
