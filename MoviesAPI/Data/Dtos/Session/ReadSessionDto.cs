using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos.Session
{
    public class ReadSessionDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public Models.MovieTheather Theather { get; set; }
        public Models.Movie Movie { get; set; }
        public DateTime EndingTime { get; set; }
        public DateTime StartTime { get; set; }
    }
}
