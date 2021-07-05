using OE.Data;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.FeeTypesVM
{
    public class PrintIndexFeeTypesListVM
    {
        public IList<PrintIndexFeeTypesListVM_FeeTypes> _FeeTypes { get; set; }
        public IndexFeeTypesListVM_FeeTypes FeeTypes { get; set; }
        public PrintIndexFeeTypesListVM_Institutions Institution { get; set; }
        public string SearchFeetypeClassId { get; set; }
        public string SearchClassName { get; set; }
    }
    public class PrintIndexFeeTypesListVM_FeeTypes : FeeTypes
    {
        public string ClassName { get; set; }
    }
    public class PrintIndexFeeTypesListVM_Institutions : Institutions
    {


    }
}

