using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Data.Requests
{
    public class ForgetPasswordRequest
    {
        [Required]
        public string Email { get; set; }
    }
}
