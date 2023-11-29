using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Libanan_Almario_Project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Inventory inventory = new Inventory();
            UserInput userInput = new UserInput(inventory);

            int choice;
            do
            {
                choice = userInput.ShowMenu();
                userInput.ExecuteChoice(choice);

            } while (choice != 0);

            Console.WriteLine("Exiting the program. Press Enter to close...");
            Console.ReadLine();
        }
    }
}