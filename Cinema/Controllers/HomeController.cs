using Cinema.Models.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Cinema.Controllers
{
    public class HomeController : Controller
    {

        private IFilmRepository repository;


        public HomeController(IFilmRepository repository)
        {
            this.repository = repository;
        }

		[Authorize]
		public IActionResult Index()
        {
            return View();
        }
        public IActionResult Films()
        {
            return View(repository.Films.Include(f => f.Ratings).ToList());
        }
    }
}