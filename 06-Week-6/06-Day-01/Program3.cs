using System;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    static void Main()
    {
        Console.WriteLine("Starting Report Generation...\n");

        // Run tasks concurrently
        Task task1 = Task.Run(() => GenerateSalesReport());
        Task task2 = Task.Run(() => GenerateInventoryReport());
        Task task3 = Task.Run(() => GenerateCustomerReport());

        // Wait for all tasks to complete
        Task.WaitAll(task1, task2, task3);

        Console.WriteLine("\nAll reports generated successfully.");
    }

    static void GenerateSalesReport()
    {
        Console.WriteLine("Sales Report Started...");
        Thread.Sleep(2000); // Simulate processing
        Console.WriteLine("Sales Report Completed.");
    }

    static void GenerateInventoryReport()
    {
        Console.WriteLine("Inventory Report Started...");
        Thread.Sleep(3000); // Simulate processing
        Console.WriteLine("Inventory Report Completed.");
    }

    static void GenerateCustomerReport()
    {
        Console.WriteLine("Customer Report Started...");
        Thread.Sleep(2500); // Simulate processing
        Console.WriteLine("Customer Report Completed.");
    }
}