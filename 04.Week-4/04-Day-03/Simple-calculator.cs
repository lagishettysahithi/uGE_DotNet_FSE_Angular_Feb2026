namespace Simple_Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int num1;
            int num2;
            char op;
            int result;

            Console.WriteLine("enter first number:");
            num1=int.Parse(Console.ReadLine());

            Console.WriteLine("enter second number:");
            num2=int.Parse(Console.ReadLine());

            Console.WriteLine("enter operator(+,-,*,/)");
            op = char.Parse(Console.ReadLine());

            switch (op)
            {
                case '+':
                    result=num1 + num2;
                    Console.WriteLine("result : "+ result);
                    break;

                case '-':
                    result = num1 - num2;
                    Console.WriteLine("result : " + result);
                    break;

                case '*':
                    result = num1 * num2;
                    Console.WriteLine("result : " + result);
                    break;

                case '/':
                    result = num1 / num2;
                    Console.WriteLine("result : " + result);
                    break;

                default:
                    Console.WriteLine("Invalid operation");
                    return;

            }

        }
    }
}
