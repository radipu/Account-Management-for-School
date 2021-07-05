
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.ExpenseTypesServ
{
    public class PrintGetExpenseTypeList
    {
        public IEnumerable<PrintGetExpenseTypeList_ExpenseTypes> _ExpenseTypes { get; set; }
        public PrintGetExpenseTypeList_Institutions Institution { get; set; }
    }
    public class PrintGetExpenseTypeList_ExpenseTypes : ExpenseTypes
    {

    }
    public class PrintGetExpenseTypeList_Institutions : Institutions
    {

    }
}