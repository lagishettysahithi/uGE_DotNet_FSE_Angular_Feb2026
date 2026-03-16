namespace Day_19
{
    class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        public int Subtract(int a, int b)
        {
            return a - b;
        }
        internal class Program
        {
            static void Main(string[] args)
            {
                int num1;

                Console.WriteLine("enter fst no:");
                num1 = int.Parse(Console.ReadLine());

               


                Calculator calobj = new Calculator();

                int addition = calobj.Add(num1,5);
                Console.WriteLine($"Addition:  {addition}");
                Console.WriteLine($"Subtraction:  {calobj.Subtract(num1, 5)}");


            }
        }
    }
}
