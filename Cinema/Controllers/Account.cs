using Cinema.Models.DTO;
using Cinema.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Controllers
{
	public class Account : Controller
	{
		private readonly IUserAuthenticationService _service;

        public Account(IUserAuthenticationService service)
        {
            this._service = service;
        }

		public IActionResult Registration()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Registration(RegistrationModel model)
		{
			if (!ModelState.IsValid)
				return View(model);

			model.Role = "user";
			var result = await _service.RegistrationAsync(model);
			TempData["msg"] = result.Message;
			return RedirectToAction(nameof(Registration));
		}

        public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Login(LoginModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var result = await _service.LoginAsync(model);
			if (result.StatusCode == 1)
			{
				return RedirectToAction("Display", "Admin");
			} else
			{
				TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }

		}

		[Authorize]
		public async Task<IActionResult> Logout()
		{
			await _service.LogoutAsync();
			return RedirectToAction(nameof(Login));
		}


		public async Task<IActionResult> reg()
		{
			var model = new RegistrationModel
			{
				Username = "Timur",
				Name = "TimurAdmin",
				Email = "TimurShai228@gmail.com",
				// Придумай
				// Напиши на своем ноуте, придумай пароль и email
				//Password = "AdminQwerty123@#"
				Password = "sdfsjdfsjEH#$123",
			};

            model.Role = "admin";
            var result = await _service.RegistrationAsync(model);
			return Ok(result);
        }
	}
}
