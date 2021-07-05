
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.SalaryIncrementsServ
{
    public class getSalaryIncrementsList
    {
        public IEnumerable<getSalaryIncrementsList_SalaryIncrements> _SalaryIncrements { get; set; }
        public SalaryIncrements SalaryIncrements { get; set; }
    }

    public class getSalaryIncrementsList_SalaryIncrements : SalaryIncrements
    {

    }
}