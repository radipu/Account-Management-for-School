
using OE.Data;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.ExpensesServ
{
    public class PrintSearchExpenses
    {
        public IEnumerable<PrintSearchExpenses_Expenses> _Expenses { get; set; }
        public Expenses Expenses { get; set; }
        public PrintSearchExpenses_Institutions Institution { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public decimal DateRangeAmount { get; set; }
    }
    public class PrintSearchExpenses_Expenses : Expenses
    {
        public string ExpenseTypeName { get; set; }
    }
    public class PrintSearchExpenses_Institutions : Institutions
    {

    }
}