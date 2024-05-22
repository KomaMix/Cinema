using System.ComponentModel.DataAnnotations;

namespace Cinema.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Director { get; set; }
        public string? Description { get; set; }
        public string Url { get; set; } = string.Empty;
        public List<FilmRating> Ratings { get; set; } = new();
    }
}
