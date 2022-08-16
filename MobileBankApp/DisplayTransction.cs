using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankApp
{
    public class DisplayTransction
    {
        public static void DisplayTransct(List<CreateSavingsAcc> savings, List<CreateCurrentAcc> current)
        {
            string[] yesOrNo = { "yes", "no" };
            string accountNum = string.Empty;
            string type = string.Empty;

            while (true)
            {
                Options2();
                var input = Console.ReadLine();

                if (input == "0")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    //PrintTables.DisplayAccountDetails(savings, current);
                    Console.ResetColor();
                }

                if (input == "1")
                {
                    Console.Write("Enter Your Account Number:  ");
                    accountNum = Console.ReadLine().Trim();

                    Console.WriteLine("Select Account Type:  ");
                    Console.WriteLine("1 - Savings");
                    Console.WriteLine("2 - Current");
                    type = Console.ReadLine().Trim();

                    if (type == "1")
                    {
                        foreach (var account in savings)
                        {
                            if (account.AccountNumber == accountNum)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                BankOutput.DisplayBankOutput(account);
                                Console.ResetColor();
                            }
                        }
                    }

                    if (type == "2")
                    {
                        foreach (var account in current)
                        {
                            if (account.AccountNumber == accountNum)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                BankOutput.DisplayBankOutputCurrent(account);
                                Console.ResetColor();
                            }
                        }
                    }
                }

                if (input == "2")
                {
                    Environment.Exit(0);
                }

                var decision = string.Empty;
                while (true)
                {
                    Console.WriteLine("Enter \"yes\" to perform another operation or \"no\" to continue: ");
                    decision = Console.ReadLine().Trim().ToLower();

                    if (yesOrNo.Contains(decision))
                        break;
                }

                if (decision == "yes")
                    continue;

                if (decision == "no")
                    break;
            }
        }

        private static void Options2()
        {
            StringBuilder options = new StringBuilder();

            options.Append("What operation would you like perform?")
                .AppendLine()
                .Append("Enter 0 to Print Account Details Table")
                .AppendLine()
                .Append("Enter 1 to Print Transaction History Table")
                .AppendLine()
                .Append("Enter 2 to Exit")
                .AppendLine();

            Console.WriteLine(options);
        }
    }
}
