using Microsoft.AspNetCore.Mvc;

namespace WebApplication2.Controllers
{
    [Route("feedback")]
    public class FeedbackController : Controller
    {
        // GET → Show Form
        [HttpGet("form")]
        public IActionResult Form()
        {
            return View();
        }

        //  POST → Handle Submission
        [HttpPost("form")]
        public IActionResult Form(string name, string comments, int rating)
        {
            //  Conditional Logic
            if (rating >= 4)
            {
                ViewData["Message"] = "Thank You for your positive feedback!";
            }
            else
            {
                ViewData["Message"] = "We will improve based on your feedback.";
            }

            // Optional: show entered name
            ViewData["UserName"] = name;

            return View(); // return same page
        }
    }
}
