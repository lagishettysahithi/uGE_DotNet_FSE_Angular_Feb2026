using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{

    [Route("contact")]
    public class ContactController : Controller
    {
        private readonly IContactService _service;

        public ContactController(IContactService service)
        {
            _service = service;
        }

        // 🔹 SHOW LIST
        [HttpGet("")]
        public IActionResult Index()
        {
            return View(_service.GetContacts());
        }

        // 🔹 CREATE GET
        [HttpGet("create")]
        public IActionResult Create()
        {
            LoadDropdowns();
            return View();
        }

        // 🔹 CREATE POST
        [HttpPost("create")]
        public IActionResult Create(ContactInfo contact)
        {
            if (!ModelState.IsValid)
            {
                LoadDropdowns();
                return View(contact);
            }

            _service.Create(contact);
            return RedirectToAction("Index");
        }

        // 🔹 EDIT GET
        [HttpGet("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var data = _service.GetContact(id);

            if (data == null)
                return NotFound();

            LoadDropdowns();
            return View(data);
        }

        // 🔹 EDIT POST (FIXED ROUTE)
        [HttpPost("edit/{id}")]
        public IActionResult Edit(int id, ContactInfo contact)
        {
            if (id != contact.ContactId)
                return BadRequest();

            if (!ModelState.IsValid)
            {
                LoadDropdowns();
                return View(contact);
            }

            _service.Update(contact);
            return RedirectToAction("Index");
        }

        // 🔹 DELETE GET
        [HttpGet("delete/{id}")]
        public IActionResult Delete(int id)
        {
            var data = _service.GetContact(id);

            if (data == null)
                return NotFound();

            return View(data);
        }

        // 🔹 DELETE POST (FIXED NAME + ROUTE)
        [HttpPost("delete/{id}")]
        [ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            _service.Delete(id);
            return RedirectToAction("Index");
        }

        // 🔹 DROPDOWNS
        private void LoadDropdowns()
        {
            ViewBag.Companies = _service.GetCompanies();
            ViewBag.Departments = _service.GetDepartments();
        }
    }
}