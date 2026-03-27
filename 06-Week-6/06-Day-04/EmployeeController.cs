using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            // Sample data (you can later connect DB)
            List<Employee> employees = new List<Employee>()
            {
                new Employee { Empno = 101, Ename = "John", Job = "Manager", Salary = 50000, Deptno = 10 },
                new Employee { Empno = 102, Ename = "Sara", Job = "Developer", Salary = 40000, Deptno = 20 },
                new Employee { Empno = 103, Ename = "David", Job = "Tester", Salary = 30000, Deptno = 30 }
            };

            return View(employees);
        }
    }
}