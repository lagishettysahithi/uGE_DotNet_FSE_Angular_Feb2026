using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {

        private readonly StudentCourseDbContext _context;

        public StudentController(StudentCourseDbContext context)
        {
            _context = context;
        }

        // Display Students with Course
        public IActionResult Index()
        {
            var students = _context.Students.Include(s => s.Course).ToList();
                                  

            return View(students);
        }

        // Display Courses with Students
        public IActionResult Courses()
        {
            var courses = _context.Courses.Include(c => c.Students).ToList();
                                 

            return View(courses);
        }
    }
}