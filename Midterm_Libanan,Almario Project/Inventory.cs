using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Libanan_Almario_Project
{
    internal class Inventory
    {
        private string filePath = "inventory.txt";
        private Dictionary<int, Product> products;
        private List<string> transactionHistory;
        private int receiptNumber = 1;

        public Inventory()
        {
            products = new Dictionary<int, Product>();
            transactionHistory = new List<string>();
            ReadInventoryFromCSV();

        }


        public void ReadInventoryFromCSV()
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    int id = 1;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine($"Reading line: {line}");

                        string[] data = line.Split(',');

                        if (data.Length == 4)
                        {
                            try
                            {
                                Product product = new Product
                                {
                                    Name = data[0],
                                    Price = double.Parse(data[1]),
                                    Quantity = int.Parse(data[2]),
                                    Category = data[3]
                                };

                                products.Add(id, product);
                                id++;
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error parsing line: {line}");
                                Console.WriteLine(ex.Message);

                            }
                        }
                        else
                        {
                            Console.WriteLine($"Invalid data format in line: {line}");
                        }
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File not found: {filePath}");
            }
        }

        public void CheckInventory()
        {
            CheckInventoryService.CheckInventory(products);
            Console.WriteLine("\nPress Enter to go back to the main menu...");
            Console.ReadKey();
        }




        public void SellProduct()
        {
            SellProductService.SellProduct(products, transactionHistory, receiptNumber);
        }

        public void RestockProduct()
        {
            RestockProductService.RestockProduct(products);
        }

        public void SearchProduct()
        {
            SearchProductService.SearchProduct(products);
        }

        public void ShowTransactionHistory()
        {
            ShowTransactionHistoryService.ShowTransactionHistory(transactionHistory);
            Console.WriteLine("\nPress Enter to go back to the main menu...");
            Console.ReadKey();


        }
    }
}
