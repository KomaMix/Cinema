using Microsoft.EntityFrameworkCore;

namespace Cinema.Models
{
    public class ApplicationContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmRating> FilmRatings { get; set; }

    }
}
