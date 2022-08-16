using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBankApp
{
    public class BankOutput
    {
        private static int tableWidth = 115;
        public static void DisplayBankOutput(CreateSavingsAcc account)
        {
            PrintDash();
            PrintHeadings("Account Name", "Account Number", "Amount", "Balance", "Date", "Narration");
            PrintDash();

            foreach (var item in account.Transctions)
            {
                PrintHeadings(account.AccountName, account.AccountNumber, item.Amount.ToString(), account.Balance.ToString(), item.Date.ToShortDateString(), item.Comment);
            }

            PrintDash();
        }

        public static void DisplayBankOutputCurrent(CreateCurrentAcc account)
        {
            PrintDash();
            PrintHeadings("Account Name", "Account Number", "Amount", "Date", "Narration");
            PrintDash();

            foreach (var item in account.Transctions)
            {
                PrintHeadings(account.AccountName, account.AccountNumber, item.Amount.ToString(), item.Date.ToShortDateString(), item.Comment);
            }

            PrintDash();
        }

        public static void DisplayAccountDetails(List<CreateSavingsAcc> savingsAccounts, List<CreateCurrentAcc> currentAccount)
        {
            PrintDash();
            PrintHeadings("ACCOUNT NAME", "EMAIL", "PHONE NUMBER", "ACCOUNT NUMBER", "ACCOUNT TYPE", "BALANCE");
            PrintDash();

            foreach (var account in savingsAccounts)
            {
                PrintHeadings(account.AccountName, account.Email, account.MobileNumber, account.AccountNumber, account.AccountType.ToString(), account.Balance.ToString());
            }

            foreach (var account in currentAccount)
            {
                PrintHeadings(account.AccountName, account.Email, account.MobileNumber, account.AccountNumber, account.AccountType.ToString(), account.Balance.ToString());
            }


            PrintDash();
        }
        private static void PrintDash() => Console.WriteLine(new string('-', tableWidth));

        private static void PrintHeadings(params string[] columns)
        {
            int columnWidth = (tableWidth - columns.Length) / columns.Length;
            const string columnSeperator = "|";

            string row = columns.Aggregate(columnSeperator, (seperator, columnText) => seperator + GetCenterAlignedText(columnText, columnWidth) + columnSeperator);

            Console.WriteLine(row);
        }

        private static string GetCenterAlignedText(string text, int columnWidth)
        {
            text = text.Length > columnWidth ? text.Substring(0, columnWidth - 3) + "..." : text;

            return string.IsNullOrEmpty(text)
                ? new string(' ', columnWidth)
                : text.PadRight(columnWidth - ((columnWidth - text.Length) / 2)).PadLeft(columnWidth);
        }
    }
}
