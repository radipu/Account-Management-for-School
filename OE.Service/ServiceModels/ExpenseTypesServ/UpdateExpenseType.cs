
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.ExpenseTypesServ
{
    public class UpdateExpenseType
    {
        public IEnumerable<UpdateExpenseType_ExpenseTypes> _ExpenseTypes { get; set; }        
        public UpdateExpenseType_ExpenseTypes ExpenseTypes { get; set; }        
    }
    public class UpdateExpenseType_ExpenseTypes : ExpenseTypes
    {

    }
}