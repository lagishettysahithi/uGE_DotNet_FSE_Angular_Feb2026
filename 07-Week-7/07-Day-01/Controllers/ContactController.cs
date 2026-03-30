using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class ContactController : Controller
    {
        
        public static List<ContactInfo> contacts = new List<ContactInfo>()
        {

    new ContactInfo
    {
        ContactId = 1,
        FirstName = "Sahithi",
        LastName = "Shetti",
        CompanyName = "ABC ",
        EmailId = "sahithi@gmail.com",
        MobileNo = 23456789,
        Designation = "Developer"
    },
    new ContactInfo
    {
        ContactId = 2,
        FirstName = "Sruthi",
        LastName = "Sharma",
        CompanyName = "XYZ ",
        EmailId = "amit@gmail.com",
        MobileNo = 123456780,
        Designation = "Manager"
        } };

        // INDEX (Show All)
        public IActionResult Index()
        {
            return View(contacts);
        }

        // DETAILS
        public IActionResult Details(int id)
        {
            var contact = contacts.FirstOrDefault(x => x.ContactId == id);
            return View(contact);
        }

        // CREATE - GET
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // CREATE - POST
        [HttpPost]
        public IActionResult Create(ContactInfo obj)
        {
            if (ModelState.IsValid)
            {
                contacts.Add(obj);
                return RedirectToAction("Index");
            }

            ViewBag.ErrorMessage = "Invalid data!";
            return View();
        }

        // SEARCH
        public IActionResult Search(int id)
        {
            var result = contacts.Where(x => x.ContactId == id).ToList();
            return View(result);
        }
    }
}
