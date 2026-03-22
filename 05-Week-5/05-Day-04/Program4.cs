using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
            // Get all drives
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo drive in drives)
            {
                // Check if drive is ready
                if (drive.IsReady)
                {
                    Console.WriteLine("Drive Name: " + drive.Name);
                    Console.WriteLine("Drive Type: " + drive.DriveType);

                    // Convert bytes to GB
                    double totalSize = drive.TotalSize / (1024.0 * 1024 * 1024);
                    double freeSpace = drive.AvailableFreeSpace / (1024.0 * 1024 * 1024);

                    Console.WriteLine("Total Size (GB): " + totalSize);
                    Console.WriteLine("Free Space (GB): " + freeSpace);

                    // Calculate free space percentage
                    double percentFree = (freeSpace / totalSize) * 100;

                    Console.WriteLine("Free Space (%): " + percentFree);

                    // Warning if less than 15%
                    if (percentFree < 15)
                    {
                        Console.WriteLine("Warning: Low Disk Space!");
                    }

                    Console.WriteLine("----------------------------");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(" Error: " + e.Message);
        }
    }
}