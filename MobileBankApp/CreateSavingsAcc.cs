using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankApp
{
    public class CreateSavingsAcc : BankInfo, IBankTransactions
    {
        public CreateSavingsAcc()
        {

        }
        public CreateSavingsAcc(decimal amount, DateTime date, string comment)
            :base()
        {
            Deposite(amount, date, comment);
        }
        public void Deposite(decimal amount, DateTime date, string comment)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount cannot be 0 or less than 0");
            }

            var transaction = new BankTransaction(amount, date, comment);
            Transctions.Add(transaction);
           
        }

        public void WithDraw(decimal amount, DateTime date, string comment)
        {
            if (amount <= 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount cannot be 0 or less than 0");
            }

            if (Balance - amount <= 1000)
            {
                throw new InvalidOperationException("Insufficient Fund");
            }

            var transaction = new BankTransaction(-amount, date, comment);
            Transctions.Add(transaction);
            
        }

        public void TransferFund(decimal amount, DateTime date, string narration, CreateSavingsAcc account)
        {
            if (amount <= 1000)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount cannot be less than 1");
            }

            if (Balance - amount <= 1000)
            {
                throw new InvalidOperationException("Insufficient Fund");
            }

            var savingsTransact = new BankTransaction(-amount, date, narration);
            var currentTransact = new BankTransaction(amount, date, narration);

            Transctions.Add(savingsTransact);
            account.Transctions.Add(currentTransact);
        }
    }
}
