namespace Cinema.Models
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
