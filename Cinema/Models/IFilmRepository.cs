namespace Cinema.Models
{
    public interface IFilmRepository
    {
        IQueryable<Film> Films { get; }
    }
}
