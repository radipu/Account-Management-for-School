
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.StaffsServ
{
    public class getStaffsList
    {
        public IEnumerable<getStaffsList_Staffs> _Staffs { get; set; }        
        public string WebRootPath { get; set; }
        public getStaffsList_Staffs Staffs { get; set; }        
    }
    public class getStaffsList_Staffs : Staffs
    {
        public string Name { get; set; }
        public string Designation { get; set; }       
        public string GenderName { get; set; }
        
    }
}

