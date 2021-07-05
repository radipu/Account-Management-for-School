
using OE.Data;
using System;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.FeeStructuresServ
{
    public class PrintGetFeeStructuresList
    {
        public IEnumerable<PrintGetFeeStructuresList_FeeStructures> _FeeStructures { get; set; }
        public PrintGetFeeStructuresList_FeeStructures FeeStructures { get; set; }
        public PrintGetFeeStructuresList_Institutions Institution { get; set; }
    }
    public class PrintGetFeeStructuresList_FeeStructures : FeeStructures
    {
        public string FeeType { get; set; }
        public string Class { get; set; }
        public Int64 FeeTypeMood { get; set; }
    }
    public class PrintGetFeeStructuresList_Institutions : Institutions
    {

    }
}
