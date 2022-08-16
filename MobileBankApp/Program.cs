
using MobileBankApp;

AccType accounts = AccountDetails.AccountInfo();

List<CreateSavingsAcc> savings = accounts.savings;
List<CreateCurrentAcc> current = accounts.currents;

BankMethodolgy.PerformAccountOperation(savings, current);

DisplayTransction.DisplayTransct(savings, current);
