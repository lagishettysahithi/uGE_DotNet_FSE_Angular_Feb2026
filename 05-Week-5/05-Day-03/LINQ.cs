using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqAllInOne
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
                new Product{ ProductCode=103, ProductName="Shampoo", Category="FMCG", Mrp=120 },
                new Product{ ProductCode=104, ProductName="Wheat", Category="Grain", Mrp=40 },
                new Product{ ProductCode=105, ProductName="Oil", Category="FMCG", Mrp=150 }
            };

            // 1. FMCG Products
            Console.WriteLine("\nFMCG Products:");
            var result1 = products.Where(p => p.Category == "FMCG");
            foreach (var item in result1)
                Console.WriteLine(item.ProductName + " - " + item.Mrp);

            // 2. Grain Products
            Console.WriteLine("\nGrain Products:");
            var result2 = products.Where(p => p.Category == "Grain");
            foreach (var item in result2)
                Console.WriteLine(item.ProductName + " - " + item.Mrp);

            // 3. Sort by Product Code
            Console.WriteLine("\nSorted by Product Code:");
            var result3 = products.OrderBy(p => p.ProductCode);
            foreach (var item in result3)
                Console.WriteLine(item.ProductCode + " - " + item.ProductName);

            // 4. Sort by Category
            Console.WriteLine("\nSorted by Category:");
            var result4 = products.OrderBy(p => p.Category);
            foreach (var item in result4)
                Console.WriteLine(item.Category + " - " + item.ProductName);

            // 5. Sort by MRP (Ascending)
            Console.WriteLine("\nMRP Ascending:");
            var result5 = products.OrderBy(p => p.Mrp);
            foreach (var item in result5)
                Console.WriteLine(item.ProductName + " - " + item.Mrp);

            // 6. Sort by MRP (Descending)
            Console.WriteLine("\nMRP Descending:");
            var result6 = products.OrderByDescending(p => p.Mrp);
            foreach (var item in result6)
                Console.WriteLine(item.ProductName + " - " + item.Mrp);

            // 7. Group by Category
            Console.WriteLine("\nGroup by Category:");
            var result7 = products.GroupBy(p => p.Category);
            foreach (var group in result7)
            {
                Console.WriteLine("Category: " + group.Key);
                foreach (var item in group)
                    Console.WriteLine(item.ProductName + " - " + item.Mrp);
            }

            // 8. Group by MRP
            Console.WriteLine("\nGroup by MRP:");
            var result8 = products.GroupBy(p => p.Mrp);
            foreach (var group in result8)
            {
                Console.WriteLine("MRP: " + group.Key);
                foreach (var item in group)
                    Console.WriteLine(item.ProductName);
            }

            // 9. Highest Price in FMCG
            Console.WriteLine("\nHighest Price in FMCG:");
            var result9 = products
                .Where(p => p.Category == "FMCG")
                .OrderByDescending(p => p.Mrp)
                .FirstOrDefault();
            Console.WriteLine(result9.ProductName + " - " + result9.Mrp);

            // 10. Total Count
            Console.WriteLine("\nTotal Products:");
            Console.WriteLine(products.Count());

            // 11. FMCG Count
            Console.WriteLine("\nFMCG Count:");
            Console.WriteLine(products.Count(p => p.Category == "FMCG"));

            // 12. Max Price
            Console.WriteLine("\nMax Price:");
            Console.WriteLine(products.Max(p => p.Mrp));

            // 13. Min Price
            Console.WriteLine("\nMin Price:");
            Console.WriteLine(products.Min(p => p.Mrp));

            // 14. All products below 30?
            Console.WriteLine("\nAll products below 30:");
            Console.WriteLine(products.All(p => p.Mrp < 30));

            // 15. Any product below 30?
            Console.WriteLine("\nAny product below 30:");
            Console.WriteLine(products.Any(p => p.Mrp < 30));
        }
    }
}