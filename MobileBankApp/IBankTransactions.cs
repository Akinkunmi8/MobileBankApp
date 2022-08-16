using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankApp
{
    public interface IBankTransactions
    {
        void Deposite(decimal amount,DateTime date,string comment);
        void WithDraw(decimal amount,DateTime date,string comment);
        
    }
}
