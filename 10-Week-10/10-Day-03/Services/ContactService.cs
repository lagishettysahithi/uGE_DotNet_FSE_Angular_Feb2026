using System.Xml.Linq;
using WebApplication2.Models;

namespace WebApplication2.Services
{
    public class ContactService : IContactService
    {
        private static List<Contact> contacts = new List<Contact>();

        public List<Contact> GetAll()
        {
            return contacts;
        }

        public Contact GetById(int id)
        {
            return contacts.FirstOrDefault(c => c.Id == id);
        }

        public Contact Add(Contact contact)
        {
            contact.Id = contacts.Count + 1;
            contacts.Add(contact);
            return contact;
        }

        public bool Update(int id, Contact contact)
        {
            var existing = contacts.FirstOrDefault(c => c.Id == id);
            if (existing == null) return false;

            existing.Name = contact.Name;
            existing.Email = contact.Email;
            existing.Phone = contact.Phone;
            return true;
        }

        public bool Delete(int id)
        {
            var contact = contacts.FirstOrDefault(c => c.Id == id);
            if (contact == null) return false;

            contacts.Remove(contact);
            return true;
        }
    }
}

