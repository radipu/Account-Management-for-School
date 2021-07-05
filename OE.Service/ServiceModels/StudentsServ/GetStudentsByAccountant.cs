
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.StudentsServ
{
    public class GetStudentsByAccountant
    {
        public IEnumerable<GetStudentsByAccountant_Students> _Students { get; set; }
    }
    public class GetStudentsByAccountant_Students : Students
    {
        public string ClassName { get; set; }
        public string GenderName { get; set; }
        public string StudentName { get; set; }
    }
}
