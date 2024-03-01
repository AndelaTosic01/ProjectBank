using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes {
    public class GiftCardAccount : Bankaccount
    {
        private readonly decimal _monthlyDeposit = 0m;

        public GiftCardAccount(decimal initialBalance, string name, decimal monthlyDeposit) : base(initialBalance, name) => _monthlyDeposit = monthlyDeposit;

        public override void PerformMonthEndTransactions()
        {
            if (_monthlyDeposit > 0)
            {
                MakeDeposit(_monthlyDeposit, DateTime.Now, "Add monthly deposit");
            }
        }



    }
}
