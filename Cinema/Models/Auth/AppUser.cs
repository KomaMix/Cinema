using Microsoft.AspNetCore.Identity;

namespace Cinema.Models.Auth
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
