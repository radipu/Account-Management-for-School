
using OE.Data;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.SalaryIncrementsServ
{
    public class InsertSalaryIncrement
    {
        public IEnumerable<InsertSalaryIncrement_SalaryIncrements> _SalaryIncrements { get; set; }       
        public InsertSalaryIncrement_SalaryIncrements SalaryIncrements { get; set; }        
    }

    public class InsertSalaryIncrement_SalaryIncrements : SalaryIncrements
    {

    }
}