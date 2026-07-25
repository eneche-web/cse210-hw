using System;
using System.Net;

class Program
{
    static void Main(string[] args)
    {
        Address address1 = new Address(
            "370 Milan Street", "New York", "NY", "USA"
        );

        Customer customer1 = new Customer("Eneche John", address1);

        Order order1 = new Order(customer1);

        order1.AddProduct(new Product("Laptop", "P101", 850.00, 1));
        order1.AddProduct(new Product("External Hard Drive", "P102", 90.00,  2));
        order1.AddProduct(new Product("Wireless Mouse", "P103", 40.00, 3));


        Address address2 = new Address(
            "70 Maitama Sule Street",
            "Abuja Municipal Area",
            "Abuja Nigeria",
            "Nigeria"
        );

        Customer customer2 = new Customer("Barri White", address2);

        Order order2 = new Order(customer2);

        order2.AddProduct(new Product("Back Pack", "P201", 70.00, 1));
        order2.AddProduct(new Product("IPad", "P202", 250.00, 2));
        order2.AddProduct(new Product("Screen Protector", "P203", 65.00, 3));



        Console.WriteLine("==============================");
        Console.WriteLine("ORDER1");

        Console.WriteLine("===============================");

        Console.WriteLine("\nPacking Label:");
        Console.WriteLine("order1.GetPackingLabel:");
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"\nTotal Cost: ${order1.CalculateTotalCost}: F2");



        Console.WriteLine("=================================");
        Console.WriteLine("order2");

        Console.WriteLine("=================================");

        Console.WriteLine("\nPacking Label:");
        Console.WriteLine("order2.GetPackingLabel:");
        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"\nTotal Cost: ${order2.CalculateTotalCost}: F2");

    }
}