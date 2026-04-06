using WebApplication2.Models;

namespace WebApplication2.Services
{
    public interface IContactService
    {
     IEnumerable<ContactInfo> GetContacts();
    ContactInfo? GetContact(int id);
    void Create(ContactInfo contact);
    void Update(ContactInfo contact);
    void Delete(int id);

    IEnumerable<Company> GetCompanies();
    IEnumerable<Department> GetDepartments();

    }
}
