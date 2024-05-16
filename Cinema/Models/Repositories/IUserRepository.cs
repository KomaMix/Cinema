using Microsoft.AspNetCore.Identity;
using System.Linq;

namespace Cinema.Models.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> GetAllUsersAsync();
        IEnumerable<IdentityRole> GetAllRolesAsync();
    }
}
