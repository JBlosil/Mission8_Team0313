using Microsoft.AspNetCore.Mvc;
using Mission8_Team0313.Models;
using System.Diagnostics;

namespace Mission8_Team0313.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private TimeManagementContext context;

        public HomeController(TimeManagementContext temp)
        {
            context = temp
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddEdit()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new Tasks { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
