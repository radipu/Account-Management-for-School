
using OE.Data;
using System;
using System.Collections.Generic;
namespace OE.Web.Areas.Institution.Models.SalariesVM
{
    public class IndexSalariesListVM
    {
        public IList<IndexSalariesListVM_Salaries> _Salaries { get; set; }
        public IndexSalariesListVM_Salaries Salaries { get; set; }       
        public IndexSalariesListVM_Staffs Staffs { get; set; }        
        public decimal Amount { get; set; }
        public decimal BonusAmount { get; set; }        
    }
    public class IndexSalariesListVM_Salaries : Salaries
    {
        public string StaffName { get; set; }        
           
    }    
    public class IndexSalariesListVM_Staffs : Staffs
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public Int64 StaffId { get; set; }
    }
    
}