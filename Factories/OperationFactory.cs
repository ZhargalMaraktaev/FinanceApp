using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp
{
    public static class OperationFactory
    {
        public static Operation CreateOperation(int id, string type, int bankAccountId, decimal amount, DateTime date, string description, int categoryId)
        {
            if (type == "Expense" && amount > 0)
                throw new ArgumentException("Amount for 'Expense' type cannot be positive.");

            if (type == "Income" && amount < 0)
                throw new ArgumentException("Amount for 'Income' type cannot be negative.");

            return new Operation
            {
                Id = id,
                Type = type,
                BankAccountId = bankAccountId,
                Amount = amount,
                Date = date,
                Description = description,
                CategoryId = categoryId
            };
        }
    }

}
