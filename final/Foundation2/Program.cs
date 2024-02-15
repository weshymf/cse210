using System;
using System.Collections.Generic;

public class Order
{
    private List<Product> products;
    private Customer customer;

    // Constructor
    public Order(Customer customer)
    {
        this.customer = customer;
        products = new List<Product>();
    }

    // Method to add a product to the order
    public void AddProduct(Product product)
    {
        products.Add(product);
    }

    // Method to calculate the total cost of the order
    public double CalculateTotalCost()
    {
        double totalCost = 0;
        foreach (var product in products)
        {
            totalCost += product.Price * product.Quantity;
        }

        // Add shipping cost
        if (customer.IsInUSA())
            totalCost += 5;
        else
            totalCost += 35;

        return totalCost;
    }

    // Method to generate packing label
    public string GeneratePackingLabel()
    {
        string packingLabel = "Packing Label:\n";
        foreach (var product in products)
        {
            packingLabel += $"Product: {product.Name}, ID: {product.ProductId}\n";
        }
        return packingLabel;
    }

    // Method to generate shipping label
    public string GenerateShippingLabel()
    {
        string shippingLabel = "Shipping Label:\n";
        shippingLabel += $"Customer: {customer.Name}\n";
        shippingLabel += $"Address: {customer.Address.GetFullAddress()}";
        return shippingLabel;
    }
}

public class Product
{
    private string name;
    private string productId;
    private double price;
    private int quantity;

    // Constructor
    public Product(string name, string productId, double price, int quantity)
    {
        this.name = name;
        this.productId = productId;
        this.price = price;
        this.quantity = quantity;
    }

    // Properties
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string ProductId
    {
        get { return productId; }
        set { productId = value; }
    }

    public double Price
    {
        get { return price; }
        set { price = value; }
    }

    public int Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }
}

public class Customer
{
    private string name;
    private Address address;

    // Constructor
    public Customer(string name, Address address)
    {
        this.name = name;
        this.address = address;
    }

    // Method to check if the customer is in the USA
    public bool IsInUSA()
    {
        return address.IsInUSA();
    }

    // Properties
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public Address Address
    {
        get { return address; }
        set { address = value; }
    }
}

public class Address
{
    private string streetAddress;
    private string city;
    private string stateProvince;
    private string country;

    // Constructor
    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        this.streetAddress = streetAddress;
        this.city = city;
        this.stateProvince = stateProvince;
        this.country = country;
    }

    // Method to check if the address is in the USA
    public bool IsInUSA()
    {
        return country.ToLower() == "usa";
    }

    // Method to get full address
    public string GetFullAddress()
    {
        return $"{streetAddress}, {city}, {stateProvince}, {country}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create address
        Address address1 = new Address("123 Main St", "Anytown", "CA", "USA");

        // Create customer
        Customer customer1 = new Customer("John Doe", address1);

        // Create products
        Product product1 = new Product("Product 1", "P1", 10, 2);
        Product product2 = new Product("Product 2", "P2", 15, 1);

        // Create order
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        // Display packing and shipping labels and total cost
        Console.WriteLine(order1.GeneratePackingLabel());
        Console.WriteLine(order1.GenerateShippingLabel());
        Console.WriteLine("Total Cost: $" + order1.CalculateTotalCost());
    }
}
