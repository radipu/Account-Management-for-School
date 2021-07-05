
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.FeeStructuresServ
{
    public class InsertFeeStructure
    {
        public IList<InsertFeeStructure_FeeStructures> _FeeStructures { get; set; }       
        public InsertFeeStructure_FeeStructures FeeStructures { get; set; }       
    }
    public class InsertFeeStructure_FeeStructures : FeeStructures
    {        
        public string StartYear { get; set; }
        public string EndYear { get; set; }       
    }
}