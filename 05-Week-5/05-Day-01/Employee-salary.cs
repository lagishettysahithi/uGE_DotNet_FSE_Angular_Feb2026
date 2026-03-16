namespace Employee_salary
{
    class Employee
    {
        public string Name { get; set; }
        public double BaseSalary { get; set; }
        public Employee(string name, double salary)
        {
            Name = name;
            BaseSalary = salary;
        }
        public virtual double CalculateSalary()
        { return BaseSalary; }
    }


    class Manager: Employee
    {
        public Manager(string name,double salary):base(name,salary) {
        
        }
        public override double CalculateSalary() {
            return BaseSalary+(BaseSalary*0.20);
        }
    }
    class Developer : Employee
    {
        public Developer(string name, double salary) : base(name, salary)
        {
        }
        public override double CalculateSalary()
        {
            return BaseSalary + (BaseSalary * 0.10);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Enter Base Salary: ");
            double salary = Convert.ToDouble(Console.ReadLine());

            // Polymorphism using base class reference
            Employee manager = new Manager("Manager", salary);
            Employee developer = new Developer("Developer", salary);

            Console.WriteLine("Manager Salary = " + manager.CalculateSalary());
            Console.WriteLine("Developer Salary = " + developer.CalculateSalary());
        

    }
    }
}
