using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission8_Team0313.Models;
using System.Diagnostics;

namespace Mission8_Team0313.Controllers
{
    public class HomeController : Controller
    {


        private IManagementRepository _repo;

        public HomeController(IManagementRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var recordDelete = _repo.Actions
            .Single(x => x.TaskID == id);

            return View(recordDelete);
        }

        [HttpPost]
        public IActionResult Delete(Models.Action tasktodelete)
        {
            _repo.DeleteAction(tasktodelete.TaskID);
            _repo.SaveChanges();

            return RedirectToAction("Quadrants");
        }

        public IActionResult Quadrants()
        {
            var tasks = _repo.Actions.Where(x => x.Completed == 0).Include("Category")
                 .OrderBy(x => x.TaskID).ToList();

            return View(tasks);
        }

        [HttpGet]
        public IActionResult AddEdit()
        {

            return View(new Models.Action());
        }

        [HttpPost]
        public IActionResult AddEdit(Models.Action response)
        {
            if (response.Quadrant == null || response.Task == null)
            {
                // Model validation failed, return to the view with the current model to show validation messages
                return View(response);
            }
            else
            {
                _repo.AddAction(response); //Add record to database
                _repo.SaveChanges();
                return RedirectToAction("Quadrants");
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var recordEdit = _repo.Actions
                .Single(x => x.TaskID == id);


            return View("AddEdit", recordEdit);
        }

        [HttpPost]
        public IActionResult Edit(Models.Action updatedInfo)
        {
            _repo.UpdateAction(updatedInfo);
            _repo.SaveChanges();

            return RedirectToAction("Quadrants");
        }
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new Tasks { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
