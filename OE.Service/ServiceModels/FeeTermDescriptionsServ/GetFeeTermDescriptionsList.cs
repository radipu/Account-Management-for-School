
using OE.Data;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.FeeTermDescriptionsServ
{
    public class GetFeeTermDescriptionsList
    {
        public IEnumerable<GetFeeTermDescriptionsList_FeeTermDescriptions> _FeeTermDescriptions { get; set; }

    }
    public class GetFeeTermDescriptionsList_FeeTermDescriptions : FeeTermDescriptions
    {
        public string ClassName { get; set; }
        public string FeeType { get; set; }
        public long ClassId { get; set; }
        public long FeeTypeId { get; set; }
    }
}