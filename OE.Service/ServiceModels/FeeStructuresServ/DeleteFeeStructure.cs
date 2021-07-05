
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.FeeStructuresServ
{
    public class DeleteFeeStructure
    {
        public FeeStructures FeeStructures { get; set; }
        public long FeeStructureId { get; set; }

        public string Message { get; set; }
    }
}