namespace Casestudy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp = new Employee("sahihti", 3200, 21);

            Console.WriteLine("Employee ID: " + emp.EmployeeId);
            Console.WriteLine("Name: " + emp.FullName);
            Console.WriteLine("Age: " + emp.Age);
            Console.WriteLine("Salary: " + emp.Salary);

            emp.GiveRaise(10);

            bool result = emp.DeductPenalty(200);

            if (result)
                Console.WriteLine("Penalty deducted successfully.");
            else
                Console.WriteLine("Penalty failed. Salary cannot go below 1000.");

            Console.ReadLine();
        }


    }
    }

