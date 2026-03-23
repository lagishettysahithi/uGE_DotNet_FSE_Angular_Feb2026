using System;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Application Started...\n");

            // Call async logging multiple times
            Task log1 = WriteLogAsync("User logged in");
            Task log2 = WriteLogAsync("File uploaded");
            Task log3 = WriteLogAsync("Data processed");

            Console.WriteLine("Logging in progress...\n");

            // Main thread continues working
            for (int i = 1; i <= 3; i++)
            {
                Console.WriteLine($"Main thread working... {i}");
                await Task.Delay(1000);
            }

            // Wait for all logs to complete
            await Task.WhenAll(log1, log2, log3);

            Console.WriteLine("\nAll logs written successfully.");
        }

        // Asynchronous method
        static async Task WriteLogAsync(string message)
        {
            Console.WriteLine($"Start writing log: {message}");

            // Simulate file writing delay
            await Task.Delay(2000);

            Console.WriteLine($"Finished writing log: {message}");
        }
    }
}