using System.ComponentModel.DataAnnotations;

namespace Cinema.ViewModels
{
	public class CreateModel
	{
		[Required] public string Name { get; set; }
		[Required] public string Email { get; set; }
		[Required] public int Age { get; set; }
		[Required] public string Password { get; set; }
	}
}
