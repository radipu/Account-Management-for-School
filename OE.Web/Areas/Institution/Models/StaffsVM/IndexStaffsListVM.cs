
using Microsoft.AspNetCore.Http;
using OE.Data;
using System;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.StaffsVM
{
    public class IndexStaffsListVM
    {
        public IList<IndexStaffsListVM_Staffs> _Staffs { get; set; }
        public IndexStaffsListVM_Staffs Staffs { get; set; }

    }
    public class IndexStaffsListVM_Staffs : Staffs
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public Int64 StaffId { get; set; }       
        public IFormFile fleImage { get; set; }       
        public string GenderName { get; set; }        
    }

}
