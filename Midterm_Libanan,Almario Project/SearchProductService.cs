using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Libanan_Almario_Project
{
    internal class SearchProductService
    {
        public static void SearchProduct(Dictionary<int, Product> products)
        {
            Console.Write("Enter search term (product name or category): ");
            string searchTerm = Console.ReadLine();

            List<Product> searchResults = new List<Product>();

            // Search by product name or category
            foreach (var kvp in products)
            {
                if (kvp.Value.Name.ToLower().Contains(searchTerm.ToLower()) || kvp.Value.Category.ToLower().Contains(searchTerm.ToLower()))
                {
                    searchResults.Add(kvp.Value);
                }
            }

            if (searchResults.Count > 0)
            {
                Console.WriteLine("Search Results:");
                foreach (var product in searchResults)
                {
                    Console.WriteLine($"Product: {product.Name}, Price: {product.Price}, Quantity: {product.Quantity}, Category: {product.Category}");
                }
            }
            else
            {
                Console.WriteLine("No matching products found.");
            }
        }
    }
}