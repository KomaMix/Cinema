using Cinema.Models;
using Cinema.Models.DbContexts;
using Cinema.Models.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// ”становка базы данных фильмов в сервисах дл€ приложени€
builder.Services.AddDbContext<FilmDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ”становка базы данных пользователей в сервисах дл€ приложени€
builder.Services.AddDbContext<UsersDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
});


// ƒобавление репозитори€ базы данных фильмов в сервисы приложени€
builder.Services.AddTransient<IFilmRepository, EFFilmRepository>();

// ƒобавление базы данных пользователей в сервисы приложени€
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<UsersDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(op =>
{
    op.LoginPath = "/Account/Login";
});

builder.Services.Configure<IdentityOptions>(options =>
{
    // ћожно настроить пароль
    //options.Password.RequireDigit = true;

    // ћожно настроить блокировку пользовател€
    //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

    // ћожно настроить пользователей
    //options.User.RequireUniqueEmail = true;
});

//builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();

var app = builder.Build();
//SeedData.FillingMovies(app);


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Films}/{id?}");

app.Run();
