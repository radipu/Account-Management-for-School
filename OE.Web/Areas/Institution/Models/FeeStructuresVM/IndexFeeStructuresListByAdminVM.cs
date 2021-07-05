
using OE.Data;
using System;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.FeeStructuresVM
{
    public class IndexFeeStructuresListByAdminVM
    {
        public IList<IndexFeeStructuresListByAdminVM_FeeStructures> _FeeStructures { get; set; }
        public IndexFeeStructuresListByAdminVM_FeeStructures FeeStructures { get; set; }
        public string SearchClassId { get; set; }
        public decimal ammount { get; set; }
       
        public string SearchClassName { get; set; }
    }
    public class IndexFeeStructuresListByAdminVM_FeeStructures : FeeStructures
    {
        public string FeeType { get; set; }
        public string Class { get; set; }
        public Int64 FeeTypeMood { get; set; }
    }
}
