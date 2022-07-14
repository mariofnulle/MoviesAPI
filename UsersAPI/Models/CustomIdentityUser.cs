using Microsoft.AspNetCore.Identity;
using System;

namespace UsersAPI.Models
{
    public class CustomIdentityUser : IdentityUser<int>
    {
        public DateTime BirthDate { get; set; }
    }
}
