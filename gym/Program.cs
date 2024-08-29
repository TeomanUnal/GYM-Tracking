using gym.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
AddCookie(option =>
{
    option.LoginPath = "/Startp/Login";
    option.ExpireTimeSpan = TimeSpan.FromMinutes(20);
});//2.adým
builder.Services.AddDbContext<gymContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("constring")));
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

app.UseRouting();
app.UseAuthentication();//3.adým
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Startp}/{action=Login}/{id?}");//4.adým
app.Run();
