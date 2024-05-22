using Cinema.Models.DbContexts;

namespace Cinema.Models.Repositories
{
    public class EFFilmRepository : IFilmRepository
    {
        private FilmDbContext context;
        public EFFilmRepository(FilmDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Film> Films => context.Films;
    }
}
