
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.FeeTypesServ
{
    public class UpdateFeeType
    {
        public IList<UpdateFeeType_FeeTypes> _FeeTypes { get; set; }       
        public UpdateFeeType_FeeTypes FeeTypes { get; set; }        
    }
    public class UpdateFeeType_FeeTypes : FeeTypes
    {

    }
}