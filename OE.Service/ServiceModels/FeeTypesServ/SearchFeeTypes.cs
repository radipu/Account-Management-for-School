
using OE.Data;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.FeeTypesServ
{
    public class SearchFeeTypes
    {
        public IEnumerable<SearchFeeTypes_FeeTypes> _FeeTypes { get; set; }
        public FeeTypes FeeTypes { get; set; }
        public string SearchFeetypeClassId { get; set; }
        public string SearchClassName { get; set; }

    }
    public class SearchFeeTypes_FeeTypes : FeeTypes
    {
        public string ClassName { get; set; }

    }
}