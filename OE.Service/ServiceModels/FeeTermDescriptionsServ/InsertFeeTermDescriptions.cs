
using OE.Data;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.FeeTermDescriptionsServ
{
    public class InsertFeeTermDescriptions
    {
        public IList<InsertFeeTermDescriptions_FeeTermDescriptions> _FeeTermDescriptions { get; set; }        
        public InsertFeeTermDescriptions_FeeTermDescriptions FeeTermDescriptions { get; set; }        
    }
    public class InsertFeeTermDescriptions_FeeTermDescriptions : FeeTermDescriptions
    {
        public long ClassId { get; set; }
       
        public long FeeTypeId { get; set; }
    }
}