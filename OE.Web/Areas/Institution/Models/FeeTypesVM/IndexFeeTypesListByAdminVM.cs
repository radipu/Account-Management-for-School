
using OE.Data;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.FeeTypesVM
{
    public class IndexFeeTypesListByAdminVM
    {
        public IList<IndexFeeTypesListByAdminVM_FeeTypes> _FeeTypes { get; set; }
        public IndexFeeTypesListByAdminVM_FeeTypes FeeTypes { get; set; }
        public string SearchFeetypeClassId { get; set; }
        public string SearchClassName { get; set; }

    }
    public class IndexFeeTypesListByAdminVM_FeeTypes : FeeTypes
    {
        public string ClassName { get; set; }
    }
}