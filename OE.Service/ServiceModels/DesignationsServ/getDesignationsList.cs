using System;
using System.Collections.Generic;
using System.Text;
using OE.Data;

namespace OE.Service.ServiceModels.DesignationsServ
{
    public class getDesignationsList
    {
        public IEnumerable<getDesignationsList_Designations> _Designations { get; set; }
        public Designations Designations { get; set; }
    }
    public class getDesignationsList_Designations : Designations
    {

    }
}