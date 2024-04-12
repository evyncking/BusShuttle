using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ManagerDashboard.Models;

namespace ManagerDashboard.Controllers
{
    public class ManagerDashboardController : Controller
    {
        private readonly List<DriverModel> _drivers;
        private readonly Manager _manager;

        public ManagerDashboardController(List<DriverModel> drivers, Manager manager)
        {
            _drivers = drivers;
            _manager = manager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml", _drivers);
        }

        [HttpGet]
        public IActionResult AddDriver()
        {
            return View("~/Views/Home/AddDriver.cshtml");
        }

        [HttpPost]
        public IActionResult AddDriver(DriverViewModel model)
        {
            if (ModelState.IsValid)
            {
                var driver = new DriverModel
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Username = model.Username,
                    Password = model.Password,
                    IsActive = false
                };
                _drivers.Add(driver);
                return RedirectToAction("Index", "ManagerDashboard");
            }
            else
            {
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult ActivateDriver(int id)
        {
            var driver = _drivers.FirstOrDefault(d => d.Id == id);
            if (driver != null)
            {
                driver.IsActive = true;
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult DeactivateDriver(int id)
        {
            var driver = _drivers.FirstOrDefault(d => d.Id == id);
            if (driver != null)
            {
                driver.IsActive = false;
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult ListDrivers()
        {
            return View(_drivers);
        }

        [HttpGet]
        public IActionResult ListDriversToActivate()
        {
            var driversToActivate = _drivers.Where(d => !d.IsActive).ToList();
            return View(driversToActivate);
        }

        [HttpGet]
        public IActionResult ListActiveDrivers()
        {
            var activeDrivers = _drivers.Where(d => d.IsActive).ToList();
            return View(activeDrivers);
        }

    //     [HttpGet]
    //     public IActionResult EditDriver(int id)
    //     {
    //         var driver = _drivers.FirstOrDefault(d => d.Id == id);
    //         if (driver == null)
    //         {
    //             return NotFound();
    //         }

    //         var model = new DriverViewModel
    //         {
    //             Id = driver.Id,
    //             FirstName = driver.FirstName,
    //             LastName = driver.LastName,
    //             Username = driver.Username,
    //             Password = driver.Password
    //         };

    //         return View(model);
    //     }

    //     [HttpPost]
    //     public IActionResult EditDriver(DriverViewModel model)
    //     {
    //         if (ModelState.IsValid)
    //         {
    //             var driver = _drivers.FirstOrDefault(d => d.Id == model.Id);
    //             if (driver == null)
    //             {
    //                 return NotFound();
    //             }

    //             // Update driver details
    //             driver.FirstName = model.FirstName;
    //             driver.LastName = model.LastName;
    //             driver.Username = model.Username;
    //             driver.Password = model.Password;

    //             return RedirectToAction("Index");
    //         }
    //         return View(model);
    //     }

    //     [HttpPost]
    //     public IActionResult DeleteDriver(int id)
    //     {
    //         var driver = _drivers.FirstOrDefault(d => d.Id == id);
    //         if (driver != null)
    //         {
    //             _drivers.Remove(driver);
    //         }

    //         return RedirectToAction("Index");
    //     }



     }
}
