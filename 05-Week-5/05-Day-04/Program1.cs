using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.Write("Enter folder path: ");
        string folderPath = Console.ReadLine();

        try
        {
            // Check if directory exists
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine(" Invalid folder path!");
                return;
            }

            // Get all files in the folder
            string[] files = Directory.GetFiles(folderPath);

            int count = 0;

            foreach (string file in files)
            {
                FileInfo info = new FileInfo(file);

                Console.WriteLine("File Name: " + info.Name);
                Console.WriteLine("Size (bytes): " + info.Length);
                Console.WriteLine("Created On: " + info.CreationTime);
                Console.WriteLine("------------------------");

                count++;
            }

            Console.WriteLine("Total Files: " + count);
        }
        catch (Exception e)
        {
            Console.WriteLine(" Error: " + e.Message);
        }
    }
}