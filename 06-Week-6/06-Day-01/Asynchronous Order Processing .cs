using System;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("Order Processing Started...\n");

        await ProcessOrderAsync();

        Console.WriteLine("\nOrder Processing Completed Successfully.");
    }

    static async Task ProcessOrderAsync()
    {
        // Step 1: Verify Payment
        await VerifyPaymentAsync();

        // Step 2: Check Inventory
        await CheckInventoryAsync();

        // Step 3: Confirm Order
        await ConfirmOrderAsync();
    }

    static async Task VerifyPaymentAsync()
    {
        Console.WriteLine("Verifying payment...");
        await Task.Delay(2000); // Simulate delay
        Console.WriteLine("Payment verified.");
    }

    static async Task CheckInventoryAsync()
    {
        Console.WriteLine("Checking inventory...");
        await Task.Delay(3000); // Simulate delay
        Console.WriteLine("Inventory available.");
    }

    static async Task ConfirmOrderAsync()
    {
        Console.WriteLine("Confirming order...");
        await Task.Delay(1500); // Simulate delay
        Console.WriteLine("Order confirmed.");
    }
}