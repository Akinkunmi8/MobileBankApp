using NUnit.Framework;
using System;
using MobileBankApp;

namespace BankTestUnit
{
    public class Tests
    {
        [Test]
        public void CreateSavings()
        {
            var sut = new CreateSavingAcc();
            Assert.Pass();
        }
    }
}