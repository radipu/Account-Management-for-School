using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using OE.Data;
namespace OE.Web.Areas.Institution.Models.ClassesVM
{
    public class PrintIndexClassesVM
    {
        public string InstitutionName { get; set; }
        public string Logo { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }       
        public PrintIndexClassesVM_Classes classesVM { get; set; }
        public List<PrintIndexClassesVM_Classes> _classesVM { get; set; }        
        public SelectList _InstitutionsListVM { get; set; }
    }
    
    public class PrintIndexClassesVM_Classes : Classes   
    {
        //[NOTE: Extra Field]
        public string InsCategoryName { get; set; }
        public string DepartmentName { get; set; }
    }
}

