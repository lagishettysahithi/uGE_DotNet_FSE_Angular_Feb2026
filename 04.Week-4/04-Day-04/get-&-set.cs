
/*Assignment
 ~~~~~~~~~~~~~~
  
 Write  a  C# program to process product details using object oriented programming.
 
•	Class should contain private variables:  productId, productName, unitPrice, qty.
•	Constructor should allow productId as parameter
•	 Create properties for all private variables. Property Names :   ProductId, ProductName, UnitPrice, Quantity
•	ProductId – should be readonly property
•	ShowDetails()  method to display all the details along with total amount.
*/





using System.Xml.Linq;

namespace Student_Grade
{

    class Product
    {
        // Private variables
        private int productId;
        private string productName;
        private double unitPrice;
        private int qty;

        // Constructor with productId parameter
        public Product(int id)
        {
            productId = id;
        }

        // Readonly Property for ProductId
        public int ProductId
        {
            get { return productId; }
        }

        // Property for ProductName
        public string ProductName
        {
            get { return productName; }
            set { productName = value; }
        }

        // Property for UnitPrice
        public double UnitPrice
        {
            get { return unitPrice; }
            set { unitPrice = value; }
        }

        // Property for Quantity
        public int Quantity
        {
            get { return qty; }
            set { qty = value; }
        }

        // Method to show product details
        public void ShowDetails()
        {
            double total = unitPrice * qty;

            Console.WriteLine("Product Id: " + productId);
            Console.WriteLine("Product Name: " + productName);
            Console.WriteLine("Unit Price: " + unitPrice);
            Console.WriteLine("Quantity: " + qty);
            Console.WriteLine("Total Amount: " + total);
        }
    }

    class Program
    {
        static void Main()
        {
            int id;
            string name;
            double price;
            int quantity;

            Console.WriteLine("Enter Product Id:");
            id = int.Parse(Console.ReadLine());

            Product p = new Product(id);

            Console.WriteLine("Enter Product Name:");
            name = Console.ReadLine();
            p.ProductName = name;

            Console.WriteLine("Enter Unit Price:");
            price = double.Parse(Console.ReadLine());
            p.UnitPrice = price;

            Console.WriteLine("Enter Quantity:");
            quantity = int.Parse(Console.ReadLine());
            p.Quantity = quantity;

            Console.WriteLine("\nProduct Details:");
            p.ShowDetails();
        }
    }
