using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalesWebMvc.Data;
using System.Configuration;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args); 


var connectionStringMysql = builder.Configuration.GetConnectionString("SalesWebMvcContext");
builder.Services.AddDbContext<SalesWebMvcContext>(options => options.UseMySql(connectionStringMysql, ServerVersion.Parse("8.1.0-mysql")));


// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
