
using OE.Data;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.SalarysServ
{
    public class UpdateSalary
    {
        public IEnumerable<UpdateSalary_Salaries> _Salaries { get; set; }       
        public UpdateSalary_Salaries Salaries { get; set; }      
    }
    public class UpdateSalary_Salaries : Salaries    
    {

    }
}