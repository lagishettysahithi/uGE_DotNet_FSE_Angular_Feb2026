using System;
using System.Collections.Generic;
using System.Linq;
namespace ConsoleApp1
{
    class Product
    {
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }
        public double Mrp { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>()
            {
                new Product{ ProductCode=101, ProductName="Soap", Category="FMCG", Mrp=25 },
                new Product{ ProductCode=102, ProductName="Rice", Category="Grain", Mrp=50 },
                new Product{ ProductCode=103, ProductName="Oil", Category="FMCG", Mrp=120 },
                new Product{ ProductCode=104, ProductName="Wheat", Category="Grain", Mrp=40 },
                new Product{ ProductCode=105, ProductName="Shampoo", Category="FMCG", Mrp=60 }
            };

            // 1. FMCG products (Query Syntax)
            var result1 = from p in products
                          where p.Category == "FMCG"
                          select p;

            Console.WriteLine("\n1. FMCG Products:");
            foreach (var p in result1)
                Console.WriteLine(p.ProductName);

            // 2. Grain products (Query Syntax)
            var result2 = from p in products
                          where p.Category == "Grain"
                          select p;

            Console.WriteLine("\n2. Grain Products:");
            foreach (var p in result2)
                Console.WriteLine(p.ProductName);

            // 3. Sort by ProductCode
            var result3 = from p in products
                          orderby p.ProductCode ascending
                          select p;

            Console.WriteLine("\n3. Sort by ProductCode:");
            foreach (var p in result3)
                Console.WriteLine(p.ProductCode + " " + p.ProductName);

            // 4. Sort by Category
            var result4 = from p in products
                          orderby p.Category ascending
                          select p;

            Console.WriteLine("\n4. Sort by Category:");
            foreach (var p in result4)
                Console.WriteLine(p.Category + " " + p.ProductName);

            // 5. Sort by MRP Ascending
            var result5 = from p in products
                          orderby p.Mrp ascending
                          select p;

            Console.WriteLine("\n5. Sort by MRP Asc:");
            foreach (var p in result5)
                Console.WriteLine(p.ProductName + " " + p.Mrp);

            // 6. Sort by MRP Descending
            var result6 = from p in products
                          orderby p.Mrp descending
                          select p;

            Console.WriteLine("\n6. Sort by MRP Desc:");
            foreach (var p in result6)
                Console.WriteLine(p.ProductName + " " + p.Mrp);

            // 7. Group by Category
            var result7 = from p in products
                          group p by p.Category;

            Console.WriteLine("\n7. Group by Category:");
            foreach (var group in result7)
            {
                Console.WriteLine("Category: " + group.Key);
                foreach (var p in group)
                    Console.WriteLine("  " + p.ProductName);
            }

            // 8. Group by MRP (Method)
            var result8 = products.GroupBy(p => p.Mrp);

            Console.WriteLine("\n8. Group by MRP:");
            foreach (var group in result8)
            {
                Console.WriteLine("MRP: " + group.Key);
                foreach (var p in group)
                    Console.WriteLine("  " + p.ProductName);
            }

            // 9. Highest price in FMCG
            var result9 = products
                          .Where(p => p.Category == "FMCG")
                          .OrderByDescending(p => p.Mrp)
                          .FirstOrDefault();

            Console.WriteLine("\n9. Highest FMCG Product:");
            Console.WriteLine(result9.ProductName + " " + result9.Mrp);

            // 10. Count total products
            var result10 = products.Count();
            Console.WriteLine("\n10. Total Products: " + result10);

            // 11. Count FMCG products
            var result11 = products.Count(p => p.Category == "FMCG");
            Console.WriteLine("\n11. FMCG Count: " + result11);

            // 12. Max price
            var result12 = products.Max(p => p.Mrp);
            Console.WriteLine("\n12. Max Price: " + result12);

            // 13. Min price
            var result13 = products.Min(p => p.Mrp);
            Console.WriteLine("\n13. Min Price: " + result13);

            // 14. All below 30
            var result14 = products.All(p => p.Mrp < 30);
            Console.WriteLine("\n14. All below 30: " + result14);

            // 15. Any below 30
            var result15 = products.Any(p => p.Mrp < 30);
            Console.WriteLine("\n15. Any below 30: " + result15);
        }
    }
}