using Cinema.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ���������� ����������� ���� ������ � ������� ����������
builder.Services.AddTransient<IFilmRepository, EFFilmRepository>();

// ��������� ������ ����������� � ���� ������
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// ��������� �������� ���� ������
var options = new DbContextOptionsBuilder<ApplicationContext>().UseSqlServer(connectionString).Options;

// ��������� ���� ������ � �������� ��� ����������
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
