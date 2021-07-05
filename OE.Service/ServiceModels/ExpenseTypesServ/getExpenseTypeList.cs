
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.ExpenseTypesServ
{
    public class getExpenseTypeList
    {
        public IEnumerable<getExpenseTypeList_ExpenseTypes> _ExpenseTypes { get; set; }
        public ExpenseTypes ExpenseTypes { get; set; }
    }
    public class getExpenseTypeList_ExpenseTypes : ExpenseTypes
    {


    }
}
