
using OE.Data;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.ExpensesVM
{
    public class CalculateExpensesVM
    {
        public IList<CalculateExpensesVM_Expenses> _Expenses { get; set; }
        public CalculateExpensesVM_Expenses Expenses { get; set; }
        public decimal ammount { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
    public class CalculateExpensesVM_Expenses : Expenses
    {
        public string ExpenseTypeName { get; set; }
    }
}