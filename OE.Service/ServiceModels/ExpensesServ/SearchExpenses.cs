
using OE.Data;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.ExpensesServ
{
    public class SearchExpenses
    {
        public IEnumerable<SearchExpenses_Expenses> _Expenses { get; set; }
        public SearchExpenses_Expenses Expenses { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal DateRangeAmount { get; set; }

    }
    public class SearchExpenses_Expenses : Expenses
    {
        public string ExpenseTypeName { get; set; }
    }
}