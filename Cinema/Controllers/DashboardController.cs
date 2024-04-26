using Cinema.Models.Auth;
using Cinema.Repositories.Abstract;
using Cinema.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{

    [Authorize]
    public class DashboardController : Controller
    {
		private readonly IUserAuthenticationService _service;

        public DashboardController(IUserAuthenticationService service)
        {
            this._service = service;
        }

        public async Task<IActionResult> Display()
        {
            return View();
        }
    }
}
