using Cinema.Models.Auth;
using Cinema.Models.DTO;
using Microsoft.AspNetCore.Identity;
using System.Collections.ObjectModel;

namespace Cinema.Repositories.Abstract
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(LoginModel model);
        Task<Status> RegistrationAsync(RegistrationModel model);
        Task LogoutAsync();
        public UserManager<AppUser> GetUserManager();

	}
}
