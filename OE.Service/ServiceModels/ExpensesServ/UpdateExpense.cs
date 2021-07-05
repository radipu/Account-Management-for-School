
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.ExpensesServ
{
    public class UpdateExpense
    {
        public IList<UpdateExpense_Expenses> _Expenses { get; set; }        
        public UpdateExpense_Expenses Expenses { get; set; }       
    }
    public class UpdateExpense_Expenses : Expenses
    {

    }
}