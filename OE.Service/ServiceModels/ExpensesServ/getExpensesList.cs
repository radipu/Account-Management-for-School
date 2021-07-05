
using System;
using OE.Data;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.ExpensesServ
{
    public class getExpensesList
    {

        public IEnumerable<getExpensesList_Expenses> _Expenses { get; set; }
        public Expenses Expenses { get; set; }
    }

    public class getExpensesList_Expenses : Expenses
    {
        public string ExpenseTypeName { get; set; }       
    }

}
