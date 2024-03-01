using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes {
    public class InterestEarningAccount : Bankaccount
    {
        public InterestEarningAccount(decimal initialBalance, string name) : base(initialBalance, name) { }

        public override void PerformMonthEndTransactions()
        {
            if (Balance > 500m)
            {
                decimal interest = Balance * 0.5m;
                MakeDeposit(interest, DateTime.Now, "Interest");

            }
        }
    }
}
