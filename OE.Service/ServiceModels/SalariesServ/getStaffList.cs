
using OE.Data;
using System.Collections.Generic;
using System;

namespace OE.Service.ServiceModels.SalariesServ
{
    public class getStaffList
    {
        public IEnumerable<getStaffList_Staffs> _Staffs { get; set; }
        public string WebRootPath { get; set; }
        public getStaffList_Staffs Staffs { get; set; }
    }
    public class getStaffList_Staffs : Staffs
    {
        public string Name { get; set; }
        public string Designation { get; set; }       
        public long YearlyTermNo { get; set; }        
        public DateTime SalaryYear { get; set; }
        public decimal NetSalary { get; set; }
    }
}
