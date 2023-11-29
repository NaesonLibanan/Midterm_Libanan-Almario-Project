using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Libanan_Almario_Project
{
    internal class SellProductService
    {
        public static void SellProduct(Dictionary<int, Product> products, List<string> transactionHistory, int receiptNumber)
        {
            Console.Clear();
            CheckInventoryService.CheckInventory(products);

            Console.Write("Enter product ID to sell: ");
            if (int.TryParse(Console.ReadLine(), out int productId))
            {
                if (products.ContainsKey(productId))
                {
                    Console.Write("Enter quantity to sell: ");
                    if (int.TryParse(Console.ReadLine(), out int sellQuantity))
                    {
                        Product product = products[productId];

                        if (sellQuantity <= product.Quantity)
                        {
                            double totalAmount = sellQuantity * product.Price;

                            Console.WriteLine($"Total Amount: {totalAmount:C}");

                            product.Quantity -= sellQuantity;
                            Console.ReadKey();

                            // Generate receipt and log transaction
                            GenerateReceipt(product, sellQuantity, transactionHistory, ref receiptNumber);

                            Console.WriteLine($"Sold {sellQuantity} {product.Name}(s). Updated inventory:");
                            Console.WriteLine(product.GetProductInfo());

                            // Write the updated inventory back to the CSV file
                            WriteInventoryToCSV(products);
                        }
                        else
                        {
                            Console.WriteLine($"Error: Sell quantity exceeds available quantity ({product.Quantity}).");
                        }
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
                Console.WriteLine("Invalid product ID. Please enter a valid number.");
            }
        }



        private static void GenerateReceipt(Product product, int sellQuantity, List<string> transactionHistory, ref int receiptNumber)
        {
            string receiptContent = $"Receipt: {receiptNumber}, Product: {product.Name}, Quantity: {sellQuantity}, Price: {product.Price:C}, Category: {product.Category}";

            transactionHistory.Add(receiptContent);
            receiptNumber++;
            SaveReceiptToFile(receiptContent);

            // Save the updated transaction history to the file
            SaveTransactionHistoryToFile(transactionHistory);
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
        private static void SaveReceiptToFile(string receiptContent)
        {
            string receiptFileName = $"Receipt_{DateTime.Now:yyyyMMdd_HHmmss}.txt";

            try
            {
                // Write the receipt content to a new file
                File.WriteAllText(receiptFileName, receiptContent);
                Console.WriteLine($"Receipt saved to {receiptFileName}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving receipt to file: {ex.Message}");
            }
        }
        private static void SaveTransactionHistoryToFile(List<string> transactionHistory)
        {
            string transactionHistoryFilePath = "transaction_history.txt";

            try
            {
                // Write the updated transaction history to the file
                File.WriteAllLines(transactionHistoryFilePath, transactionHistory);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving transaction history to file: {ex.Message}");
            }
        }
    }
}