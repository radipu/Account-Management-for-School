
using Microsoft.AspNetCore.Http;
using OE.Data;
using System;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.SalariesVM
{
    public class IndexStaffListVM
    {
        public IList<IndexStaffListVM_Staffs> _Staffs { get; set; }
        public IndexStaffListVM_Staffs Staffs { get; set; }

    }
    public class IndexStaffListVM_Staffs : Staffs
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public Int64 StaffId { get; set; }  
        public string GenderName { get; set; }
        public long YearlyTermNo { get; set; }        
        public IFormFile fleImage { get; set; }
        public DateTime SalaryYear { get; set; }
        public decimal NetSalary { get; set; }
    }
}