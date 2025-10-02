using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Storeii.Data;
using Storeii.Services;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(); // Enables MVC

// Setup MySQL connection with EFCore
builder.Services.AddDbContext<StoreiiContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection")!,
        new MySqlServerVersion(new Version(8, 0, 28)) // Use your actual MySQL version
    ));

// Register services
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddSession();  // Add session service for Cart contents so we don't need to store it in the database

var app = builder.Build();






// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();  // Tell browsers to always use HTTPS, never downgrade to HTTP
}

app.UseHttpsRedirection();  // redirects HTTP -> HTTPS
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.UseSession();               // required for Cart contents.

// Defaut MVC route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


// allow for "Slugs" in the Product URLs
app.MapControllerRoute(
    name: "product",
    pattern: "products/{id}/{slug?}",
    defaults: new { controller = "Products", action = "Details" });

// start
app.Run();