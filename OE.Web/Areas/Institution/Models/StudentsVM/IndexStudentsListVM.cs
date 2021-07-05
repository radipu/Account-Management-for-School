
using Microsoft.AspNetCore.Http;
using OE.Data;
using System;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.StudentsVM
{
    public class IndexStudentsListVM
    {
        public IList<Vm_Students> _Students { get; set; }
        public Vm_Students Students { get; set; }
        public string SearchStudentClassId { get; set; }       
        public string ClassName { get; set; }        
        public IndexStudentsListVM_StudentPromotions StudentPromotions { get; set; }       
    }

    public class Vm_Students : Students
    {
        public string ClassName { get; set; }
        public string GenderName { get; set; }
        public string StudentName { get; set; }
        public Int64 StudentId { get; set; }     
        public Int64 RollNO { get; set; }       
        public string Year { get; set; }       
        public Int64 CurrentClassId { get; set; }
        public string CurrentClassName { get; set; }
        public DateTime CurrentYear { get; set; }        
        public IFormFile fleImage { get; set; }
        public object ParentsName { get; set; }
    }
   
    public class IndexStudentsListVM_StudentPromotions : StudentPromotions
    {

    } 
}
