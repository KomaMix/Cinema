using Microsoft.EntityFrameworkCore;

namespace Cinema.Models.DbContexts
{
    public class FilmDbContext : DbContext
    {
        public FilmDbContext(DbContextOptions<FilmDbContext> options)
            : base(options) { }
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmRating> FilmRatings { get; set; }

    }
}
