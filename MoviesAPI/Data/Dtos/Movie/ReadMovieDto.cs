using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos.Movie
{
    public class ReadMovieDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Director is required.")]
        public string Director { get; set; }
        [StringLength(30, ErrorMessage = "Gender can't be longer than 30 characters.")]
        public string Gender { get; set; }
        [Range(1, 600, ErrorMessage = "Minimum duration is 1 minute and maximum duration is 600 minutes.")]
        public int Duration { get; set; }
        public DateTime LookupDate { get; set; }
    }
}
