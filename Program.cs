using System.Configuration;
using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebMvc.Data;
using SalesWebMVC.Data;
using SalesWebMVC.Services;

var builder = WebApplication.CreateBuilder(args);
var connString = (builder.Configuration.GetConnectionString("SalesWebMVCContext"));
builder.Services.AddDbContext<SalesWebMVCContext>(options =>
options.UseMySql(connString, ServerVersion.AutoDetect(connString),
builder => builder.MigrationsAssembly("SalesWebMVC")));

builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartmentService>();

//Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

void Configure(SeedingService seedingService)
{

    if (app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");

        app.UseHsts();

        seedingService.Seed();
    }
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
