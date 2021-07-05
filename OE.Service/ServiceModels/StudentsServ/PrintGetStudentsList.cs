
using OE.Data;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.StudentsServ
{
    public class PrintGetStudentsList
    {
        public IEnumerable<PrintGetStudentsList_Students> _Students { get; set; }
        public PrintGetStudentsList_Institutions Institution { get; set; }
    }
    public class PrintGetStudentsList_Students : Students
    {
        public string ClassName { get; set; }
        public string GenderName { get; set; }
        public string StudentName { get; set; }
        public string ParentsName { get; set; }
    }
    public class PrintGetStudentsList_Institutions : Institutions
    {

    }
}