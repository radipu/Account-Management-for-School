
using Microsoft.AspNetCore.Http;
using OE.Data;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.StudentsServ
{
    public class UpdateStudent
    {
        public IList<UpdateStudent_Students> _Students { get; set; }       
        public UpdateStudent_Students Students { get; set; }     
        public UpdateStudent_StudentPromotions StudentPromotions { get; set; }        
        public string WebRootPath { get; set; }        
    }
    public class UpdateStudent_Students : Students
    {       
        public IFormFile fleImage { get; set; }       
        public string Year { get; set; }       
    }

    public class UpdateStudent_StudentPromotions : StudentPromotions    
    {        
        public string Year { get; set; }        
    }
}
