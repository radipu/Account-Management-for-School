
using Microsoft.AspNetCore.Http;
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.StaffsServ
{
    public class InsertStaff
    {
        public IEnumerable<InsertStaff_Staffs> _Staffs { get; set; }       
        public InsertStaff_Staffs Staffs { get; set; }
        public string WebRootPath { get; set; }       
    }
    public class InsertStaff_Staffs : Staffs
    {       
        public IFormFile fleImage { get; set; }        
    }
}