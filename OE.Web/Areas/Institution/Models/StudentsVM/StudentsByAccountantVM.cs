
using Microsoft.AspNetCore.Http;
using OE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OE.Web.Areas.Institution.Models.StudentsVM
{
    public class StudentsByAccountantVM
    {
        public IList<StudentsByAccountantVM_Students> _Students { get; set; }
        public StudentsByAccountantVM_Students Students { get; set; }
        public string SearchStudentClassId { get; set; }        
        public string ClassName { get; set; }
        public object SearchStudentCurrentClassId { get; set; }
    }

    public class StudentsByAccountantVM_Students : Students
    {
        public string ClassName { get; set; }
        public string GenderName { get; set; }
        public string StudentName { get; set; }
        public Int64 StudentId { get; set; }       
        public Int64 CurrentClassId { get; set; }
        public string CurrentClassName { get; set; }       
        public DateTime? CurrentYear { get; set; }       
        public IFormFile fleImage { get; set; }
        public object ParentsName { get; set; }
    }
}
