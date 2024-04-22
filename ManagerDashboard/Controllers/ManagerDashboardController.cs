using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ManagerDashboard.Models;

namespace ManagerDashboard.Controllers
{
    public class ManagerDashboardController : Controller
    {
        private readonly List<DriverModel> _drivers;

        private readonly List<BusModel> _buses;

        private readonly List<LoopModel> _loops;

        private readonly List<StopModel> _stops;
        private readonly Manager _manager;

        public ManagerDashboardController(List<DriverModel> drivers, List<BusModel> buses, List<LoopModel> loops, List<StopModel> stops, Manager manager)
        {
            _drivers = drivers;
            _buses = buses;
            _loops = loops;
            _stops = stops;
            _manager = manager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("~/Views/Driver/Index.cshtml", _drivers);
        }

        [HttpGet]
        public IActionResult AddDriver()
        {
            return View("~/Views/Driver/AddDriver.cshtml");
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

        [HttpGet]
        public IActionResult EditDriver(int id)
        {
            var driver = _drivers.FirstOrDefault(d => d.Id == id);
            if (driver == null)
            {
                return NotFound();
            }

            var model = new DriverViewModel
            {
                Id = driver.Id,
                FirstName = driver.FirstName,
                LastName = driver.LastName,
                Username = driver.Username,
                Password = driver.Password
            };

            return View("~/Views/Driver/EditDriver.cshtml", model);
        }

        [HttpPost]
        public IActionResult EditDriver(DriverViewModel model)
        {
            if (ModelState.IsValid)
            {
                var driver = _drivers.FirstOrDefault(d => d.Id == model.Id);
                if (driver != null)
                {
                    driver.FirstName = model.FirstName;
                    driver.LastName = model.LastName;
                    driver.Username = model.Username;
                    driver.Password = model.Password;

                    return RedirectToAction("Index");
                }
                return NotFound();
            }
            return View("~/Views/Driver/EditDriver.cshtml", model);
        }

        [HttpGet]
        public IActionResult DeleteDriver(int id)
        {
            var driver = _drivers.FirstOrDefault(d => d.Id == id);
            if (driver == null)
            {
                return NotFound();
            }

            return View("~/Views/Driver/DeleteDriver.cshtml", driver);
        }


        [HttpPost]
        public IActionResult DeleteDriverConfirmed(int id)
        {
            var driver = _drivers.FirstOrDefault(d => d.Id == id);
            if (driver != null)
            {
                _drivers.Remove(driver);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult ListBuses()
        {
            return View("~/Views/Buses/ListBuses.cshtml", _buses);
        }

        [HttpGet]
        public IActionResult AddBus()
        {
            return View("~/Views/Buses/AddBus.cshtml");
        }

        [HttpPost]
        public IActionResult AddBus(BusModel model)
        {
            if (ModelState.IsValid)
            {
                _buses.Add(model);
                return RedirectToAction("ListBuses");
            }
            return View("~/Views/Buses/AddBus.cshtml", model);
        }

        [HttpGet]
        public IActionResult EditBus(int id)
        {
            var bus = _buses.FirstOrDefault(b => b.Id == id);
            if (bus == null)
            {
                return NotFound();
            }

            return View("~/Views/Buses/EditBus.cshtml", bus);
        }

        [HttpPost]
        public IActionResult EditBus(BusModel model)
        {
            if (ModelState.IsValid)
            {
                var existingBus = _buses.FirstOrDefault(b => b.Id == model.Id);
                if (existingBus != null)
                {
                    existingBus.BusNumber = model.BusNumber;
                    return RedirectToAction("ListBuses");
                }
                return NotFound();
            }
            return View("~/Views/Buses/EditBus.cshtml", model);
        }

        [HttpGet]
        public IActionResult DeleteBus(int id)
        {
            var bus = _buses.FirstOrDefault(b => b.Id == id);
            if (bus == null)
            {
                return NotFound();
            }

            return View("~/Views/Buses/DeleteBus.cshtml", bus);
        }

        [HttpPost]
        public IActionResult DeleteBusConfirmed(int id)
        {
            var bus = _buses.FirstOrDefault(b => b.Id == id);
            if (bus != null)
            {
                _buses.Remove(bus);
                return RedirectToAction("ListBuses");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult ListLoops()
        {
            return View("~/Views/Loops/ListLoops.cshtml", _loops);
        }

        [HttpGet]
        public IActionResult AddLoop()
        {
            return View("~/Views/Loops/AddLoop.cshtml");
        }

        [HttpPost]
        public IActionResult AddLoop(LoopModel model)
        {
            if (ModelState.IsValid)
            {
                _loops.Add(model);
                return RedirectToAction("ListLoops");
            }
            return View("~/Views/Loops/AddLoop.cshtml", model);
        }

        [HttpGet]
        public IActionResult EditLoop(int id)
        {
            var loop = _loops.FirstOrDefault(l => l.Id == id);
            if (loop == null)
            {
                return NotFound();
            }

            return View("~/Views/Loops/EditLoop.cshtml", loop);
        }

        [HttpPost]
        public IActionResult EditLoop(LoopModel model)
        {
            if (ModelState.IsValid)
            {
                var existingLoop = _loops.FirstOrDefault(l => l.Id == model.Id);
                if (existingLoop != null)
                {
                    existingLoop.LoopName = model.LoopName;
                    return RedirectToAction("ListLoops");
                }
                return NotFound();
            }
            return View("~/Views/Loops/EditLoop.cshtml", model);
        }

        [HttpGet]
        public IActionResult DeleteLoop(int id)
        {
            var loop = _loops.FirstOrDefault(l => l.Id == id);
            if (loop == null)
            {
                return NotFound();
            }

            return View("~/Views/Loops/DeleteLoop.cshtml", loop);
        }

        [HttpPost]
        public IActionResult DeleteLoopConfirmed(int id)
        {
            var loop = _loops.FirstOrDefault(l => l.Id == id);
            if (loop != null)
            {
                _loops.Remove(loop);
                return RedirectToAction("ListLoops");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult ListStops()
        {
            return View("~/Views/Stops/ListStops.cshtml", _stops);
        }

        [HttpGet]
        public IActionResult AddStop()
        {
            return View("~/Views/Stops/AddStop.cshtml");
        }

        [HttpPost]
        public IActionResult AddStop(StopModel model)
        {
            if (ModelState.IsValid)
            {
                _stops.Add(model);
                return RedirectToAction("ListStops");
            }
            return View("~/Views/Stops/AddStop.cshtml", model);
        }

        [HttpGet]
        public IActionResult EditStop(int id)
        {
            var stop = _stops.FirstOrDefault(s => s.Id == id);
            if (stop == null)
            {
                return NotFound();
            }

            return View("~/Views/Stops/EditStop.cshtml", stop);
        }

        [HttpPost]
        public IActionResult EditStop(StopModel model)
        {
            if (ModelState.IsValid)
            {
                var existingStop = _stops.FirstOrDefault(s => s.Id == model.Id);
                if (existingStop != null)
                {
                    existingStop.StopName = model.StopName;
                    return RedirectToAction("ListStops");
                }
                return NotFound();
            }
            return View("~/Views/Stops/EditStop.cshtml", model);
        }

        [HttpGet]
        public IActionResult DeleteStop(int id)
        {
            var stop = _stops.FirstOrDefault(s => s.Id == id);
            if (stop == null)
            {
                return NotFound();
            }

            return View("~/Views/Stops/DeleteStop.cshtml", stop);
        }

        [HttpPost]
        public IActionResult DeleteStopConfirmed(int id)
        {
            var stop = _stops.FirstOrDefault(s => s.Id == id);
            if (stop != null)
            {
                _stops.Remove(stop);
                return RedirectToAction("ListStops");
            }
            return NotFound();
        }

    }
}
