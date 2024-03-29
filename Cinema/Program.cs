using Cinema.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ƒобавление репозитори€ базы данных в сервисы приложени€
builder.Services.AddTransient<IFilmRepository, EFFilmRepository>();

// ѕолучение строки подключени€ к базе данных
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// ѕолучение настроек базы данных
var options = new DbContextOptionsBuilder<ApplicationContext>().UseSqlServer(connectionString).Options;

// ”становка базы данных в сервисах дл€ приложени€
builder.Services.AddDbContext<ApplicationContext>(options =>
options.UseSqlServer(connectionString));


var app = builder.Build();



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
