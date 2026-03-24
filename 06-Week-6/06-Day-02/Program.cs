using Microsoft.Data.SqlClient;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main()
        {
            // Windows Authentication
            string connStr = "Server=DESKTOP-JJ7C5FH\\SQLEXPRESS; Database=AutoDb; Integrated Security=true; TrustServerCertificate=True";
            SqlConnection con = new SqlConnection(connStr);

            Console.WriteLine("Enter products to delete : ");
            int eno = int.Parse(Console.ReadLine());

            string cmdText = $"DELETE FROM Emp WHERE Empno={eno}";
            SqlCommand cmd = new SqlCommand(cmdText, con);

            con.Open();

            // ExecuteNonQuery()  Returns int
            // no. of rows affected
            int n = cmd.ExecuteNonQuery();  // for DML Commands

            Console.WriteLine("Connected to SQL Server");
            Console.WriteLine("No. of Rows affected : " + n);

            con.Close();


            Console.ReadLine(); // Waiting the command prompt

        }
    }
}

