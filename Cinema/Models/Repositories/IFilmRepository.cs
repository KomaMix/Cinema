namespace Cinema.Models.Repositories
{
    public interface IFilmRepository
    {
        IQueryable<Film> Films { get; }
    }
}
