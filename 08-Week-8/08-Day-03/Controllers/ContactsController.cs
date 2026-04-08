using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DataAccess;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {

        private readonly IContactRepository _repo;

        public ContactsController(IContactRepository repo)
        {
            _repo = repo;
        }

        // GET ALL
        [HttpGet]
        public IActionResult GetContacts()
        {
            return Ok(_repo.GetAll());
        }

        // GET BY ID
        [HttpGet("{id}")]
        public IActionResult GetContact(int id)
        {
            var contact = _repo.GetById(id);

            if (contact == null)
                return NotFound("Contact not found");

            return Ok(contact);
        }

        // ADD
        [HttpPost]
        public IActionResult AddContact(ContactInfo contact)
        {
            var newContact = _repo.Add(contact);

            return Ok(new
            {
                newContact,
                message = "Contact added successfully"
            });
        }

        // UPDATE
        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, ContactInfo contact)
        {
            var updated = _repo.Update(id, contact);

            if (updated == null)
                return NotFound("Contact not found");

            return Ok(new
            {
                updatedContact = updated,
                message = "Contact updated successfully"
            });
        }

        // DELETE
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var deleted = _repo.Delete(id);

            if (deleted == null)
                return NotFound("Contact not found");

            return Ok(new
            {
                deletedContact = deleted,
                message = "Contact deleted successfully"
            });
        }
    }
}
  