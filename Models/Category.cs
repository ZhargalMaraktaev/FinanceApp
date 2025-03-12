using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceApp
{
    public class Category
    {
        public int Id { get; set; }
        public string Type { get; set; } // "Income" или "Expense"
        public string Name { get; set; }
    }
}
