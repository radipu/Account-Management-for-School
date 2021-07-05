
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.ExpensesServ
{
    public class DeleteExpense
    {
        public Expenses Expenses { get; set; }
        public long ExpenseId { get; set; }
    }
}
