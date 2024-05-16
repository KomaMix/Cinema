using Cinema.Models;
using Cinema.Models.DbContexts;
using Cinema.Models.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Установка базы данных фильмов в сервисах для приложения
builder.Services.AddDbContext<FilmDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Установка базы данных пользователей в сервисах для приложения
builder.Services.AddDbContext<UsersDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
});


// Добавление репозитория базы данных фильмов в сервисы приложения
builder.Services.AddScoped<IFilmRepository, EFFilmRepository>();

// Добавление репозитория базы данных пользователей в сервисы приложения
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Добавление базы данных пользователей в сервисы приложения
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<UsersDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(op =>
{
    op.LoginPath = "/Account/Login";
});

builder.Services.Configure<IdentityOptions>(options =>
{
    // Можно настроить пароль
    //options.Password.RequireDigit = true;

    // Можно настроить блокировку пользователя
    //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

    // Можно настроить пользователей
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
