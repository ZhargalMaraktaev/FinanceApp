using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp
{
    public class BalanceService
    {
        public void RecalculateBalance(BankAccount account, List<Operation> operations)
        {
            account.Balance = operations.Where(o => o.BankAccountId == account.Id).Sum(o => o.Amount);
            Console.WriteLine($"Recalculated balance for account {account.Name}: {account.Balance}");
        }
    }
}
