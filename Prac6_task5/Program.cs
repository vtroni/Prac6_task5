using System;
using System.IO;
using System.Text.Json;

class Product
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public double Price { get; set; }
    public int Quantity { get; set; }
}

class Program
{
    static void Main()
    {
        try
        {
            string json = File.ReadAllText("product.json");

            Product? product = JsonSerializer.Deserialize<Product>(json);

            if (product != null)
            {
                Console.WriteLine("Product information:");
                Console.WriteLine($"Id: {product.Id}");
                Console.WriteLine($"Name: {product.Name}");
                Console.WriteLine($"Price: {product.Price}");
                Console.WriteLine($"Quantity: {product.Quantity}");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Error: File not found.");
        }
        catch (JsonException)
        {
            Console.WriteLine("Error: Invalid JSON format.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}