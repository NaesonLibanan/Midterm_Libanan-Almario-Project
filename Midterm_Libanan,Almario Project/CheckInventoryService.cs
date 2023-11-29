using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Libanan_Almario_Project
{
    internal class CheckInventoryService
    {
        public static void CheckInventory(Dictionary<int, Product> products)
        {
            Console.WriteLine("Current Inventory:");
            foreach (var kvp in products)
            {
                Console.WriteLine($"ID:{kvp.Key} Product: {kvp.Value.Name}, Price: {kvp.Value.Price}, Quantity: {kvp.Value.Quantity}, Category: {kvp.Value.Category}");
                Console.WriteLine();
            }
        }
    }
}