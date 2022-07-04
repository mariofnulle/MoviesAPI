using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MoviesAPI.Models
{
    public class Movie
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required (ErrorMessage ="Title is required.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Director is required.")]
        public string Director { get; set; }
        [StringLength(30, ErrorMessage ="Gender can't be longer than 30 characters.")]
        public string Gender { get; set; }
        [Range(1, 600, ErrorMessage ="Minimum duration is 1 minute and maximum duration is 600 minutes.")]
        public int Duration { get; set; }
        public Rate MovieRate { get; set; }
        [JsonIgnore]
        public virtual List<Session> Sessions { get; set; }

    }

    public enum Rate
    {
        None,
        G,
        PG,
        PG_13,
        R,
        NC_17
    }
}
