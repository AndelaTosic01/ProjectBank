using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes {
    public class LineOfCreditAccount : Bankaccount
    {
        public LineOfCreditAccount (decimal initialBalance, string name, decimal creditLimit) : base(initialBalance, name, -creditLimit) { }

        public override void PerformMonthEndTransactions()
        {
            if (Balance < 0)
            {
                decimal interest = -Balance * 0.7m;
                MakeWithdrawal(interest, DateTime.Now, "Charge monthly interest");
            }
        }

        protected override Transaction? CheckWithdrawalLimit(bool isOverdrawn) 
            => isOverdrawn ? new Transaction(-20, DateTime.Now, "Apply overdraft fee") : default; 
    }
}
