using Microsoft.EntityFrameworkCore;
using MVCPanierManager.Models;

namespace MVCPanierManager.Repository
{
    public class PanierContext : DbContext
    {
        public PanierContext(DbContextOptions<PanierContext> options ) : base(options) 
        {

        }
        public DbSet<Panier> Paniers { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Historique> Historiques { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Panier>()
                .HasMany(e => e.Articles)
                .WithMany(e => e.Paniers);
        }
    }
}




