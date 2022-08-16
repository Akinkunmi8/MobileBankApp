using MobileBankApp;
namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void DepositTest()
        {
            var sut = new CreateSavingsAcc();
            sut.Deposite(1000, DateTime.Now, "Initial Deposit");
            Assert.That(sut.Balance, Is.EqualTo(1000));
        }

        [Test]
        public void DepositTestError()
        {
            var sut = new CreateSavingsAcc();
            Assert.That(() => sut.Deposite(900, DateTime.Now, "initial Deposit"), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WithdrawalTest()
        {
            var sut = new CreateSavingsAcc();
            Assert.That(() => sut.WithDraw(999, DateTime.Now, "initial Deposit"), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WithdrawaInvalid()
        {
            var sut = new CreateSavingsAcc();
            Assert.That(() => sut.WithDraw(-1000, DateTime.Now, "initial Deposit"), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
        [Test]
        public void TranferValid()
        {
            var sut1 = new CreateSavingsAcc(15000, DateTime.Now, "initial Deposit");
            var sut2 = new CreateSavingsAcc(30000, DateTime.Now, "initial Deposit");
            sut2.TransferFund(2000, DateTime.Now, "Transfer", sut1);
            Assert.That(() => sut1.Balance, Is.EqualTo(17000));
        }
        [Test]
        public void TranferInValid()
        {
            var sut1 = new CreateSavingsAcc(15000, DateTime.Now, "initial Deposit");
            var sut2 = new CreateSavingsAcc(30000, DateTime.Now, "initial Deposit");
            
            Assert.That(() => sut2.TransferFund(-2000, DateTime.Now, "Transfer", sut1), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void DepositTest2()
        {
            var sut = new CreateCurrentAcc();
            sut.Deposite(1000, DateTime.Now, "Initia Deposite");
            Assert.That(sut.Balance, Is.EqualTo(1000));
        }
        [Test]
        public void ErrorDepositTest2()
        {
            var sut = new CreateCurrentAcc();
            Assert.That(() => sut.Deposite(-1000, DateTime.Now,"Initia Deposite"), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
        [Test]
        public void WithDrawTest2()
        {
            var sut = new CreateCurrentAcc();
            Assert.That(() => sut.WithDraw(-1000, DateTime.Now, "First withdraw"), Throws.TypeOf<ArgumentOutOfRangeException>());
        }
        [Test]
        public void TranferValidTest()
        {
            var sut2 = new CreateCurrentAcc(5000, DateTime.Now, " Sender Account");
            var sut3 = new CreateSavingsAcc(4000, DateTime.Now, "Receiver Account");
            sut2.TransferFund(3000, DateTime.Now, "First Transfer",sut3);
            Assert.That(() => sut3.Balance, Is.EqualTo(7000));
        }
    }
}