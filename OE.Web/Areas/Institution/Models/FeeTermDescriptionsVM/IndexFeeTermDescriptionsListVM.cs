using OE.Data;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.FeeTermDescriptionsVM
{
    public class IndexFeeTermDescriptionsListVM
    {
        public IList<IndexFeeTermDescriptionsListVM_FeeTermDescriptions> _FeeTermDescriptions { get; set; }
        public IndexFeeTermDescriptionsListVM_FeeTermDescriptions FeeTermDescriptions { get; set; }
        public string SearchFeetypeClassId { get; set; }
        public string SearchClassName { get; set; }
    }
    public class IndexFeeTermDescriptionsListVM_FeeTermDescriptions : FeeTermDescriptions
    {
        public string ClassName { get; set; }
        public long ClassId { get; set; }
      
        public long FeeTypeId { get; set; }
        public string FeeType { get; set; }
    }
}