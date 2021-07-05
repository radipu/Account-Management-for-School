
using OE.Data;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.FeeTypesServ
{
    public class getFeeTypesList
    {
        public IEnumerable<getFeeTypesList_FeeTypes> _FeeTypes { get; set; }


    }
    public class getFeeTypesList_FeeTypes : FeeTypes
    {
        public string ClassName { get; set; }
    }
}
