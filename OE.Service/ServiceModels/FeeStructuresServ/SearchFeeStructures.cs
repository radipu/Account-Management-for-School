
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.FeeStructuresServ
{
    public class SearchFeeStructures
    {
        public IEnumerable<SearchFeeStructures_FeeStructures> _FeeStructures { get; set; }
        public FeeStructures FeeStructures { get; set; }
        public string SearchClassId { get; set; }
        public decimal DateRangeAmount { get; set; }
        public string SearchClassName { get; set; }        
    }
    public class SearchFeeStructures_FeeStructures : FeeStructures
    {
        public string FeeType { get; set; }
        public string Class { get; set; }
        public Int64 FeeTypeMood { get; set; }
    }
}