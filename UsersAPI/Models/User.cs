using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
