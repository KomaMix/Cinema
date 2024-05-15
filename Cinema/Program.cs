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
//builder.Services.AddDbContext<UsersDbContext>(options =>
//options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));


// Добавление репозитория базы данных фильмов в сервисы приложения
builder.Services.AddTransient<IFilmRepository, EFFilmRepository>();

// Добавление базы данных пользователей в сервисы приложения
//builder.Services.AddIdentity<AppUser, IdentityRole>()
//    .AddEntityFrameworkStores<UsersDbContext>().AddDefaultTokenProviders();

//builder.Services.ConfigureApplicationCookie(op => op.LoginPath = "/Account/Login");

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
