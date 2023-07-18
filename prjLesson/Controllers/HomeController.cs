using Microsoft.AspNetCore.Mvc;
using prjLesson.Models;
using System.Diagnostics;

namespace prjLesson.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult First()
        {
            return View();
        }

        public IActionResult AjaxEvent()
        {
            return View();
        }

        public IActionResult Register() 
        {
            return View();
        }

        public IActionResult Fetch() 
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        public IActionResult jQuery()
        {
            return View();
        }

        public IActionResult ShipperCors()
        {
            return View();
        }

        public IActionResult ShipperCorsEmpty()
        {
            return View();
        }

        public IActionResult Partial1()
        {
            return PartialView();
        }

        public IActionResult Partial2()
        {
            ViewBag.Message = "Hello Partial View in ViewBag";
            return PartialView();
        }

        public IActionResult Datatables()
        {
            return View();
        }

        public IActionResult Addresses() 
        {
            return View();
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
}