
using OE.Data;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.ExpensesVM
{
    public class PrintIndexExpensesListVM
    {
        public IList<PrintIndexExpensesListVM_Expenses> _Expenses { get; set; }
        public PrintIndexExpensesListVM_Institutions Institution { get; set; }
        public PrintIndexExpensesListVM_Expenses Expenses { get; set; }
        public decimal ammount { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
    public class PrintIndexExpensesListVM_Expenses : Expenses
    {
        public string ExpenseTypeName { get; set; }
    }
    public class PrintIndexExpensesListVM_Institutions : Institutions
    {


    }
}
