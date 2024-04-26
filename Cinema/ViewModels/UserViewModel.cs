using Cinema.Models.Auth;

namespace Cinema.ViewModels
{
	public class UserViewModel
	{
		public AppUser user { get; set; }
		public List<string> roles { get; set; }
	}
}
