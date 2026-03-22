using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Enter root directory path: ");
        string path = Console.ReadLine();

        try
        {
            // Check if directory exists
            if (!Directory.Exists(path))
            {
                Console.WriteLine(" Invalid directory path!");
                return;
            }

            // Create DirectoryInfo object
            DirectoryInfo root = new DirectoryInfo(path);

            // Get all subdirectories
            DirectoryInfo[] dirs = root.GetDirectories();

            foreach (DirectoryInfo dir in dirs)
            {
                // Get files inside each directory
                FileInfo[] files = dir.GetFiles();

                Console.WriteLine("Folder Name: " + dir.Name);
                Console.WriteLine("Number of Files: " + files.Length);
                Console.WriteLine("--------------------------");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(" Error: " + e.Message);
        }
    }
}