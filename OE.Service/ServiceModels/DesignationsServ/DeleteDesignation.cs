
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.DesignationsServ
{
    public class DeleteDesignation
    {
        public Designations Designations { get; set; }
        public long DesignationId { get; set; }
    }
}
