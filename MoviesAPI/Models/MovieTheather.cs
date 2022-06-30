using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class MovieTheather
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Name can't be empty.")]
        public string Name { get; set; }
        public virtual Address Address { get; set; }
        public int AddressId { get; set; }
    }
}
