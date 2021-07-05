
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.ExpensesServ
{
    public class InsertExpense
    {
        public IList<InsertExpenses_Expenses> _Expenses { get; set; }        
        public InsertExpenses_Expenses Expenses { get; set; }       
    }
    public class InsertExpenses_Expenses : Expenses
    {

    }
}