using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using QLNS.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<QuanlynhansuDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("QLNSConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
 .AddCookie(options =>
 {
     options.Cookie.Name = "QLNS.Cookie";
     options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
     options.SlidingExpiration = true;
     options.LoginPath = "/Home/Login";
     options.LogoutPath = "/Home/Logout";
     options.AccessDeniedPath = "/Home/Forbidden";
 });
builder.Services.AddHttpContextAccessor();


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    options.Cookie.Name = "QLNS.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(15);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
/*app.MapControllerRoute(name: "adminareas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");*/

app.MapAreaControllerRoute(
    name: "adminareas",
    areaName: "admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
app.MapAreaControllerRoute(
    name: "qltareas",
    areaName: "quanly",
    pattern: "QuanLy/{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();
