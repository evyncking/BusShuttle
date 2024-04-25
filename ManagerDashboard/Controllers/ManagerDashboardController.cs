using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ManagerDashboard.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;


namespace ManagerDashboard.Controllers
{
    public class ManagerDashboardController : Controller
    {
        private readonly BusShuttleContext _context;

        public ManagerDashboardController(BusShuttleContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var drivers = _context.Drivers.ToList();
            return View("~/Views/Driver/Index.cshtml", drivers);
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
                _context.Drivers.Add(driver);
                _context.SaveChanges();
                return RedirectToAction("Index", "ManagerDashboard");
            }
            return View(model);
        }
    

        [HttpGet]
        public IActionResult ActivateDriver(int id)
        {
            var driver = _context.Drivers.FirstOrDefault(d => d.Id == id);
            if (driver != null)
            {
                driver.IsActive = true;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult DeactivateDriver(int id)
        {
            var driver = _context.Drivers.FirstOrDefault(d => d.Id == id);
            if (driver != null)
            {
                driver.IsActive = false;
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult ListDrivers([FromServices] BusShuttleContext context)
        {
            var drivers = context.Drivers.ToList();
            return View(drivers);
        }

        [HttpGet]
        public IActionResult ListDriversToActivate()
        {
            var driversToActivate = _context.Drivers.Where(d => !d.IsActive).ToList();
            return View(driversToActivate);
        }

        [HttpGet]
        public IActionResult ListActiveDrivers()
        {
            var activeDrivers = _context.Drivers.Where(d => d.IsActive).ToList();
            return View(activeDrivers);
        }

        [HttpGet]
        public IActionResult EditDriver(int id)
        {
            var driver = _context.Drivers.FirstOrDefault(d => d.Id == id);
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
                var driver = _context.Drivers.FirstOrDefault(d => d.Id == model.Id);
                if (driver != null)
                {
                    driver.FirstName = model.FirstName;
                    driver.LastName = model.LastName;
                    driver.Username = model.Username;
                    driver.Password = model.Password;

                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
                return NotFound();
            }
            return View("~/Views/Driver/EditDriver.cshtml", model);
        }

        [HttpGet]
        public IActionResult DeleteDriver(int id)
        {
            var driver = _context.Drivers.FirstOrDefault(d => d.Id == id);
            if (driver == null)
            {
                return NotFound();
            }

            return View("~/Views/Driver/DeleteDriver.cshtml", driver);
        }


        [HttpPost]
        public IActionResult DeleteDriverConfirmed(int id)
        {
            var driver = _context.Drivers.FirstOrDefault(d => d.Id == id);
            if (driver != null)
            {
                _context.Drivers.Remove(driver);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult ListBuses()
        {
            var buses = _context.Buses.ToList();
            return View("~/Views/Buses/ListBuses.cshtml", buses);
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
                _context.Buses.Add(model);
                _context.SaveChanges();
                return RedirectToAction("ListBuses");
            }
            return View("~/Views/Buses/AddBus.cshtml", model);
        }

        [HttpGet]
        public IActionResult EditBus(int id)
        {
            var bus = _context.Buses.FirstOrDefault(b => b.Id == id);
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
                var existingBus = _context.Buses.FirstOrDefault(b => b.Id == model.Id);
                if (existingBus != null)
                {
                    existingBus.BusNumber = model.BusNumber;
                    _context.SaveChanges();
                    return RedirectToAction("ListBuses");
                }
                return NotFound();
            }
            return View("~/Views/Buses/EditBus.cshtml", model);
        }

        [HttpGet]
        public IActionResult DeleteBus(int id)
        {
            var bus = _context.Buses.FirstOrDefault(b => b.Id == id);
            if (bus == null)
            {
                return NotFound();
            }

            return View("~/Views/Buses/DeleteBus.cshtml", bus);
        }

        [HttpPost]
        public IActionResult DeleteBusConfirmed(int id)
        {
            var bus = _context.Buses.FirstOrDefault(b => b.Id == id);
            if (bus != null)
            {
                _context.Buses.Remove(bus);
                _context.SaveChanges();
                return RedirectToAction("ListBuses");
            }
            return NotFound();
        }


        [HttpGet]
        public IActionResult ListLoops()
        {
            var loops = _context.Loops.ToList();
            return View("~/Views/Loops/ListLoops.cshtml", loops);
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
                _context.Loops.Add(model);
                _context.SaveChanges();
                return RedirectToAction("ListLoops");
            }
            return View("~/Views/Loops/AddLoop.cshtml", model);
        }

        [HttpGet]
        public IActionResult EditLoop(int id)
        {
            var loop = _context.Loops.FirstOrDefault(l => l.Id == id);
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
                var existingLoop = _context.Loops.FirstOrDefault(l => l.Id == model.Id);
                if (existingLoop != null)
                {
                    existingLoop.LoopName = model.LoopName;
                    _context.SaveChanges();
                    return RedirectToAction("ListLoops");
                }
                return NotFound();
            }
            return View("~/Views/Loops/EditLoop.cshtml", model);
        }

        [HttpGet]
        public IActionResult DeleteLoop(int id)
        {
            var loop = _context.Loops.FirstOrDefault(l => l.Id == id);
            if (loop == null)
            {
                return NotFound();
            }

            return View("~/Views/Loops/DeleteLoop.cshtml", loop);
        }

        [HttpPost]
        public IActionResult DeleteLoopConfirmed(int id)
        {
            var loop = _context.Loops.FirstOrDefault(l => l.Id == id);
            if (loop != null)
            {
                _context.Loops.Remove(loop);
                _context.SaveChanges();
                return RedirectToAction("ListLoops");
            }
            return NotFound();
        }


        [HttpGet]
        public IActionResult ListStops()
        {
            return View("~/Views/Stops/ListStops.cshtml", _context.Stops.ToList());
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
                _context.Stops.Add(model);
                _context.SaveChanges();
                return RedirectToAction("ListStops");
            }
            return View("~/Views/Stops/AddStop.cshtml", model);
        }

        [HttpGet]
        public IActionResult EditStop(int id)
        {
            var stop = _context.Stops.FirstOrDefault(s => s.Id == id);
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
                var existingStop = _context.Stops.FirstOrDefault(s => s.Id == model.Id);
                if (existingStop != null)
                {
                    existingStop.StopName = model.StopName;
                    _context.SaveChanges();
                    return RedirectToAction("ListStops");
                }
                return NotFound();
            }
            return View("~/Views/Stops/EditStop.cshtml", model);
        }

