
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.ExpenseTypesServ
{
    public class DeleteExpenseType
    {
        public ExpenseTypes ExpenseTypes { get; set; }
        public long ExpenseTypeId { get; set; }
    }
}