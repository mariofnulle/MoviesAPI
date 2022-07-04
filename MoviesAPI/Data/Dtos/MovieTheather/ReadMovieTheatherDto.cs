using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos.MovieTheather
{
    public class ReadMovieTheatherDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name can't be empty.")]
        public string Name { get; set; }
        public object Address { get; set; }
        public Models.Manager Manager { get; set; }
    }
}
