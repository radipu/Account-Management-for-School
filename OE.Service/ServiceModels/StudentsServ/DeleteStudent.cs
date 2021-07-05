using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.StudentsServ
{
    public class DeleteStudent
    {
        public Students Students { get; set; }
        public long StudentId { get; set; }      
        public StudentPromotions StudentPromotions { get; set; }  
        public string Message { get; set; }        
        public string WebRootPath { get; set; }       
    }
}
