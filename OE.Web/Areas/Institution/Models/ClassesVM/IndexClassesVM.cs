using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using OE.Data;
namespace OE.Web.Areas.Institution.Models.ClassesVM
{
    public class IndexClassesVM
    {
        public string InstitutionName { get; set; }       
        public IndexClassesVM_Classes classesVM { get; set; }
        public List<IndexClassesVM_Classes> _classesVM { get; set; }        
        public SelectList _InstitutionsListVM { get; set; }
    }
    
    public class IndexClassesVM_Classes : Classes   
    {
        //[NOTE: Extra Field]       
        public string InsCategoryName { get; set; }
        public string DepartmentName { get; set; }
    }
}
