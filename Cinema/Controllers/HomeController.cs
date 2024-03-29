using Cinema.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            return View(repository.Films);
        }
    }
}
