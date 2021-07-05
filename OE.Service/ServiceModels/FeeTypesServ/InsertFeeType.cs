
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.FeeTypesServ
{
    public class InsertFeeType
    {
        public IList<InsertFeeType_FeeTypes> _FeeTypes { get; set; }        
        public InsertFeeType_FeeTypes FeeTypes { get; set; }        
    }
    public class InsertFeeType_FeeTypes : FeeTypes
    {

    }
}