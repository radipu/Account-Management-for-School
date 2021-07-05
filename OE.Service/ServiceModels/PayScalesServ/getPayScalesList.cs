
using OE.Data;
using System;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.PayScalesServ
{
    public class getPayScalesList
    {
        public IEnumerable<getPayScalesList_PayScales> _PayScales { get; set; }
        public PayScales PayScales { get; set; }
    }
    public class getPayScalesList_PayScales : PayScales
    {
        public string DesignationName { get; set; }      
        public string StaffName { get; set; }
        public  Int64 DesignationId { get; set; }        
        public decimal netSalary { get; set; }       
    }
}
