
using OE.Data;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.ExpenseTypesVM
{
    public class PrintIndexExpenseTypeListVM
    {
        public IList<PrintIndexExpenseTypeListVM_ExpenseTypes> _ExpenseTypes { get; set; }
        public PrintIndexExpenseTypeListVM_Institutions Institution { get; set; }
        //[NOTE: Extra Fields]
        //public string  Logo { get; set; }
    }
    public class PrintIndexExpenseTypeListVM_ExpenseTypes : ExpenseTypes
    {

    }
    public class PrintIndexExpenseTypeListVM_Institutions : Institutions
    {


    }
}