using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Dept
    {
        public int DeptId {  get; set; }
        public string Dname { get; set; }
        public string Location { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
