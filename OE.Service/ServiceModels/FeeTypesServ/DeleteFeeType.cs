
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.FeeTypesServ
{
    public class DeleteFeeType
    {
        public FeeTypes FeeTypes { get; set; }
        public long FeeTypeId { get; set; }

        public string Message { get; set; }
    }
}