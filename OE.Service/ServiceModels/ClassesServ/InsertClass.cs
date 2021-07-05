using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.ClassesServ
{
    public class InsertClass2
    {        
        public InsertClass_Classes Classes { get; set; }       
        public IEnumerable<InsertClass_Classes> _Classes { get; set; }

    }
    public class InsertClass_Classes : Classes
    {

    }
}