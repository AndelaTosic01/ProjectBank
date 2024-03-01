using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class Bankaccount
    {
        private static int s_accountNumber = 1234567890;
        public string AccountNumber { get; }
        public string Owner { get; set; }
        public decimal Balance {
            get 
            {
                decimal balance = 0;
                foreach (var item in _allTransaction)
                    balance += item.Amount;
                return balance;
            }
        }
        private readonly decimal _minimumBalance;
        private readonly List<Transaction> _allTransaction = new();


        public Bankaccount(decimal initialBalance, string owner) : this(initialBalance, owner, 0) { }


        public Bankaccount(decimal initialBalance, string owner, decimal minimumBalance)
        {
            Owner = owner;
            _minimumBalance = minimumBalance;
            AccountNumber = s_accountNumber++.ToString();
            if (initialBalance > 0)
                MakeDeposit(initialBalance, DateTime.Now, "Initial balance");
        }

        public void MakeDeposit(decimal amount, DateTime date, string note)
        {
            if (amount <= 0) {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount of deposit must be grater than zero");
            }

            var deposit = new Transaction(amount, date, note);
            _allTransaction.Add(deposit);
        }

        public void MakeWithdrawal(decimal amount, DateTime date, string note)
        {
            if (amount <= 0) {
                throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be grater than zero");
            }

            Transaction? overdraftTransaction = CheckWithdrawalLimit(Balance - amount < _minimumBalance);
            
            Transaction? withdrawl = new(-amount, date, note);
            _allTransaction.Add(withdrawl);
            
            if (overdraftTransaction != null)
                _allTransaction.Add(overdraftTransaction);
        }

        protected virtual Transaction? CheckWithdrawalLimit(bool isOverdrawn)
        {
            if (isOverdrawn)
                throw new InvalidOperationException("You do not have enough founds");
            else
                return default;
        }

        public string GetAccountHistory() 
        {
            var report = new StringBuilder();

            decimal balance = 0;
            _ = report.AppendLine("Date\t\tAmount\tBalance\tNote");
            foreach (var item in _allTransaction) {
                balance += item.Amount;
                _ = report.AppendLine($"{item.Date.ToShortDateString()}\t{item.Amount}\t{balance}\t{item.Notes}");
            }

            return report.ToString();
        }

        public virtual void PerformMonthEndTransactions() { }
    }
}
