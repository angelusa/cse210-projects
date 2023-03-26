using System;
using System.Collections.Generic;

//Declaring the classes
public class Product
{
    //Declaring private variables
    private string _name;
    private int _id;
    private double _price;
    private int _quantity;

    //Constructor
    public Product(string name, int id, double price, int quantity)
    {
        _name = name;
        _id = id;
        _price = price;
        _quantity = quantity;
    }

    //Getters and setters
    public string GetName()
    {
        return _name;
    }
    public int GetId()
    {
        return _id;
    }
    public double GetPrice()
    {
        return _price;
    }
    public int GetQuantity()
    {
        return _quantity;
    }
    public void SetName(string name)
    {
        _name = name;
    }
    public void SetId(int id)
    {
        _id = id;
    }
    public void SetPrice(double price)
    {
        _price = price;
    }
    public void SetQuantity(int quantity)
    {
        _quantity = quantity;
    }

    //Calculating the price of the product
    public double CalculatePrice()
    {
        return _price * _quantity;
    }

}

public class Customer
{
    //Declaring private variables
    private string _name;
    private Address _address;

    //Constructor
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    //Getters and setters
    public string GetName()
    {
        return _name;
    }
    public Address GetAddress()
    {
        return _address;
    }
    public void SetName(string name)
    {
        _name = name;
    }
    public void SetAddress(Address address)
    {
        _address = address;
    }

    //Checking if the customer is in the USA
    public bool IsUsaCustomer()
    {
        return _address.IsUsaAddress();
    }
}

public class Address
{
    //Declaring private variables
    private string _streetAddress;
    private string _city;
    private string _state;
    private string _country;

    //Constructor
    public Address(string streetAddress, string city, string state, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _state = state;
        _country = country;
    }

    //Getters and setters
    public string GetStreetAddress()
    {
        return _streetAddress;
    }
    public string GetCity()
    {
        return _city;
    }
    public string GetState()
    {
        return _state;
    }
    public string GetCountry()
    {
        return _country;
    }
    public void SetStreetAddress(string streetAddress)
    {
        _streetAddress = streetAddress;
    }
    public void SetCity(string city)
    {
        _city = city;
    }
    public void SetState(string state)
    {
        _state = state;
    }
    public void SetCountry(string country)
    {
        _country = country;
    }

    //Checking if the address is in the USA
    public bool IsUsaAddress()
    {
        if (_country == "USA")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Returning a string with all of the fields
    public string GetFullAddress()
    {
        return _streetAddress + "\n" + _city + ", " + _state + "\n" + _country;
    }
}

public class Order
{
    //Declaring private variables
    private List<Product> _products;
    private Customer _customer;

    //Constructor
    public Order(List<Product> products, Customer customer)
    {
        _products = products;
        _customer = customer;
    }

    //Getters and setters
    public List<Product> GetProducts()
    {
        return _products;
    }
    public Customer GetCustomer()
    {
        return _customer;
    }
    public void SetProducts(List<Product> products)
    {
        _products = products;
    }
    public void SetCustomer(Customer customer)
    {
        _customer = customer;
    }

    //Calculating the total cost of the order
    public double CalculatePrice()
    {
        double totalPrice = 0;
        foreach (Product product in _products)
        {
            totalPrice += product.CalculatePrice();
        }
        //Checking if the customer is in the USA
        if (_customer.IsUsaCustomer())
        {
            totalPrice += 5;
        }
        else
        {
            totalPrice += 35;
        }
        return totalPrice;
    }

    //Returning a string for packing label
    public string GetPackingLabel()
    {
        string packingLabel = "";
        foreach (Product product in _products)
        {
            packingLabel += product.GetName() + " (" + product.GetId() + ")\n";
        }
        return packingLabel;
    }

    //Returning a string for shipping label
    public string GetShippingLabel()
    {
        string shippingLabel = _customer.GetName() + "\n" + 
                               _customer.GetAddress().GetFullAddress();
        return shippingLabel;
    }
}

public class Program
{
        public static void Main()
        {
        //Creating the products
        Product product1 = new Product("Shirt", 1, 10.00, 2);
        Product product2 = new Product("Pants", 2, 20.00, 1);

        //Creating the customer
        Address address1 = new Address("123 Main Street", "Anytown", "CA", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        //Creating the orders
        List<Product> products1 = new List<Product> { product1, product2 };
        Order order1 = new Order(products1, customer1);

        //Printing the packing label, shipping label, and total cost of the order
        Console.WriteLine("Packing Label:\n" + order1.GetPackingLabel());
        Console.WriteLine("Shipping Label:\n" + order1.GetShippingLabel());
        Console.WriteLine("Total Cost: $" + order1.CalculatePrice());
    }
}
