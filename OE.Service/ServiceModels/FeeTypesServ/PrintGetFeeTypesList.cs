
using OE.Data;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.FeeTypesServ
{
    public class PrintGetFeeTypesList
    {
        public IEnumerable<PrintGetFeeTypesList_FeeTypes> _FeeTypes { get; set; }
        public PrintGetFeeTypesList_Institutions Institution { get; set; }

    }
    public class PrintGetFeeTypesList_FeeTypes : FeeTypes
    {
        public string ClassName { get; set; }
    }
    public class PrintGetFeeTypesList_Institutions : Institutions
    {


    }
}