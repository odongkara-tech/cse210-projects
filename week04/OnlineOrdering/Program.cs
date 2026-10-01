using System;

class Program
{
    static void Main(string[] args)
    {
        Address domesticAddress = new Address("123 Main Street", "Rexburg", "Idaho", "USA");
        Customer domesticCustomer = new Customer("Jordan Lee", domesticAddress);
        Order domesticOrder = new Order(domesticCustomer);
        domesticOrder.AddProduct(new Product("Notebook", "NB-101", 4.50, 3));
        domesticOrder.AddProduct(new Product("Pen Set", "PS-205", 8.25, 2));

        Address internationalAddress = new Address("45 Oak Road", "London", "England", "United Kingdom");
        Customer internationalCustomer = new Customer("Alex Morgan", internationalAddress);
        Order internationalOrder = new Order(internationalCustomer);
        internationalOrder.AddProduct(new Product("Water Bottle", "WB-310", 18.00, 1));
        internationalOrder.AddProduct(new Product("Backpack", "BP-422", 42.50, 2));
        internationalOrder.AddProduct(new Product("Travel Mug", "TM-118", 12.75, 1));

        DisplayOrder(domesticOrder);
        DisplayOrder(internationalOrder);
    }

    private static void DisplayOrder(Order order)
    {
        Console.WriteLine("PACKING LABEL");
        Console.WriteLine(order.GetPackingLabel());
        Console.WriteLine("SHIPPING LABEL");
        Console.WriteLine(order.GetShippingLabel());
        Console.WriteLine($"TOTAL: ${order.GetTotalCost():F2}");
        Console.WriteLine();
    }
}