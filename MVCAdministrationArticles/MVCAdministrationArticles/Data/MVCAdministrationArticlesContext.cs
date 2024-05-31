using Microsoft.EntityFrameworkCore;

namespace MVCAdministrationArticles.Data
{
    public class MVCAdministrationArticlesContext : DbContext
    {
        public MVCAdministrationArticlesContext (DbContextOptions<MVCAdministrationArticlesContext> options)
            : base(options)
        {
        }

        public DbSet<MVCAdministrationArticles.Models.Article> Article { get; set; } = default!;
    }
}
