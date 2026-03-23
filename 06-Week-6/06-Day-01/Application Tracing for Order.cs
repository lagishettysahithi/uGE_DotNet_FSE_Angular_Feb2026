using System;
using System.Diagnostics;
using System.IO;

class Program
{
    static void Main()
    {
        // Configure Trace to write logs into a file
        Trace.Listeners.Clear();
        Trace.Listeners.Add(new TextWriterTraceListener("OrderLog.txt"));
        Trace.AutoFlush = true;

        Console.WriteLine("Order Processing Started...\n");

        try
        {
            ValidateOrder();
            ProcessPayment();
            UpdateInventory();
            GenerateInvoice();

            Trace.TraceInformation("Order processed successfully.");
        }
        catch (Exception ex)
        {
            Trace.WriteLine("ERROR: " + ex.Message);
        }

        Console.WriteLine("Processing Completed. Check OrderLog.txt for trace logs.");
    }

    static void ValidateOrder()
    {
        Trace.WriteLine("Step 1: Validating Order...");
        // Simulate validation
        Trace.TraceInformation("Order validation successful.");
    }

    static void ProcessPayment()
    {
        Trace.WriteLine("Step 2: Processing Payment...");
        // Simulate payment
        Trace.TraceInformation("Payment processed successfully.");
    }

    static void UpdateInventory()
    {
        Trace.WriteLine("Step 3: Updating Inventory...");
        // Simulate inventory update
        Trace.TraceInformation("Inventory updated successfully.");
    }

    static void GenerateInvoice()
    {
        Trace.WriteLine("Step 4: Generating Invoice...");
        // Simulate invoice generation
        Trace.TraceInformation("Invoice generated successfully.");
    }
}