using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Author { get; set; }
        public string? Description { get; set; }
        public List<FilmRating> Ratings { get; set; } = new();
    }
}
