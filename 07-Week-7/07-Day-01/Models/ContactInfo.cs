using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class ContactInfo
    {
        [Required(ErrorMessage = "Contact Id is required")]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CompanyName { get; set; }

        [EmailAddress]
        public string EmailId { get; set; }

        public long MobileNo { get; set; }

        public string Designation { get; set; }
    }
}