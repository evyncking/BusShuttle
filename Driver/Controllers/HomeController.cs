using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Driver.Models;

namespace Driver.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly List<string> _drivers = new List<string> { "Evyn K" };

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.LoopOptions = new List<string> { "Blue", "Orange", "Green" };
        ViewBag.BusNumbers = new List<string> { "1", "2", "3" };
        ViewBag.Drivers = _drivers;
        return View();
    }

    [HttpPost]
    public IActionResult Index(string loop, string bus, List<string> stops)
    {
        Console.WriteLine($"Selected loop: {loop}");
        Console.WriteLine($"Selected bus: {bus}");
        Console.WriteLine("Selected stops:");
        foreach (var stop in stops)
        {
            Console.WriteLine(stop);
        }

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
