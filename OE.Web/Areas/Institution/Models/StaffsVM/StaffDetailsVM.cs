
using OE.Data;
using System;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.StaffsVM
{
    public class StaffDetailsVM
    {
        public IList<StaffDetailsVM_Staffs> _Staffs { get; set; }
        public StaffDetailsVM_Staffs Staffs { get; set; }

    }
    public class StaffDetailsVM_Staffs : Staffs
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public Int64 StaffId { get; set; }
    }
}