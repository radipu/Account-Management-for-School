using OE.Data;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.SalarysServ
{
    public class InsertSalary
    {
        public IEnumerable<InsertSalary_Salaries> _Salaries { get; set; }       
        public InsertSalary_Salaries Salaries { get; set; }       
    }
    public class InsertSalary_Salaries : Salaries 
    {       
        public decimal BonusAmount { get; set; }      
    }
}