using Microsoft.AspNetCore.Mvc;
using WebApplication3.Repository;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _repo;

        public ContactController(IContactRepository repo)
        {
            _repo = repo;
        }

        // ✅ LIST
        public IActionResult Index()
        {
            return View(_repo.GetAllContacts());
        }

        // ✅ DETAILS
        public IActionResult Details(int id)
        {
            var data = _repo.GetContactById(id);
            return View(data);
        }

        // ✅ CREATE (GET)
        public IActionResult Create()
        {
            ViewBag.Companies = _repo.GetCompanies();
            ViewBag.Departments = _repo.GetDepartments();
            return View();
        }

        // ✅ CREATE (POST)
        [HttpPost]
        public IActionResult Create(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                _repo.AddContact(contact);
                return RedirectToAction("Index");
            }

            ViewBag.Companies = _repo.GetCompanies();
            ViewBag.Departments = _repo.GetDepartments();
            return View();
        }

        // ✅ EDIT (GET)
        public IActionResult Edit(int id)
        {
            ViewBag.Companies = _repo.GetCompanies();
            ViewBag.Departments = _repo.GetDepartments();
            return View(_repo.GetContactById(id));
        }

        // ✅ EDIT (POST)
        [HttpPost]
        public IActionResult Edit(ContactInfo contact)
        {
            if (ModelState.IsValid)
            {
                _repo.UpdateContact(contact);
                return RedirectToAction("Index");
            }

            ViewBag.Companies = _repo.GetCompanies();
            ViewBag.Departments = _repo.GetDepartments();
            return View();
        }

        // ✅ DELETE (GET)
        public IActionResult Delete(int id)
        {
            var data = _repo.GetContactById(id);
            return View(data);
        }

        // ✅ DELETE (POST)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            _repo.DeleteContact(id);
            return RedirectToAction("Index");
        }
    }
}