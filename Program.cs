using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    internal class Program
    {
        static void Main()
        {
            var account = new Bankaccount(1000, "Andela Tosic");
            Console.WriteLine($"Account {account.AccountNumber} was created for {account.Owner} with {account.Balance}");

            account.MakeDeposit(500, DateTime.Now, "Deposit");
            account.MakeWithdrawal(100, DateTime.Now, "Withdraw");
            Console.WriteLine($"Account {account.AccountNumber} owner: {account.Owner} has {account.Balance} balance");

            Console.WriteLine(account.GetAccountHistory());

            var giftCard = new GiftCardAccount(100, "Ion Obreja", 50);
            Console.WriteLine($"Account {(giftCard.GetType())} {giftCard.AccountNumber} owner: {giftCard.Owner} has {giftCard.Balance} balance");

            giftCard.MakeWithdrawal(20, DateTime.Now, "get expensive coffee");
            giftCard.MakeWithdrawal(50, DateTime.Now, "buy groceries");
            giftCard.PerformMonthEndTransactions();

            // can make additional deposits:
            giftCard.MakeDeposit(27.50m, DateTime.Now, "add some additional spending money");
            Console.WriteLine(giftCard.GetAccountHistory());

            var savings = new InterestEarningAccount(10000, "Marina Trajanovska");
            Console.WriteLine($"Account {(savings.GetType())} {savings.AccountNumber} owner: {savings.Owner} has {savings.Balance} balance");

            savings.MakeDeposit(750, DateTime.Now, "save some money");
            savings.MakeDeposit(1250, DateTime.Now, "Add more savings");
            savings.MakeWithdrawal(250, DateTime.Now, "Needed to pay monthly bills");
            savings.PerformMonthEndTransactions();
            Console.WriteLine(savings.GetAccountHistory());

            //new account
            var lineOfCredit = new LineOfCreditAccount(0, "Sofija Tosic", 0);

            Console.WriteLine($"Account {(lineOfCredit.GetType())} {lineOfCredit.AccountNumber} owner: {lineOfCredit.Owner} has {lineOfCredit.Balance} balance");
            // How much is too much to borrow? --> i don't have money
            lineOfCredit.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
            lineOfCredit.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
            // I still don't have enough money
            lineOfCredit.MakeWithdrawal(5000m, DateTime.Now, "Emergency funds for repairs");
            lineOfCredit.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
            lineOfCredit.PerformMonthEndTransactions();
            Console.WriteLine(lineOfCredit.GetAccountHistory());

            var lineOfCredit2 = new LineOfCreditAccount(0, "Aleksandra Tosic", 2000);
            Console.WriteLine($"Account {(lineOfCredit2.GetType())} {lineOfCredit2.AccountNumber} owner: {lineOfCredit2.Owner} has {lineOfCredit2.Balance} balance");
            // How much is too much to borrow?
            lineOfCredit2.MakeWithdrawal(1000m, DateTime.Now, "Take out monthly advance");
            lineOfCredit2.MakeDeposit(50m, DateTime.Now, "Pay back small amount");
            lineOfCredit2.MakeWithdrawal(5000m, DateTime.Now, "Emergency funds for repairs");
            lineOfCredit2.MakeDeposit(150m, DateTime.Now, "Partial restoration on repairs");
            lineOfCredit2.PerformMonthEndTransactions();
            Console.WriteLine(lineOfCredit2.GetAccountHistory());
        }
    }
}
