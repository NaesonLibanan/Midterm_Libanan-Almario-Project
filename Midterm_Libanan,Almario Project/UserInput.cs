using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Libanan_Almario_Project
{
    internal class UserInput
    {
        private Inventory Inventory;

        public UserInput(Inventory inventory)
        {
            Inventory = inventory;
        }

        public int ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("Inventory Management System");
            Console.WriteLine("[1] Check Inventory");
            Console.WriteLine("[2] Sell Product");
            Console.WriteLine("[3] Restock Product");
            Console.WriteLine("[4] Search Product");
            Console.WriteLine("[5] Show Transaction History");
            Console.WriteLine("[0] Exit");
            Console.Write("Enter your choice (0-5): ");

            string userInput = Console.ReadLine();

            if (int.TryParse(userInput, out int choice))
            {
                return choice;
            }
            else
            {
                Console.WriteLine("Invalid input. Press Enter to continue...");
                Console.ReadLine();
                return ShowMenu(); // Recursive call to show the menu again
            }
        }

        public void ExecuteChoice(int choice)
        {
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    Inventory.CheckInventory();
                    break;

                case 2:
                    Inventory.SellProduct();
                    break;

                case 3:
                    Inventory.RestockProduct();
                    break;

                case 4:
                    Inventory.SearchProduct();
                    Console.WriteLine("\nPress Enter to go back to the main menu...");
                    Console.ReadKey();
                    break;

                case 5:
                    Inventory.ShowTransactionHistory();
                    Console.WriteLine("\nPress Enter to go back to the main menu...");
                    Console.ReadKey();


                    break;

                case 0:
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid choice. Press Enter to continue...");
                    Console.ReadLine();
                    break;
            }
        }
    }
}