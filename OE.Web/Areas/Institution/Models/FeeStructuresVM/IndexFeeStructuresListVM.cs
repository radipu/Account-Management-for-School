
using OE.Data;
using System;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.FeeStructuresVM
{
    public class IndexFeeStructuresListVM
    {
        public IList<Vm_FeeStructures> _FeeStructures { get; set; }
        public Vm_FeeStructures FeeStructures { get; set; }
        public string SearchClassId { get; set; }
        public decimal ammount { get; set; }       
        public string SearchClassName { get; set; }        
    }
    public class Vm_FeeStructures : FeeStructures
    {
        public string FeeType { get; set; }
        public string Class { get; set; }       
        public string StartYear { get; set; }
        public string EndYear { get; set; }        
        public Int64 FeeTypeMood { get; set; }        
    }
}
