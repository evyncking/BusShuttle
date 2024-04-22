using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ManagerDashboard.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register List<DriverModel>, List<BusModel> and Manager as services
builder.Services.AddSingleton<List<DriverModel>>();
builder.Services.AddSingleton<List<BusModel>>();
builder.Services.AddSingleton<List<LoopModel>>();
builder.Services.AddSingleton<List<StopModel>>();
builder.Services.AddTransient<Manager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Driver/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
