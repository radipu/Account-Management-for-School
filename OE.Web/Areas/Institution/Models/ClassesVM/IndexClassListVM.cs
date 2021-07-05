
using OE.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace OE.Web.Areas.Institution.Models.ClassesVM
{
    public class IndexClassListVM
    {
        public IList<Vm_Classes> _Classes { get; set; }
        public Vm_Classes Classes { get; set; }
    }

    public class Vm_Classes : Classes
    {
        
    }
}
