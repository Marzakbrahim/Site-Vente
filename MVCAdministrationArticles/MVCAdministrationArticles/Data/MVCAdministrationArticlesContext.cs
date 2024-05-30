using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MVCAdministrationArticles.Models;

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
