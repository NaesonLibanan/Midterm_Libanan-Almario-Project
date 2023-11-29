using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Midterm_Libanan_Almario_Project
{
    internal class ShowTransactionHistoryService
    {
        public static void ShowTransactionHistory(List<string> transactionHistory)
        {
            Console.WriteLine("Transaction History:");
            foreach (string transaction in transactionHistory)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}