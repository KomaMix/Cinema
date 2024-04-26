using Cinema.Models;
using Cinema.Models.Auth;
using Cinema.Repositories.Abstract;
using Cinema.Repositories.Implementation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


// ��������� ���� ������ ������� � �������� ��� ����������
builder.Services.AddDbContext<ApplicationContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ��������� ���� ������ ������������� � �������� ��� ����������
builder.Services.AddDbContext<UsersDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection")));


// ���������� ����������� ���� ������ ������� � ������� ����������
builder.Services.AddTransient<IFilmRepository, EFFilmRepository>();

// ���������� ���� ������ ������������� � ������� ����������
builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<UsersDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(op => op.LoginPath = "/Account/Login");

builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationService>();

var app = builder.Build();
SeedData.FillingMovies(app);


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
