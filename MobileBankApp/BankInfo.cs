namespace MobileBankApp
{
    public class BankInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        private string mobileNumber;
        public string AccountNumber { get; }
        public string AccountType { get; set; }
        public List<BankTransaction> Transctions { get; set; }


        public BankInfo()
        {
            Transctions = new List<BankTransaction>();
            AccountNumber = AccountGenerator();
        }

        public string AccountName
        {

            get
            {
                return $"{AccountDetails.FirstCharacterUpper(FirstName)} {AccountDetails.FirstCharacterUpper(LastName)}";
            }
        }
        public decimal Balance
        {

            get
            {
                decimal balance = 0;
                foreach (var item in Transctions)
                {
                    balance += item.Amount;
                }
                return balance;
            }
        }
        public string MobileNumber
        {
            get
            {
                return mobileNumber;
            }
            set
            {
                if (value.Length == 11)
                {
                    mobileNumber = value;
                }
            }
        }
        private string AccountGenerator()
        {
            var random = new Random();
            string accountNumber = string.Empty;
            for (int i = 0; i < 10; i++)
            {
                accountNumber = String.Concat(accountNumber,random.Next(0, 10).ToString());
            }
            return accountNumber;
        }
    }
}
