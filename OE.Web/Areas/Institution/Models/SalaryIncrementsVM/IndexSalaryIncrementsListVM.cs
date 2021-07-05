
using OE.Data;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.SalaryIncrementsVM
{
    public class IndexSalaryIncrementsListVM
    {
        public IList<IndexSalaryIncrementsListVM_SalaryIncrements> _SalaryIncrements { get; set; }
        public IndexSalaryIncrementsListVM_SalaryIncrements SalaryIncrements { get; set; }
    }
    public class IndexSalaryIncrementsListVM_SalaryIncrements : SalaryIncrements
    {

    }
}