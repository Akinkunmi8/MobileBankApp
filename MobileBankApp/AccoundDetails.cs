using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace MobileBankApp
{
    public class AccountDetails
    {
      
        public static AccType AccountInfo() 
        {
            List<CreateSavingsAcc> savings = new List<CreateSavingsAcc>();
            List<CreateCurrentAcc> current = new List<CreateCurrentAcc>();
            string? firstName = string.Empty;
            string? lastName = string.Empty;
            string? email = string.Empty;
            string? phoneNumber = string.Empty;
            string? input = string.Empty;
            decimal amount = 0;
            string[] yesOrNo = { "yes", "no" };
            var type = string.Empty;


            Console.WriteLine("***********************************Welcome To AKIN MOBILE Bank APP SYSTEM********************************");

            while (true)
            {
                Options1();
                input = Console.ReadLine();

                while (true)
                {
                    Console.Write("Enter your firstname:  ");
                    firstName = Console.ReadLine().Trim();

                    if (ValidateName(firstName))
                        break;
                }

                while (true)
                {
                    Console.Write("Enter your lastname:  ");
                    lastName = Console.ReadLine().Trim();

                    if (ValidateName(lastName))
                        break;
                }

                // Check if the customer already has that type of account
                var accountExits = false;
                BankInfo bankInfo = new BankInfo();
                 
                
                
                if (savings.Count > 0)
                {
                    if (input == "1")
                    {
                        foreach (var account in savings)
                        {
                            if(account.AccountName == firstName + " " + lastName)
                            {
                                Console.WriteLine("You already have a savings account, open a current account instead");
                                accountExits = true;
                            }

                        }
                    }
                }

                if (current.Count > 0)
                {
                    if (input == "2")
                    {
                        foreach (var account in current)
                        {
                            if (account.AccountName == firstName + " " + lastName)
                            {
                                Console.WriteLine("You already have a current account, open a savings account instead");
                                accountExits = true;
                            }

                        }
                    }
                }

                if (accountExits)
                    continue;

                while (true)
                {
                    Console.Write("Enter your email address:  ");
                    email = Console.ReadLine().Trim();

                    if (IsEmailValid(email))
                        break;
                }

                while (true)
                {
                    Console.Write("Enter your eleven digit phone number, eg: 07062746869:  ");
                    phoneNumber = Console.ReadLine().Trim(); ;

                    if (ValidatePhoneNumber(phoneNumber))
                        break;
                }

                while (true)
                {
                    Console.Write("How much do you want to open account with; Minimum opening balance is 1000: ");
                    var n = Console.ReadLine().Trim();

                    var isValid = decimal.TryParse(n, out amount);

                    if (ValidAmount(amount))
                        break;
                }


                switch (input)
                {
                    case "1":
                        CreateSavingsAcc savingsAccount = new CreateSavingsAcc(amount, DateTime.Now, "Opening Amount\n");

                        savingsAccount.AccountType = AccountType.Savings.ToString();
                        savingsAccount.Email = email;
                        savingsAccount.FirstName = firstName;
                        savingsAccount.LastName = lastName;
                        savingsAccount.MobileNumber = phoneNumber;

                        savings.Add(savingsAccount);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Your savings account has been successfully opened with account number {savingsAccount.AccountNumber}\n");
                        Console.ResetColor();

                        break;
                    case "2":
                        CreateCurrentAcc currentAccount = new CreateCurrentAcc(amount, DateTime.Now, "Opening Amount\n")
                        {
                            AccountType = AccountType.Current.ToString(),
                            Email = email,
                            FirstName = firstName,
                            LastName = lastName,
                            MobileNumber = phoneNumber,
                        };

                        current.Add(currentAccount);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Your current account has been successfully opened with account number {currentAccount.AccountNumber}\n");
                        Console.ResetColor();

                        break;
                    default:
                        break;
                }

                Console.WriteLine("Would you like to open another account: ");

                var decision = string.Empty;
                while (true)
                {
                    Console.WriteLine("Enter \"yes\" to open another account or \"no\" to continue: ");
                    decision = Console.ReadLine().Trim().ToLower();

                    if (yesOrNo.Contains(decision))
                        break;
                }

                if (decision == "yes")
                    continue;

                if (decision == "no")
          
                    break;
            }
            AccType act = new AccType();
            act.savings = savings;
            act.currents = current;
            return act;
        }

        private static void Options1()
        {
            var options = @"Select one option to continue
Enter 1 To Open a Savings Account
Enter 2 To Open a Current Account";

            Console.WriteLine("\n" + options);
        }

        private static bool ValidateName(string name)
        {
            var regex = @"^[\p{L} \.\-]+$";
            Regex newRegex = new Regex(regex);

            if (!newRegex.IsMatch(name))
                return false;

            return true;
        }

        //private static bool ValidateName(string name)
        //{

        //    if ((!Regex.IsMatch(name, @"^[\p{L}\p{M}' \.\-]+$")))
        //        return false;

        //    return true;
        //}

        private static bool ValidatePhoneNumber(string number)
        {
            if (number == null || number.Length != 11)
                return false;

            return true;
        }

        private static bool ValidAmount(decimal amount)
        {
            if (amount < 1000)
                return false;

            return true;
        }

        public static string FirstCharacterUpper(string input)
        {
            var name = input[0].ToString().ToUpper();

            for (int i = 1; i < input.Length; i++)
                name += input[i];

            return name;
        }

        public static bool IsEmailValid(string email)
        {
            string emailRegex = "^[0-9A-Za-z]+[_+.-]{0,1}[0-9A-Za-z]+[@][a-zA-Z]+[.][A-Za-z]{2,3}([.][a-zA-Z]{2,3}){0,1}$";

            return Regex.IsMatch(email, emailRegex);
        }
    }

}
    

