
using OE.Data;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.ExpenseTypesVM
{
    public class IndexExpenseTypeListVM
    {
        public IList<IndexExpensesListVM_ExpenseTypes> _ExpenseTypes { get; set; }
        public IndexExpensesListVM_ExpenseTypes ExpenseTypes { get; set; }
    }
    public class IndexExpensesListVM_ExpenseTypes : ExpenseTypes
    {

    }
}