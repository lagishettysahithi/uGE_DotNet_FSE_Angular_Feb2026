using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("student")]
    public class StudentController : Controller
    {

        //  GET → Display Form
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View();
        }

        //  POST → Handle Form Submission
        [HttpPost("register")]
        public IActionResult Register(string name, int age, string course)
        {
            // Store data using ViewBag
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewBag.Course = course;

            // Redirect to Display Action
            return RedirectToAction("Display", new
            {
                name = name,
                age = age,
                course = course
            });
        }

        //  Display Submitted Data
        [HttpGet("display")]
        public IActionResult Display(string name, int age, string course)
        {
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewBag.Course = course;

            return View();
        }
    }
}

