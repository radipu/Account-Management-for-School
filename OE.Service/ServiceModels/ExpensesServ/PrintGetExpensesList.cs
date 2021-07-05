
using OE.Data;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.ExpensesServ
{
    public class PrintGetExpensesList
    {
        public IEnumerable<PrintGetExpensesList_Expenses> _Expenses { get; set; }
        public Expenses Expenses { get; set; }
        public PrintGetExpensesList_Institutions Institution { get; set; }
    }
    public class PrintGetExpensesList_Expenses : Expenses
    {
        public string ExpenseTypeName { get; set; }
    }
    public class PrintGetExpensesList_Institutions : Institutions
    {

    }
}