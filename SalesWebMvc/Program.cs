using SalesWebMvc.Services;
using SalesWebMvc.Data;
using System.Globalization;
using System.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Localization;
using Humanizer.Configuration;
using System;




var builder = WebApplication.CreateBuilder(args); 


var connectionStringMysql = builder.Configuration.GetConnectionString("SalesWebMvcContext");
builder.Services.AddDbContext<SalesWebMvcContext>(options =>
options.UseMySql(connectionStringMysql, ServerVersion.Parse("8.1.0-mysql"),
 mySqlOptions => mySqlOptions.EnableRetryOnFailure()
));


// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<SeedingService>();
builder.Services.AddScoped<SellerService>();
builder.Services.AddScoped<DepartamentService>();
builder.Services.AddScoped<SalesRecordService>();

var app = builder.Build();

// Configurar localização
var enUS = new CultureInfo("en-US");
var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(enUS),
    SupportedCultures = new List<CultureInfo> { enUS },
    SupportedUICultures = new List<CultureInfo> { enUS }
};

app.UseRequestLocalization(localizationOptions);


// Inicializa o banco de dados com dados de seed
using (var scope = app.Services.CreateScope())
{
    var seedingService = scope.ServiceProvider.GetRequiredService<SeedingService>();
    seedingService.Seed();
}


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseDeveloperExceptionPage();


}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
