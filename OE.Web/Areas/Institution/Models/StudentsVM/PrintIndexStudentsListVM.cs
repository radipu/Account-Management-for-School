
using OE.Data;
using System;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.StudentsVM
{
    public class PrintIndexStudentsListVM
    {
        public IList<PrintIndexStudentsListVM_Students> _Students { get; set; }
        public PrintIndexStudentsListVM_Students Students { get; set; }
        public PrintIndexStudentsListVM_Institutions Institution { get; set; }

    }

    public class PrintIndexStudentsListVM_Students : Students
    {
        public string ClassName { get; set; }
        public string GenderName { get; set; }
        public string StudentName { get; set; }
        public Int64 StudentId { get; set; }
        public string ParentsName { get; set; }
    }
    public class PrintIndexStudentsListVM_Institutions : Institutions
    {

    }
}
