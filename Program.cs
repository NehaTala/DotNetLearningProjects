
using FirstCoreDemo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var settings = builder.Configuration.GetSection("ConnectionStrings");
builder.Services.AddDbContext<TestCoreContext>(
        options => options.UseSqlServer("name=ConnectionStrings:DemoDBConnection"));
//IServiceCollection serviceCollection = builder.Services.AddDbContextPool<TestCoreContext>(options => options.UseSqlServer(settings.GetConnectionString("DemoDBConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
