﻿using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos.MovieTheather
{
    public class CreateMovieTheatherDto
    {
        [Required(ErrorMessage = "Name can't be empty.")]
        public string Name { get; set; }
        public int AddressId { get; set; }
        public int ManagerId { get; set; }
    }
}
