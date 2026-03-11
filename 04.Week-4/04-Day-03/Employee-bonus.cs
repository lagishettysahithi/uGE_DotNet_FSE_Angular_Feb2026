namespace Employee_Bonus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            double salary;
            int experience;
            double bonusPercent;
            double bonus;
            double finalSalary;


            Console.WriteLine("Enter Name:");
            name = Console.ReadLine();

            Console.WriteLine("Enter Salary:");
            salary = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter Experience :");
            experience = int.Parse(Console.ReadLine());

            if (experience < 2)
            {
                bonusPercent = 0.05;
            }
            else if (experience <= 5)
            {
                bonusPercent = 0.10;
            }
            else 
              {
                bonusPercent = 0.15;
            }

            bonus = salary > 0? salary * bonusPercent:0;
            finalSalary = salary + bonus;

            Console.WriteLine($"Employee: {name}");
            Console.WriteLine($"Bonus: {bonus}");
            Console.WriteLine($"Final Salary: {finalSalary}");

        }

    }
}
