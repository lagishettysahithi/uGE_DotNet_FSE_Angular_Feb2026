using System.Xml.Linq;

namespace Student_Grade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int marks;
            string uname;


            Console.WriteLine("Enter Name:");
            uname = Console.ReadLine();
            Console.WriteLine("enter marks:");
            marks = int.Parse(Console.ReadLine());

            if (marks < 0 || marks > 100)
            {
                Console.WriteLine("Invaild Marks");
            }

            else
            {
                if (marks >=90)
                {
                    Console.WriteLine("Grade A");
                }
                else if (marks >= 75)
                {
                    Console.WriteLine("Grade: B");
                }
                else if (marks >= 60)
                {
                    Console.WriteLine("Grade: C");
                }
                else if (marks >= 50)
                {
                    Console.WriteLine("Grade: D");
                }
                else
                {
                    Console.WriteLine("Grade: Fail");
                }
            }

        }
    }
}
        

