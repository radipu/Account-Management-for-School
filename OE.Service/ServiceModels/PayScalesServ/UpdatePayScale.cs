
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.PayScalesServ
{
    public class UpdatePayScale
    {
        public IEnumerable<UpdatePayScale_PayScales> _PayScales { get; set; }        
        public UpdatePayScale_PayScales PayScales { get; set; }       
    }
    public class UpdatePayScale_PayScales : PayScales
    {       
        public string Year { get; set; }       
    }
}