using Cinema.Models.DbContexts;

namespace Cinema.Models.Repositories
{
    public class EFFilmRepository : IFilmRepository
    {
        private ApplicationContext context;
        public EFFilmRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public IQueryable<Film> Films => context.Films;
    }
}