        [HttpGet]
        public IActionResult DeleteStop(int id)
        {
            var stop = _context.Stops.FirstOrDefault(s => s.Id == id);
            if (stop == null)
            {
                return NotFound();
            }

            return View("~/Views/Stops/DeleteStop.cshtml", stop);
        }

        [HttpPost]
        public IActionResult DeleteStopConfirmed(int id)
        {
            var stop = _context.Stops.FirstOrDefault(s => s.Id == id);
            if (stop != null)
            {
                _context.Stops.Remove(stop);
                _context.SaveChanges();
                return RedirectToAction("ListStops");
            }
            return NotFound();
        }


        [HttpGet]
        public IActionResult ListRoutes()
        {
            var loops = _context.Loops.ToList(); // Assuming _context is your DbContext
            ViewBag.Loops = loops.Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.LoopName }).ToList();

            var stops = _context.Stops.ToList();
            ViewBag.Stops = stops.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.StopName }).ToList();
            
            var routes = _context.Routes.ToList(); // Get all routes including the newly added ones

            return View("~/Views/Routes/ListRoutes.cshtml", routes);
        }

        [HttpGet]
        public IActionResult AddRoute()
        {
            var loops = _context.Loops.ToList(); // Assuming _context is your DbContext
            var stops = _context.Stops.ToList();

            ViewBag.Loops = loops.Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.LoopName }).ToList();
            ViewBag.Stops = stops.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.StopName }).ToList();

            return View("~/Views/Routes/AddRoute.cshtml");
        }


        [HttpPost]
        public IActionResult AddRoute(RouteModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Routes.Add(model);
                _context.SaveChanges();
                return RedirectToAction("ListRoutes");
            }


            ViewBag.Loops = _context.Loops.Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.LoopName }).ToList();
            ViewBag.Stops = _context.Stops.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.StopName }).ToList();

            return View("~/Views/Routes/AddRoute.cshtml", model);
        }

        [HttpGet]
        public IActionResult EditRoute(int id)
        {
            var route = _context.Routes.FirstOrDefault(r => r.Id == id);
            if (route == null)
            {
                return NotFound();
            }

            ViewBag.Loops = _context.Loops.Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.LoopName }).ToList();
            ViewBag.Stops = _context.Stops.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.StopName }).ToList();

            return View("~/Views/Routes/EditRoute.cshtml", route);
        }

        [HttpPost]
        public IActionResult EditRoute(RouteModel model)
        {
            if (ModelState.IsValid)
            {
                var existingRoute = _context.Routes.FirstOrDefault(r => r.Id == model.Id);
                if (existingRoute != null)
                {
                    existingRoute.LoopId = model.LoopId;
                    existingRoute.StopId = model.StopId;
                    existingRoute.Position = model.Position;
                    _context.SaveChanges();
                    return RedirectToAction("ListRoutes");
                }
                return NotFound();
            }

            ViewBag.Loops = _context.Loops.Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.LoopName }).ToList();
            ViewBag.Stops = _context.Stops.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.StopName }).ToList();

            return View("~/Views/Routes/EditRoute.cshtml", model);
        }

        [HttpGet]
        public IActionResult DeleteRoute(int id)
        {
            var route = _context.Routes.FirstOrDefault(r => r.Id == id);
            if (route == null)
            {
                return NotFound();
            }

            return View("~/Views/Routes/DeleteRoute.cshtml", route);
        }

        [HttpPost]
        public IActionResult DeleteRouteConfirmed(int id)
        {
            var route = _context.Routes.FirstOrDefault(r => r.Id == id);
            if (route != null)
            {
                _context.Routes.Remove(route);
                _context.SaveChanges();
                return RedirectToAction("ListRoutes");
            }
            return NotFound();
        }


    }
}
