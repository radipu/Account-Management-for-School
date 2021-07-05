
using OE.Data;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.ExpenseTypesVM
{
    public class IndexExpenseTypesListByAdminVM
    {
        public IList<IndexExpenseTypesListByAdminVM_ExpenseTypes> _ExpenseTypes { get; set; }
        public IndexExpenseTypesListByAdminVM_ExpenseTypes ExpenseTypes { get; set; }
    }
    public class IndexExpenseTypesListByAdminVM_ExpenseTypes : ExpenseTypes
    {

    }
}
