
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.FeeStructuresServ
{
    public class getFeeStructuresList
    {
        public IEnumerable<getFeeStructuresList_FeeStructures> _FeeStructures { get; set; }
        public FeeStructures FeeStructures { get; set; }
    }
    public class getFeeStructuresList_FeeStructures : FeeStructures
    {
        public string FeeType { get; set; }
        public string Class { get; set; }
        public Int64 FeeTypeMood { get; set; }      
    }
}