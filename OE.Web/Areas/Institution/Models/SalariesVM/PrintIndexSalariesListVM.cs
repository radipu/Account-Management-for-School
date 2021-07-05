
using OE.Data;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.SalariesVM
{
    public class PrintIndexSalariesListVM
    {
        public IList<PrintIndexSalariesListVM_Salaries> _Salaries { get; set; }
        public PrintIndexSalariesListVM_Salaries Salaries { get; set; }
    }
    public class PrintIndexSalariesListVM_Salaries : Salaries
    {
        public string StaffName { get; set; }
    }
}