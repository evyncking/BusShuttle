using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Driver.Models;

namespace Driver.Controllers
{
    public class HomeController : Controller
    {
        private readonly DriverDbContext _context;

        public HomeController(DriverDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Check username and password against database
            if (IsValidUser(username, password))
            {
                return RedirectToAction("SelectionForm");
            }
            else
            {
                // Handle invalid login
                return View();
            }
        }

        public IActionResult SelectionForm()
        {
            var viewModel = new SelectionFormViewModel
            {
                BusNumbers = _context.BusNumbers.Select(b => new SelectListItem { Value = b.Id.ToString(), Text = b.Number }).ToList(),
                FirstNames = _context.Names.Select(n => new SelectListItem { Value = n.Id.ToString(), Text = n.FullName }).ToList(),
                LoopNames = _context.Loops.Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.LoopName }).ToList()
            };

            return View(viewModel);
        }

        private bool IsValidUser(string username, string password)
        {
            // Implement logic to validate username and password
        
            return true;
        }
    }
}
