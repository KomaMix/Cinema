using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Models.DbContexts
{
	public class UsersDbContext : IdentityDbContext<ApplicationUser>
	{
		public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options)
		{

		}
	}

}
