
using Microsoft.AspNetCore.Http;
using OE.Data;
using System;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.StaffsVM
{
    public class IndexStaffsListByAdminVM
    {
        public IList<IndexStaffsListByAdminVM_Staffs> _Staffs { get; set; }
        public IndexStaffsListByAdminVM_Staffs Staffs { get; set; }
    }
    public class IndexStaffsListByAdminVM_Staffs : Staffs
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public Int64 StaffId { get; set; }
        public IFormFile fleImage { get; set; }
        public string GenderName { get; set; }
    }
}
