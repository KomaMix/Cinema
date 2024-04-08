using Cinema.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// ��������� ���� ������ ������� � �������� ��� ����������
builder.Services.AddDbContext<ApplicationContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ��������� ���� ������ ������������� � �������� ��� ����������
builder.Services.AddDbContext<IdentityContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));


// ���������� ����������� ���� ������ ������� � ������� ����������
builder.Services.AddTransient<IFilmRepository, EFFilmRepository>();

// ���������� ���� ������ ������������� � ������� ����������
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
