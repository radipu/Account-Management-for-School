
using Microsoft.AspNetCore.Http;
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.StaffsServ
{
    public class UpdateStaff
    {
        public IEnumerable<UpdateStaff_Staffs> _Staffs { get; set; }        
        public string WebRootPath { get; set; }
        public UpdateStaff_Staffs Staffs { get; set; }      
    }
    public class UpdateStaff_Staffs : Staffs
    {       
        public IFormFile fleImage { get; set; }        
    }
}