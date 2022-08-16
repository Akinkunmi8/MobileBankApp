using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankApp
{
    public class BankMethodolgy
    {
        public static void PerformAccountOperation(List<CreateSavingsAcc> savings, List<CreateCurrentAcc> current)
        {
            string input = string.Empty;
            string accountNum = string.Empty;
            string accountNumReceiver = string.Empty;
            string type = string.Empty;
            string receiverType = string.Empty;
            decimal balance = 0;
            decimal amount = 0;
            string[] yesOrNo = { "yes", "no" };
            decimal balanceBeforeSavings = 0;
            decimal balanceBeforeCurrent = 0;
            string narration = string.Empty;

            //To get the balance
            foreach (var account in savings)
            {
                if (account.AccountNumber == accountNum)
                {
                    balance = account.Balance;
                    balanceBeforeSavings = balance;
                }
            }

            foreach (var account in current)
            {
                if (account.AccountNumber == accountNum)
                {
                    balance = account.Balance;
                    balanceBeforeCurrent = balance;
                }
            }

            while (true)
            {
                Options();
                input = Console.ReadLine().Trim();

                switch (input)
                {
                    case "0":
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
                                    balance = account.Balance;
                                    balanceBeforeSavings = balance;
                                }
                            }
                        }

                        if (type == "2")
                        {
                            foreach (var account in current)
                            {
                                if (account.AccountNumber == accountNum)
                                {
                                    balance = account.Balance;
                                    balanceBeforeCurrent = balance;
                                }
                            }
                        }

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Your account balance is: " + balance);
                        Console.ResetColor();

                        break;
                        // to deposite
                    case "1":
                        Console.Write("Enter Your Account Number:  ");
                        accountNum = Console.ReadLine().Trim();

                        Console.Write("Enter Amount: ");
                        amount = Convert.ToDecimal(Console.ReadLine());

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
                                    try
                                    {
                                        account.Deposite(amount, DateTime.Now, "Deposit");
                                    }
                                    catch (ArgumentOutOfRangeException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }

                                    balance = account.Balance;
                                }
                            }

                            if (balance > balanceBeforeSavings)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Deposit was succussful\n");
                                Console.ResetColor();
                                balanceBeforeSavings = balance;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Deposit was Unsuccussful\n");
                                Console.ResetColor();
                            }
                        }

                        if (type == "2")
                        {
                            foreach (var account in current)
                            {
                                if (account.AccountNumber == accountNum)
                                {
                                    try
                                    {
                                        account.Deposite(amount, DateTime.Now, "Deposit");
                                    }
                                    catch (ArgumentOutOfRangeException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }

                                    balance = account.Balance;
                                }
                            }

                            if (balance > balanceBeforeCurrent)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Deposit was succussful\n");
                                Console.ResetColor();
                                balanceBeforeCurrent = balance;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Deposit was Unsuccussful\n");
                                Console.ResetColor();
                            }
                        }

                        break;

                    case "2":
                        Console.Write("Enter Your Account Number:  ");
                        accountNum = Console.ReadLine().Trim();

                        Console.Write("Enter Amount: ");
                        amount = Convert.ToDecimal(Console.ReadLine());

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
                                    try
                                    {
                                        account.WithDraw(amount, DateTime.Now, "Withdrawal");
                                    }
                                    catch (ArgumentOutOfRangeException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }

                                    balance = account.Balance;
                                }
                            }

                            if (balance < balanceBeforeSavings)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Withdrawal was succussful\n");
                                Console.ResetColor();
                                balanceBeforeSavings = balance;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Withdrawal was Unsuccussful\n");
                                Console.ResetColor();
                            }
                        }

                        if (type == "2")
                        {
                            foreach (var account in current)
                            {
                                if (account.AccountNumber == accountNum)
                                {
                                    try
                                    {
                                        account.WithDraw(amount, DateTime.Now, "Withdrawal");
                                    }
                                    catch (ArgumentOutOfRangeException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }

                                    balance = account.Balance;
                                }
                            }

                            if (balance < balanceBeforeCurrent)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Withdrawal was succussful\n");
                                Console.ResetColor();
                                balanceBeforeCurrent = balance;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Withdrawal was Unsuccussful\n");
                                Console.ResetColor();
                            }
                        }

                        break;

                    case "3":
                        Console.Write("Enter Your Account Number:  ");
                        accountNum = Console.ReadLine().Trim();

                        Console.Write("Enter Receiver's Account Number:  ");
                        accountNumReceiver = Console.ReadLine().Trim();

                        Console.Write("Enter Amount: ");
                        amount = Convert.ToDecimal(Console.ReadLine());

                        Console.WriteLine("Select Sender's Account Type:  ");
                        Console.WriteLine("1 - Savings");
                        Console.WriteLine("2 - Current");
                        type = Console.ReadLine().Trim();

                        Console.WriteLine("Select Receiver's Account Type:  ");
                        Console.WriteLine("1 - Savings");
                        Console.WriteLine("2 - Current");
                        receiverType = Console.ReadLine().Trim();

                        CreateSavingsAcc savingsAcc = new CreateSavingsAcc();
                       CreateCurrentAcc currentAcc = new CreateCurrentAcc();

                        if (receiverType == "1")
                        {
                            foreach (var account in savings)
                            {
                                if (account.AccountNumber == accountNumReceiver)
                                    savingsAcc = account;
                            }
                        }

                        if (receiverType == "2")
                        {
                            foreach (var account in current)
                            {
                                if (account.AccountNumber == accountNumReceiver)
                                    currentAcc = account;
                            }
                        }

                        if (type == "1" && receiverType == "1")
                        {
                            foreach (var account in savings)
                            {
                                if (account.AccountNumber == accountNum)
                                {
                                    try
                                    {
                                        account.TransferFund(amount, DateTime.Now, "Transfer", savingsAcc);
                                    }
                                    catch (ArgumentOutOfRangeException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }

                                    balance = account.Balance;
                                }
                            }

                            if (balance < balanceBeforeSavings)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Transfer was successful\n");
                                Console.ResetColor();
                                balanceBeforeSavings = balance;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Transfer was Unsuccessful\n");
                                Console.ResetColor();
                            }
                        }

                        if (type == "1" && receiverType == "2")
                        {
                            foreach (var account in savings)
                            {
                                if (account.AccountNumber == accountNum)
                                {
                                    try
                                    {
                                        account.TransferFund(amount, DateTime.Now, "Transfer", savingsAcc);
                                    }
                                    catch (ArgumentOutOfRangeException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }

                                    balance = account.Balance;
                                }
                            }

                            if (balance < balanceBeforeSavings)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Transfer was successful\n");
                                Console.ResetColor();
                                balanceBeforeSavings = balance;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Transfer was Unsuccessful\n");
                                Console.ResetColor();
                            }
                        }

                        if (type == "2" && receiverType == "2")
                        {
                            foreach (var account in current)
                            {
                                if (account.AccountNumber == accountNum)
                                {
                                    try
                                    {
                                        account.TransferFund(amount, DateTime.Now, "Transfer", savingsAcc);
                                    }
                                    catch (ArgumentOutOfRangeException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }

                                    balance = account.Balance;
                                }
                            }

                            if (balance < balanceBeforeCurrent)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Transfer was successful\n");
                                Console.ResetColor();
                                balanceBeforeCurrent = balance;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Transfer was Unsuccessful\n");
                                Console.ResetColor();
                            }
                        }

                        if (type == "2" && receiverType == "1")
                        {
                            foreach (var account in current)
                            {
                                if (account.AccountNumber == accountNum)
                                {
                                    try
                                    {
                                        account.TransferFund(amount, DateTime.Now, "Transfer", savingsAcc);
                                    }
                                    catch (ArgumentOutOfRangeException e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }
                                    catch (Exception e)
                                    {
                                        Console.WriteLine(e.Message);
                                    }

                                    balance = account.Balance;
                                }
                            }

                            if (balance < balanceBeforeCurrent)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("Transfer was successful\n");
                                Console.ResetColor();
                                balanceBeforeCurrent = balance;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Transfer was Unsuccessful\n");
                                Console.ResetColor();
                            }
                        }

                        break;

                    default:
                        break;
                }

                var decision = string.Empty;
                while (true)
                {
                    Console.WriteLine("Enter \"yes\" to perform another transaction or \"no\" to continue: ");
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

        private static void Options()
        {
            StringBuilder options = new StringBuilder();

            options.Append("What operation would you like perform?")
                .AppendLine()
                .Append("Enter 0 to Check Balance")
                .AppendLine()
                .Append("Enter 1 to Deposit Fund")
                .AppendLine()
                .Append("Enter 2 to Withdraw Fund")
                .AppendLine()
                .Append("Enter 3 to Transfer Fund")
                .AppendLine();

            Console.WriteLine(options);
        }
    }
}

