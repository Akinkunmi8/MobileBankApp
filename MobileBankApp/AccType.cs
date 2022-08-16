using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankApp
{
    public class AccType
    {
        public List<CreateSavingsAcc> savings { get; set; } = new List<CreateSavingsAcc>();
        public List<CreateCurrentAcc> currents { get; set; } = new List<CreateCurrentAcc>();
    }

}

