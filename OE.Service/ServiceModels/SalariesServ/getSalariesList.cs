
using OE.Data;
using System.Collections.Generic;
namespace OE.Service.ServiceModels.SalariesServ
{
    public class getSalariesList
    {
        public IEnumerable<getSalariesList_Salaries> _Salaries { get; set; }
        public Salaries Salaries { get; set; }        
        public getSalariesList_Staffs Staffs { get; set; }       
        public decimal Amount { get; set; }
        public decimal BonusAmount { get; set; }       
    }
    public class getSalariesList_Salaries : Salaries
    {
        public string StaffName { get; set; }

    }
   
    public class getSalariesList_Staffs : Staffs
    {
        public string Name { get; set; }
        public string Designation { get; set; }
    }
   
}
