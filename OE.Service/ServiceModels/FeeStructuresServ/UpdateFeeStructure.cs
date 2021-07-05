
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.FeeStructuresServ
{
    public class UpdateFeeStructure
    {
        public IList<UpdateFeeStructure_FeeStructures> _FeeStructures { get; set; }       
        public UpdateFeeStructure_FeeStructures FeeStructures { get; set; }       
    }
    public class UpdateFeeStructure_FeeStructures : FeeStructures
    {      
        public string StartYear { get; set; }
        public string EndYear { get; set; }        
    }
}