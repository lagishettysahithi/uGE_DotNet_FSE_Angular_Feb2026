
using WebApplication1.Models;

namespace WebApplication1.DataAccess
{
    public interface IContactRepository
    {
        List<ContactInfo> GetAll();
        ContactInfo GetById(int id);
        ContactInfo Add(ContactInfo contact);
        ContactInfo Update(int id, ContactInfo contact);
        ContactInfo Delete(int id);
    }
}
