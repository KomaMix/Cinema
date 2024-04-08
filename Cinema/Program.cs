using Cinema.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// Установка базы данных фильмов в сервисах для приложения
builder.Services.AddDbContext<ApplicationContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Установка базы данных пользователей в сервисах для приложения
builder.Services.AddDbContext<IdentityContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));


// Добавление репозитория базы данных фильмов в сервисы приложения
builder.Services.AddTransient<IFilmRepository, EFFilmRepository>();

// Добавление базы данных пользователей в сервисы приложения
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();


var app = builder.Build();
SeedData.FillingMovies(app);


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
