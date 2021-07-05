
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.DesignationsServ
{
    public class UpdateDesignation
    {
        public IList<UpdateDesignation_Designations> _Designations { get; set; }       
        public UpdateDesignation_Designations Designations { get; set; }        
    }
    public class UpdateDesignation_Designations : Designations
    {

    }
}

