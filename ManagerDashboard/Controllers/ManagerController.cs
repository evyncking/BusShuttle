using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ManagerDashboard.Models;

namespace ManagerDashboard.Controllers
{
    public class ManagerController : Controller
    {
        private readonly ILogger<ManagerController> _logger;

        public ManagerController(ILogger<ManagerController> logger)
        {
            _logger = logger;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("~/Views/Home/Login.cshtml");
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Check username and password info
                if (model.Username == "bus" && model.Password == "shuttle")
                {
                    // Redirect to the Index action of the Manager controller
                    return RedirectToAction("Index", "Manager");
                }
                else
                {
                    // Error message
                    ModelState.AddModelError(string.Empty, "Invalid username or password");
                    return View("Login", model);
                }
            }
            else
            {
                // Model is not valid, return the login view with errors
                return View("Login", model);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
