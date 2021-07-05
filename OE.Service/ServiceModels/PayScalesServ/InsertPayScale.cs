
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.PayScalesServ
{
    public class InsertPayScale
    {
        public IEnumerable<InsertPayScale_PayScales> _PayScales { get; set; }        
        public InsertPayScale_PayScales PayScales { get; set; }       
    }
    public class InsertPayScale_PayScales : PayScales
    {        
        public string Year { get; set; }        
    }
}
