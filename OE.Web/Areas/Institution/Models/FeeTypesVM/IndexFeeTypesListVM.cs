using OE.Data;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.FeeTypesVM
{
    public class IndexFeeTypesListVM
    {
        public IList<IndexFeeTypesListVM_FeeTypes> _FeeTypes { get; set; }
        public IndexFeeTypesListVM_FeeTypes FeeTypes { get; set; }
        public string SearchFeetypeClassId { get; set; }
        public string SearchClassName { get; set; }       
    }
    public class IndexFeeTypesListVM_FeeTypes : FeeTypes
    {
        public string ClassName { get; set; }
    }
}

