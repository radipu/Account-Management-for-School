
using OE.Data;
using System;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.FeeStructuresVM
{
    public class PrintIndexFeeStructuresListVM
    {
        public IList<PrintIndexFeeStructuresListVM_FeeStructures> _FeeStructures { get; set; }
        public PrintIndexFeeStructuresListVM_FeeStructures FeeStructures { get; set; }
        public PrintIndexFeeStructuresListVM_Institutions Institution { get; set; }
        public string SearchClassId { get; set; }
        public decimal ammount { get; set; }
        public Int64 Year { get; set; }
        public string SearchClassName { get; set; }
    }
    public class PrintIndexFeeStructuresListVM_FeeStructures : FeeStructures
    {
        public string FeeType { get; set; }
        public string Class { get; set; }
        public Int64 FeeTypeMood { get; set; }
    }
    public class PrintIndexFeeStructuresListVM_Institutions : Institutions
    {

    }
}

