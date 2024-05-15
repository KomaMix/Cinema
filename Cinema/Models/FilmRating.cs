namespace Cinema.Models
{
    public class FilmRating
    {
        public int Id { get; set; }
        public int FilmId { get; set; }
        public int Rating { get; set; }
        public Film? Film { get; set; }

    }
}
