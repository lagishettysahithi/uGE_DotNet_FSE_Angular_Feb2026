using Microsoft.AspNetCore.Mvc;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _repo;

        public HomeController(IStudentRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Students()
        {
            var students = _repo.GetStudentsWithCourse();
            return View(students);
        }

        public IActionResult Courses()
        {
            var courses = _repo.GetCoursesWithStudents();
            return View(courses);
        }
    }
}