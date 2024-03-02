using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission8_Team0313.Models;
using System.Diagnostics;

namespace Mission8_Team0313.Controllers
{
    public class HomeController : Controller
    {

        private TimeManagementContext _context;

        public HomeController(TimeManagementContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordDelete = _context.Actions
            .Single(x => x.TaskID == id);

            return View(recordDelete);
        }

        [HttpPost]
        public IActionResult Delete(Models.Action tasktodelete)
        {
            _context.Actions.Remove(tasktodelete);
            _context.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        public IActionResult Quadrants()
        {
            var tasks = _context.Actions.Include("Category")
                 .OrderBy(x => x.TaskID).ToList();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult AddEdit()
        {
            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();

            return View(new Models.Action());
        }

        [HttpPost]
        public IActionResult AddEdit(Models.Action response)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName).ToList();
                // Model validation failed, return to the view with the current model to show validation messages
                return View(response);
            }
            else
            {
                _context.Actions.Add(response); //Add record to database
                _context.SaveChanges();
                return RedirectToAction("Quadrants");
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordEdit = _context.Actions
                .Single(x => x.TaskID == id);

            ViewBag.Categories = _context.Categories
            .OrderBy(x => x.CategoryName).ToList();

            return View("AddEdit", recordEdit);
        }

        [HttpPost]
        public IActionResult Edit(Models.Action updatedInfo)
        {
            _context.Update(updatedInfo);
            _context.SaveChanges();

            return RedirectToAction("Quadrants");
        }
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new Tasks { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
