using WebApplication2.Models;
using Dapper;
using Microsoft.Data.SqlClient;
namespace WebApplication2.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly string _connStr;

        public ContactRepository(IConfiguration config)
        {
            _connStr = config.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' is missing.");
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_connStr);
        }

        public IEnumerable<ContactInfo> GetAllContacts()
        {
            string query = @"SELECT c.*, comp.CompanyName, d.DepartmentName
                         FROM ContactInfo c
                         JOIN Company comp ON c.CompanyId = comp.CompanyId
                         LEFT JOIN Department d ON c.DepartmentId = d.DepartmentId";

            using var db = GetConnection();
            return db.Query<ContactInfo>(query);
        }

        public ContactInfo? GetContactById(int id)
        {
            using var db = GetConnection();
            return db.QueryFirstOrDefault<ContactInfo>(
                "SELECT * FROM ContactInfo WHERE ContactId=@Id", new { Id = id });
        }

        public void AddContact(ContactInfo contact)
        {
            using var db = GetConnection();
            db.Execute(@"INSERT INTO ContactInfo
        (FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId)
        VALUES (@FirstName,@LastName,@EmailId,@MobileNo,@Designation,@CompanyId,@DepartmentId)", contact);
        }

        public void UpdateContact(ContactInfo contact)
        {
            using var db = GetConnection();
            db.Execute(@"UPDATE ContactInfo SET
        FirstName=@FirstName, LastName=@LastName, EmailId=@EmailId,
        MobileNo=@MobileNo, Designation=@Designation,
        CompanyId=@CompanyId, DepartmentId=@DepartmentId
        WHERE ContactId=@ContactId", contact);
        }

        public void DeleteContact(int id)
        {
            using var db = GetConnection();
            db.Execute("DELETE FROM ContactInfo WHERE ContactId=@Id", new { Id = id });
        }

        public IEnumerable<Company> GetCompanies()
        {
            using var db = GetConnection();
            return db.Query<Company>("SELECT * FROM Company");
        }

        public IEnumerable<Department> GetDepartments()
        {
            using var db = GetConnection();
            return db.Query<Department>("SELECT * FROM Department");
        }
    }
}