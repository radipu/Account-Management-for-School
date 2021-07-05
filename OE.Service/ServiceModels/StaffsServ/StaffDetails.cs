
using OE.Data;
using System;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.StaffsServ
{
    public class StaffDetails
    {
        public IEnumerable<StaffDetails_Staffs> _Staffs { get; set; }
        public StaffDetails_Staffs Staffs { get; set; }
        public Int64 StaffId { get; set; }
    }
    public class StaffDetails_Staffs : Staffs
    {
        public string Name { get; set; }
        public string Designation { get; set; }
    }
}
