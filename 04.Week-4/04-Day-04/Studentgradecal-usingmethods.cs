namespace Student_grade_methods
{
    class Student {

        public double CalAvg(int m1, int m2,int m3)
        {
            double avg = (m1 + m2 + m3) / 3.0;
            return avg;
        }
    internal class Program
        {
            static void Main(string[] args)
            {
                int m1,m2,m3;
                Console.WriteLine("Enter marks 1:");
                m1 = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter marks 2:");
                m2 = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter marks 3:");
                m3 = int.Parse(Console.ReadLine());

                Student stuObj = new Student();

                double average=stuObj.CalAvg(m1,m2,m3);

                Console.WriteLine($"Average {average}");
                if (average >= 80)
                    Console.WriteLine("Grade = A");
                else if (average >= 60)
                    Console.WriteLine("Grade = B");
                else if (average >= 40)
                    Console.WriteLine("Grade = C");
                else
                    Console.WriteLine("Grade = F");

            }
        }
    }
}