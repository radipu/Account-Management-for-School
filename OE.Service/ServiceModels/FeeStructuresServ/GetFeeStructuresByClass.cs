
using OE.Data;
using System;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.FeeStructuresServ
{
    public class GetFeeStructuresByClass
    {
        public IEnumerable<GetFeeStructuresByClass_FeeStructures> _FeeStructures { get; set; }       
        public string ClassName { get; set; }
        public long FeeYear { get; set; }       
    }
    public class GetFeeStructuresByClass_FeeStructures : FeeStructures
    {
        public decimal DiscountAmount { get; set; }
        public string FeeType { get; set; }        
        public string TermName { get; set; }
        public long TermNo { get; set; }

        public decimal? Fine { get; set; }
        public decimal? PaidAmount { get; set; }
        public string Remarks { get; set; }
        public long FeeTermDescriptionId { get; set; }       
        public string Class { get; set; }
        public Int64 FeeTypeMood { get; set; }      
    }
}