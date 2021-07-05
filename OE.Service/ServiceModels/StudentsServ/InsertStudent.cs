
using Microsoft.AspNetCore.Http;
using OE.Data;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.StudentsServ
{
    public class InsertStudent
    {
        public IList<InsertStudent_Students> _Students { get; set; }       
        public InsertStudent_Students Students { get; set; }      
        public InsertStudent_StudentPromotions StudentPromotions { get; set; }       
        public string WebRootPath { get; set; }    
        public string insertmessage { get; set; }
    }
    public class InsertStudent_Students : Students
    {       
        public IFormFile fleImage { get; set; }       
        public string Year { get; set; }      
    }

    public class InsertStudent_StudentPromotions : StudentPromotions    
    {      
        public string Year { get; set; }       
    }
}
