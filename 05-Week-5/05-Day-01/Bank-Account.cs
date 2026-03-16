namespace ConsoleApp1
{
    class BankAccount
    {

        private string accountNumber;
        private double balance;

        public string AccountNumber=>accountNumber;
        
        public double Balance =>  balance; 
        


        public BankAccount(string AccNo){
            accountNumber=AccNo;
            balance=0;
        }

        public void deposit(double amount)
        {
            if( amount <=0){
                Console.WriteLine("Invalid deposit amnt");
                return;
            }
            balance += amount;
            Console.WriteLine("amnt deposit:"+ amount);
            Console.WriteLine("amnt blnce:" + balance);

        }

        public void Withdraw(double amount)  {
            if( amount <=0){
                Console.WriteLine("Invalid withdrawal amount");
                return;
            }

            if (amount > balance)
            {
                Console.WriteLine("Insufficient Balance");
                return;
            }

            balance = balance - amount;
            Console.WriteLine("Amount Withdrawn: " + amount);
            Console.WriteLine("Current Balance = " + balance);
        }

    }
    internal class Program
    {
        

        static void Main(string[] args)
        {
            BankAccount account = new BankAccount("S123");


            Console.Write("Enter Deposit Amount: ");
            double deposit = Convert.ToDouble(Console.ReadLine());
            account.deposit(deposit);

            Console.Write("Enter Withdraw Amount: ");
            double withdraw = Convert.ToDouble(Console.ReadLine());
            account.Withdraw(withdraw);

            Console.WriteLine("Final Balance = " + account.Balance);

        }
    }
}
