using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService
                ?? throw new ArgumentNullException(nameof(contactService));
        }

        // GET: api/contact
        [HttpGet]
        public ActionResult<IEnumerable<Contact>> GetAll()
        {
            var contacts = _contactService.GetAllContacts();
            return Ok(contacts);
        }

        // GET: api/contact/5
        [HttpGet("{id:int}")]
        public ActionResult<Contact> GetById(int id)
        {
            var contact = _contactService.GetContactById(id);

            if (contact == null)
                return NotFound($"Contact with ID {id} not found.");

            return Ok(contact);
        }

        // POST: api/contact
        [HttpPost]
        public ActionResult Create([FromBody] Contact contact)
        {
            if (contact == null)
                return BadRequest("Contact data is required.");

            try
            {
                _contactService.AddContact(contact);
                return CreatedAtAction(nameof(GetById), new { id = contact.Id }, contact);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT: api/contact/5
        [HttpPut("{id:int}")]
        public ActionResult Update(int id, [FromBody] Contact contact)
        {
            if (contact == null || id != contact.Id)
                return BadRequest("Invalid contact data.");

            try
            {
                _contactService.UpdateContact(contact);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Contact with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE: api/contact/5
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _contactService.DeleteContact(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound($"Contact with ID {id} not found.");
            }
        }
    }
}