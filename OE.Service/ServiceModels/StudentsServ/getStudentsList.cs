
using System;
using OE.Data;
using System.Collections.Generic;
using System.Text;


namespace OE.Service.ServiceModels.StudentsServ.getStudentsList
{
    public class getStudentsList
    {
        public IEnumerable<getStudentsList_Students> _Students { get; set; }       
        public string WebRootPath { get; set; }        
    }
    public class getStudentsList_Students : Students
    {
        public string ClassName { get; set; }
        public string GenderName { get; set; }
        public string StudentName { get; set; }        
        public Int64 RollNO { get; set; }
        public Int64 CurrentClassId { get; set; }
        public string CurrentClassName { get; set; }       
        public DateTime? CurrentYear { get; set; }        
    }

}

