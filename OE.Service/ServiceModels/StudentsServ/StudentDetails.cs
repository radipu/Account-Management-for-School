
using Microsoft.AspNetCore.Http;
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.StudentsServ
{
    public class StudentDetails
    {
        public IEnumerable<StudentDetails_students> _Students { get; set; }
        public StudentDetails_students student { get; set; }
        public Int64 StudentId { get; set; }
    }
    public class StudentDetails_students : Students
    {
        // public IEnumerable<StudentDetails> _Students { get; set; }
        public string ClassName { get; set; }
        public string GenderName { get; set; }
        public string StudentName { get; set; }       
        public Int64 CurrentClassId { get; set; }
        public string CurrentClassName { get; set; }
        public DateTime CurrentYear { get; set; }
        public IFormFile fleImage { get; set; }
        public object ParentsName { get; set; }
        public new string FatherName { get; set; }
        public new string MotherName { get; set; }
       
    }
}

