using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankApp
{
    public class BankTransaction
    {
        public decimal Amount { get; }
        public DateTime Date { get; }
        public string Comment { get; }

        public BankTransaction(decimal amount, DateTime date, string comment)
        {
            Amount = amount;
            Date = date;
            Comment = comment;
        }
    }
}
