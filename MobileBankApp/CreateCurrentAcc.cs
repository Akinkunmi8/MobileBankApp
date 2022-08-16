using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankApp
{
    public class CreateCurrentAcc : BankInfo, IBankTransactions
    {
        public CreateCurrentAcc()
        {

        }

        public CreateCurrentAcc(decimal amount, DateTime date, string comment)
            : base()
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
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount cannot be 0 or less than 0");
            }

            if (Balance - amount < 0)
            {
                throw new InvalidOperationException("Insufficient Fund");
            }

            var transaction = new BankTransaction(-amount, date, comment);
            Transctions.Add(transaction);

        }
        public void TransferFund(decimal amount, DateTime date, string comment, CreateSavingsAcc account)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount cannot be less than 1");
            }

            if (Balance - amount <= 1000)
            {
                throw new InvalidOperationException("Insufficient Fund");
            }

            var savingsTransact = new BankTransaction(-amount, date, comment);
            var currentTransact = new BankTransaction(amount, date, comment);

            Transctions.Add(savingsTransact);
            account.Transctions.Add(currentTransact);
        }
    }
}
