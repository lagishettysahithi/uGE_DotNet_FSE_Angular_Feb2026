using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class ContactInfo
    {
        public int ContactId { get; set; }

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string EmailId { get; set; } = string.Empty;

        [Required]
        public long MobileNo { get; set; }

        [Required]
        public string Designation { get; set; } = string.Empty;

        [Required]
        public int CompanyId { get; set; }

        public int DepartmentId { get; set; }

        public string CompanyName { get; set; } = string.Empty;
        public string DepartmentName { get; set; } = string.Empty;
    }
}