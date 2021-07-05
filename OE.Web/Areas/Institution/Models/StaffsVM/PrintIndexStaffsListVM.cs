
using OE.Data;
using System;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.StaffsVM
{
    public class PrintIndexStaffsListVM
    {
        public IList<PrintIndexStaffsListVM_Staffs> _Staffs { get; set; }
        public PrintIndexStaffsListVM_Staffs Staffs { get; set; }
        public PrintIndexStaffsListVM_Institutions Institution { get; set; }
    }
    public class PrintIndexStaffsListVM_Staffs : Staffs
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public Int64 StaffId { get; set; }
    }

    public class PrintIndexStaffsListVM_Institutions : Institutions
    {
    }
}