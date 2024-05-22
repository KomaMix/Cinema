using Microsoft.AspNetCore.Identity;

namespace Cinema.Models.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;



        public UserRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IEnumerable<ApplicationUser> GetAllUsersAsync()
        {
            return _userManager.Users.ToList();
        }

        public IEnumerable<IdentityRole> GetAllRolesAsync()
        {
            return _roleManager.Roles.ToList();
        }
    }
}
