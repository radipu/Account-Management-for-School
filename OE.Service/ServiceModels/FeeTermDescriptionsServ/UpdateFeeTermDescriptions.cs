
using OE.Data;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.FeeTermDescriptionsServ
{
    public class UpdateFeeTermDescriptions
    {
        public IList<UpdateFeeTermDescriptions_FeeTermDescriptions> _FeeTermDescriptions { get; set; }       
        public UpdateFeeTermDescriptions_FeeTermDescriptions FeeTermDescriptions { get; set; }        
    }
    public class UpdateFeeTermDescriptions_FeeTermDescriptions : FeeTermDescriptions
    {
        public long ClassId { get; set; }

        public long FeeTypeId { get; set; }
    }
}