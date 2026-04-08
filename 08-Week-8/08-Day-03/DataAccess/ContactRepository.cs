using WebApplication1.Models;

namespace WebApplication1.DataAccess
{
    public class ContactRepository : IContactRepository
    {
        public static List<ContactInfo> contacts = new List<ContactInfo>()
        {
            new ContactInfo { ContactId = 1, FirstName = "Sahithi", LastName = "Shetti", EmailId="Sahithi@gmail.com",
                MobileNo=9999999999, Designation="Manager", CompanyId=1, DepartmentId=1 },

             new ContactInfo { ContactId = 2, FirstName = "Sai", LastName = "Shetti", EmailId="Sai@gmail.com",
                 MobileNo=234567, Designation="ASE", CompanyId=2, DepartmentId=2 }

        };

        // GET ALL
        public List<ContactInfo> GetAll()
        {
            return contacts;
        }

        // GET BY ID
        public ContactInfo GetById(int id)
        {
            return contacts.Find(c => c.ContactId == id);
        }

        // ADD
        public ContactInfo Add(ContactInfo contact)
        {
            contact.ContactId = contacts.Count > 0 ? contacts.Max(c => c.ContactId) + 1 : 1;
            contacts.Add(contact);
            return contact;
        }

        // UPDATE
        public ContactInfo Update(int id, ContactInfo contact)
        {
            var existing = contacts.Find(c => c.ContactId == id);

            if (existing == null)
                return null;

            existing.FirstName = contact.FirstName;
            existing.LastName = contact.LastName;
            existing.EmailId = contact.EmailId;
            existing.MobileNo = contact.MobileNo;
            existing.Designation = contact.Designation;
            existing.CompanyId = contact.CompanyId;
            existing.DepartmentId = contact.DepartmentId;

            return existing;
        }

        // DELETE
        public ContactInfo Delete(int id)
        {
            var contact = contacts.Find(c => c.ContactId == id);

            if (contact == null)
                return null;

            contacts.Remove(contact);
            return contact;
        }
    }
}