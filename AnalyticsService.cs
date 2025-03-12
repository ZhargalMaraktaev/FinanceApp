using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp
{
    public class AnalyticsService
    {
        public decimal CalculateNetIncome(List<Operation> operations, DateTime startDate, DateTime endDate)
        {
            var filteredOperations = operations.Where(o => o.Date >= startDate && o.Date <= endDate).ToList();
            var income = filteredOperations.Where(o => o.Type == "Income").Sum(o => o.Amount);
            var expense = filteredOperations.Where(o => o.Type == "Expense").Sum(o => o.Amount);
            return income + expense; // Расходы уже отрицательные
        }

        public Dictionary<string, decimal> GroupByCategory(List<Operation> operations)
        {
            return operations.GroupBy(o => o.CategoryId)
                             .ToDictionary(g => g.First().CategoryId.ToString(), g => g.Sum(o => o.Amount));
        }
    }
}
