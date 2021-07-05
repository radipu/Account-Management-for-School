using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.ClassesServ
{
    public class UpdateClass
    {
        public IList<InsertClass_Classes> _Classes { get; set; }       
        public UpdateClass_Classes Classes { get; set; }        
    }
    public class UpdateClass_Classes : Classes
    {

    }
}
