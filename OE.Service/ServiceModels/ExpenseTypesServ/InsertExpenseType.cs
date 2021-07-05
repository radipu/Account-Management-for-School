
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.ExpenseTypesServ
{
    public class InsertExpenseType
    {
        public IEnumerable<InsertExpenseType_ExpenseTypes> _ExpenseTypes { get; set; }        
        public InsertExpenseType_ExpenseTypes ExpenseTypes { get; set; }       
    }
    public class InsertExpenseType_ExpenseTypes : ExpenseTypes
    {

    }
}