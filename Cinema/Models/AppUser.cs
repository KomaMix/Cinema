using Microsoft.AspNetCore.Identity;

namespace Cinema.Models
{
    public class AppUser : IdentityUser
    {
        public int Age { get; set; }
    }
}
