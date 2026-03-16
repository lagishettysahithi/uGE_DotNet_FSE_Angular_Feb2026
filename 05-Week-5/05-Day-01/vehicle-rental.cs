namespace Vechicle_Rental
{
    // Base Class
    class Vehicle
    {
        private string brand;
        private double rentalRatePerDay;

        // Properties
        public string Brand
        {
            get => brand;
            set => brand = value;
        }

        public double RentalRatePerDay
        {
            get => rentalRatePerDay;
            set
            {
                if (value >= 0)
                    rentalRatePerDay = value;
                else
                    Console.WriteLine("Invalid rental rate");
            }
        }

        // Constructor
        public Vehicle(string brand, double rate)
        {
            Brand = brand;
            RentalRatePerDay = rate;
        }

        // Virtual Method
        public virtual double CalculateRental(int days) => RentalRatePerDay * days;
    }

    // Derived Class - Car
    class Car : Vehicle
    {
        public Car(string brand, double rate) : base(brand, rate) { }

        public override double CalculateRental(int days)
        {
            if (days <= 0)
            {
                Console.WriteLine("Invalid number of days");
                return 0;
            }

            double total = RentalRatePerDay * days;
            return total + 500; // Insurance charge
        }
    }

    // Derived Class - Bike
    class Bike : Vehicle
    {
        public Bike(string brand, double rate) : base(brand, rate) { }

        public override double CalculateRental(int days)
        {
            if (days <= 0)
            {
                Console.WriteLine("Invalid number of days");
                return 0;
            }

            double total = RentalRatePerDay * days;
            return total - (total * 0.05); // 5% discount
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Enter Car Rental Rate Per Day: ");
            double rate = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Number of Days: ");
            int days = Convert.ToInt32(Console.ReadLine());

            // Runtime Polymorphism
            Vehicle vehicle = new Car("Toyota", rate);

            double total = vehicle.CalculateRental(days);

            Console.WriteLine("Total Rental = " + total);
        }
    }
}
