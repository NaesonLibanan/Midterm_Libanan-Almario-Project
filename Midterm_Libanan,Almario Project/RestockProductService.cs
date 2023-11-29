using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Libanan_Almario_Project
{
    internal class RestockProductService
    {

        public static void RestockProduct(Dictionary<int, Product> products)
        {
            Console.WriteLine("Do you want to restock an existing product or add a new one?");
            Console.WriteLine("1. Restock existing product");
            Console.WriteLine("2. Add a new product");
            Console.Write("Enter your choice (1 or 2): ");

            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                switch (choice)
                {
                    case 1:
                        CheckInventoryService.CheckInventory(products); // Display existing inventory
                        Console.Write("Enter the ID of the product to restock: ");
                        if (int.TryParse(Console.ReadLine(), out int productId))
                        {
                            if (products.ContainsKey(productId))
                            {
                                Console.Write("Enter the quantity to restock: ");
                                if (int.TryParse(Console.ReadLine(), out int restockQuantity))
                                {
                                    products[productId].Quantity += restockQuantity;
                                    Console.WriteLine($"{products[productId].Name} successfully restocked. Updated quantity: {products[productId].Quantity}");

                                    // Log the restock transaction
                                    LogRestockTransaction(products[productId], restockQuantity);

                                    // Write the updated inventory back to the CSV file
                                    WriteInventoryToCSV(products);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid quantity. Please enter a valid number.");
                                }
                            }
                            else
                            {
                                Console.WriteLine($"Error: Product with ID {productId} not found in the inventory.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter a number.");
                        }
                        break;

                    case 2:
                        Product newProduct = GetUserInputForProduct();

                        if (newProduct != null)
                        {
                            products.Add(products.Count + 1, newProduct);
                            Console.WriteLine($"{newProduct.Name} added to the inventory.");

                            // Write the updated inventory back to the CSV file
                            WriteInventoryToCSV(products);
                        }
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter 1 or 2.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                Console.ReadKey();
            }
        }

        private static Product GetUserInputForProduct()
        {
            Console.Write("Enter the name of the product: ");
            string name = Console.ReadLine();

            Console.Write("Enter the price of the product: ");
            if (double.TryParse(Console.ReadLine(), out double price))
            {
                Console.Write("Enter the quantity of the product: ");
                if (int.TryParse(Console.ReadLine(), out int quantity))
                {
                    Console.Write("Enter the category of the product: ");
                    string category = Console.ReadLine();

                    Product newProduct = new Product
                    {
                        Name = name,
                        Price = price,
                        Quantity = quantity,
                        Category = category
                    };

                    return newProduct;
                }
                else
                {
                    Console.WriteLine("Invalid quantity. Please enter a valid number.");
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("Invalid price. Please enter a valid number.");
                Console.ReadKey();
            }

            return null;
        }

        private static void LogRestockTransaction(Product product, int restockQuantity)
        {
            string transactionContent = $"Restocked {restockQuantity} {product.Name}(s). Updated inventory: {product.GetProductInfo()}";
            Console.WriteLine(transactionContent);
        }

        private static void WriteInventoryToCSV(Dictionary<int, Product> products)
        {
            // Write the updated inventory back to the CSV file
            using (StreamWriter sw = new StreamWriter("inventory.txt"))
            {
                foreach (var kvp in products)
                {
                    sw.WriteLine($"{kvp.Value.Name},{kvp.Value.Price},{kvp.Value.Quantity},{kvp.Value.Category}");
                }
            }
        }
    }
}
