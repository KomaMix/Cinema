using System.ComponentModel.DataAnnotations;
using Cinema.Models.Repositories;

namespace Cinema.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Director { get; set; }
        public string? Description { get; set; }
        public List<FilmRating> Ratings { get; set; } = new();
    }
}
