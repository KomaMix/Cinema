using Cinema.Models.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Models.DbContexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmRating> FilmRatings { get; set; }

    }
}
