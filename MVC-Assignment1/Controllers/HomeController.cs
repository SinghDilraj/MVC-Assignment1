using MVC_Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Assignment1.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext DbContext;

        public HomeController()
        {
            DbContext = new ApplicationDbContext();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Courses()
        {
            List<Models.Classes.Course> courses =
                (from course in DbContext.Courses
                 select course).ToList();

            return View(courses);
        }

        public ActionResult CourseDetails(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction(nameof(HomeController.Courses));
            }

            var course = DbContext.Courses.FirstOrDefault(p => p.Id == id.Value);

            return View(course);
        }
    }
}