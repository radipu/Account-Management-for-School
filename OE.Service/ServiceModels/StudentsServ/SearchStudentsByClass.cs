
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.StudentsServ
{
    public class SearchStudentsByClass
    {
        public IEnumerable<SearchStudentsByClass_Students> _Students { get; set; }
        public string SearchStudentClassId { get; set; }
        public string SearchStudentClassName { get; set; }        
        public string WebRootPath { get; set; }
        public string SearchStudentCurrentClassId { get; set; }
        public string SearchStudentCurrentClassName { get; internal set; }
    }
    public class SearchStudentsByClass_Students : Students
    {
        public string ClassName { get; set; }
        public string GenderName { get; set; }
        public string StudentName { get; set; }  
        public Int64 RollNO { get; set; }
        public Int64 CurrentClassId { get; set; }
        public string CurrentClassName { get; set; }       
        public DateTime? CurrentYear { get; set; }
        public object ParentsName { get; set; }
    }
}
