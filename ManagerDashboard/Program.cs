using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ManagerDashboard.Models;
using Microsoft.EntityFrameworkCore;
using ManagerDashboard.Models;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

// Register List<DriverModel>, List<BusModel>, and Manager as services
builder.Services.AddSingleton<List<DriverModel>>();
builder.Services.AddSingleton<List<BusModel>>();
builder.Services.AddSingleton<List<LoopModel>>();
builder.Services.AddSingleton<List<StopModel>>();
builder.Services.AddSingleton<List<RouteModel>>();
builder.Services.AddTransient<Manager>();

// Set up configuration
var configuration = builder.Configuration;

builder.Services.AddDbContext<BusShuttleContext>(options =>
    options.UseSqlite(configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Driver/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Manager}/{action=Login}/{id?}");

app.Run();
