using ASP.NET_LAB_1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP.NET_LAB_1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public enum Operators
        {
            ADD,SUB,MUL,DIV 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Calculator([FromQuery(Name ="operator")]Operators op, double? a, double? b)
        {
            switch (op)
            {
                case Operators.ADD:
                    ViewBag.Op = a + b;
                    break;
                case Operators.SUB:
                    ViewBag.Op = a - b;
                    break;
                case Operators.MUL:
                    ViewBag.Op = a * b; 
                    break;
                case Operators.DIV:
                    ViewBag.Op = a / b;
                    break;
            }   
            if (a == null || b == null)
            {
                return View("Error");
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}