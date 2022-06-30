using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace MoviesAPI.Models
{
    public class Address
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public string AddressName { get; set; }
        public string Neighborhood { get; set; }
        public int Number { get; set; }
        [JsonIgnore]
        public virtual MovieTheather MovieTheather { get; set; }

    }
}
