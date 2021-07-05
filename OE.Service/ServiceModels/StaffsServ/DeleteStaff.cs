
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.StaffsServ
{
    public class DeleteStaff
    {
        public Staffs Staffs { get; set; }
        public long StaffId { get; set; }       
        public string WebRootPath { get; set; }       
    }
}
