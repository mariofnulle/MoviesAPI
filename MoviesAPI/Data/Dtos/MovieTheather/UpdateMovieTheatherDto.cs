using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos.MovieTheather
{
    public class UpdateMovieTheatherDto
    {
        [Required(ErrorMessage = "Name can't be empty.")]
        public string Name { get; set; }
    }
}
