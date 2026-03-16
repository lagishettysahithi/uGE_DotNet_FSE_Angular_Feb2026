namespace Online_shopping_cart
{
      // Base Class
        class Product
        {
            private string name;
            private double price;

            // Properties
            public string Name
            {
                get => name;
                set => name = value;
            }

            public double Price
            {
                get => price;
                set
                {
                    if (value >= 0)
                        price = value;
                    else
                        Console.WriteLine("Price cannot be negative");
                }
            }

            // Constructor
            public Product(string name, double price)
            {
                Name = name;
                Price = price;
            }

            // Virtual Method
            public virtual double CalculateDiscount() => Price;
        }

        // Derived Class - Electronics
        class Electronics : Product
        {
            public Electronics(string name, double price) : base(name, price) { }

            public override double CalculateDiscount() => Price - (Price * 0.05);
        }

        // Derived Class - Clothing
        class Clothing : Product
        {
            public Clothing(string name, double price) : base(name, price) { }

            public override double CalculateDiscount() => Price - (Price * 0.15);
        }

        class Program
        {
            static void Main()
            {
                Console.Write("Enter Electronics Price: ");
                double price = Convert.ToDouble(Console.ReadLine());

                // Polymorphism
                Product item = new Electronics("Laptop", price);

                double finalPrice = item.CalculateDiscount();

                Console.WriteLine("Final Price after 5% discount = " + finalPrice);
            }
        }
    }