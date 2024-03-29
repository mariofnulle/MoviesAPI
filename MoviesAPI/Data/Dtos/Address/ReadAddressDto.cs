﻿using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Data.Dtos.Address
{
    public class ReadAddressDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string AddressName { get; set; }
        public string Neighborhood { get; set; }
        public int Number { get; set; }
        public Models.MovieTheather MovieTheather { get; set; }
    }
}
