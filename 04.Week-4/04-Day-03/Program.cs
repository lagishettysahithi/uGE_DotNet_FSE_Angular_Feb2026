namespace Number_Analysis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N;
            int evenCount = 0;
            int oddCount = 0;
            int sum = 0;

            Console.WriteLine("Enter Number:");
            N=int.Parse(Console.ReadLine()) ;

            for (int i = 1; i <= N; i++)
            {
                sum =sum+i;
                if (i % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
            }
            Console.WriteLine($"EvenCount : {evenCount}");
            Console.WriteLine($"ODD Count :{oddCount}");
            Console.WriteLine($"sum: {sum}");

        }
    }
}
