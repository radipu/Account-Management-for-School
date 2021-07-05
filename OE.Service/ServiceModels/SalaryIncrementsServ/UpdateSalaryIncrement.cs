
using OE.Data;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.SalaryIncrementsServ
{
    public class UpdateSalaryIncrement
    {
        public IEnumerable<UpdateSalaryIncrement_SalaryIncrements> _SalaryIncrements { get; set; }        
        public UpdateSalaryIncrement_SalaryIncrements SalaryIncrements { get; set; }        
    }

    public class UpdateSalaryIncrement_SalaryIncrements : SalaryIncrements
    {

    }
}
