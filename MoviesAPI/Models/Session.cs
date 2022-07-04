using System;
using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Session
    {
        [Key]
        [Required]
        public int Id { get;set; }
        public virtual MovieTheather Theather { get; set; }
        public virtual Movie Movie { get; set; }
        public int TheatherId { get; set; }
        public int MovieId { get; set; }
        public DateTime EndingTime { get; set; }
    }
}
