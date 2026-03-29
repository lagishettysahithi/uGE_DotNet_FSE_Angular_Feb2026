using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
namespace WebApplication3.Controllers
{
    public class AccountController : Controller
    {
        // GET: Login Page
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        // POST: Handle Login
        [HttpPost]
        public IActionResult Login(LoginModel model)
        {
            if (model.Username == "sahithi" && model.Password == "1234")
            {
                ViewBag.Message = "Login Successful!";
                return View("Success");
            }
            else
            {
                ViewBag.Message = "Invalid Username or Password";
                return View();
            }
        }
    }
}
