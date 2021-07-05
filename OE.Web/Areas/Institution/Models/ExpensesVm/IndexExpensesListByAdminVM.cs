
using OE.Data;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.ExpensesVM
{
    public class IndexExpensesListByAdminVM
    {
        public IList<IndexExpensesListByAdminVM_Expenses> _Expenses { get; set; }
        public IndexExpensesListByAdminVM_Expenses Expenses { get; set; }
        public decimal ammount { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
    public class IndexExpensesListByAdminVM_Expenses : Expenses
    {
        public string ExpenseTypeName { get; set; }
    }
}
