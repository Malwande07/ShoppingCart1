using System;
using System.Collections.Generic;

class ShoppingCartItem
{
    public string Name { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}

class Program
{
    static List<ShoppingCartItem> cart = new List<ShoppingCartItem>();

    static void Main(string[] args)
    {
        bool continueShopping = true;
        while (continueShopping)
        {
            Console.WriteLine("Welcome to the Shopping Cart App!");
            Console.WriteLine("1. Add item to cart");
            Console.WriteLine("2. View cart");
            Console.WriteLine("3. Remove item from cart");
            Console.WriteLine("4. Calculate total");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    AddItemToCart();
                    break;
                case 2:
                    ViewCart();
                    break;
                case 3:
                    RemoveItemFromCart();
                    break;
                case 4:
                    CalculateTotal();
                    break;
                case 5:
                    continueShopping = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }
        }
    }

    static void AddItemToCart()
    {
        Console.Write("Enter item name: ");
        string itemName = Console.ReadLine();

        Console.Write("Enter item price: ");
        double itemPrice = double.Parse(Console.ReadLine());

        Console.Write("Enter quantity: ");
        int quantity = int.Parse(Console.ReadLine());

        cart.Add(new ShoppingCartItem { Name = itemName, Price = itemPrice, Quantity = quantity });
        Console.WriteLine("Item added to cart successfully!");
    }

    static void ViewCart()
    {
        Console.WriteLine("Your Cart:");
        foreach (var item in cart)
        {
            Console.WriteLine($"Name: {item.Name}, Price: {item.Price}, Quantity: {item.Quantity}");
        }
    }

    static void RemoveItemFromCart()
    {
        Console.Write("Enter the name of the item to remove: ");
        string itemName = Console.ReadLine();

        var itemToRemove = cart.Find(item => item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
        if (itemToRemove != null)
        {
            cart.Remove(itemToRemove);
            Console.WriteLine("Item removed from cart successfully!");
        }
        else
        {
            Console.WriteLine("Item not found in the cart.");
        }
    }

    static void CalculateTotal()
    {
        double total = 0;
        foreach (var item in cart)
        {
            total += item.Price * item.Quantity;
        }
        Console.WriteLine($"Total: {total}");
    }
}