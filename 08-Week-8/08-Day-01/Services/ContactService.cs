using WebApplication2.Models;
using WebApplication2.Repository;

namespace WebApplication2.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _repo;

        public ContactService(IContactRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<ContactInfo> GetContacts()
        {
            try { return _repo.GetAllContacts(); }
            catch { return Enumerable.Empty<ContactInfo>(); }
        }

        public ContactInfo? GetContact(int id)
        {
            try { return _repo.GetContactById(id); }
            catch { return null; }
        }

        public void Create(ContactInfo contact)
        {
            try { _repo.AddContact(contact); }
            catch { }
        }

        public void Update(ContactInfo contact)
        {
            try { _repo.UpdateContact(contact); }
            catch { }
        }

        public void Delete(int id)
        {
            try { _repo.DeleteContact(id); }
            catch { }
        }

        public IEnumerable<Company> GetCompanies()
        {
            try { return _repo.GetCompanies(); }
            catch { return Enumerable.Empty<Company>(); }
        }

        public IEnumerable<Department> GetDepartments()
        {
            try { return _repo.GetDepartments(); }
            catch { return Enumerable.Empty<Department>(); }
        }
    }
}