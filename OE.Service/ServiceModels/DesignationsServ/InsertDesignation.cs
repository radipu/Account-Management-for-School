
using System;
using System.Collections.Generic;
using System.Text;
using OE.Data;

namespace OE.Service.ServiceModels.DesignationsServ
{
    public class InsertDesignation
    {
        public IList<InsertDesignation_Designations> _Designations { get; set; }
        public InsertDesignation_Designations Designations { get; set; }
    }
    public class InsertDesignation_Designations : Designations
    {

    }
}

