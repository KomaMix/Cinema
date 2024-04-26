using Cinema.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
	[Authorize(Roles = "admin")]
	public class AdminController : Controller
    {
        public IActionResult Display()
        {
            return View();
        }

        
    }
}
