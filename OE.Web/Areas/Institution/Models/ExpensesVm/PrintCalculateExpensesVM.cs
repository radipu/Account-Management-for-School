
using OE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OE.Web.Areas.Institution.Models.ExpensesVM
{
    public class PrintCalculateExpensesVM
    {
        public IList<PrintCalculateExpensesVM_Expenses> _Expenses { get; set; }
        public PrintCalculateExpensesVM_Institutions Institution { get; set; }
        public PrintCalculateExpensesVM_Expenses Expenses { get; set; }
        public decimal ammount { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
    public class PrintCalculateExpensesVM_Expenses : Expenses
    {
        public string ExpenseTypeName { get; set; }
    }
    public class PrintCalculateExpensesVM_Institutions : Institutions
    {

    }
}
