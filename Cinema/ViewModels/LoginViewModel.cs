using System.ComponentModel.DataAnnotations;

namespace Cinema.ViewModels
{
	public class LoginViewModel
	{
		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Display(Name = "Помнишь пароль?")]
		public bool RememberMe { get; set; }
	}
}
