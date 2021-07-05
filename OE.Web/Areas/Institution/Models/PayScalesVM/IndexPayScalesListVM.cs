using OE.Data;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.PayScalesVM
{
    public class IndexPayScalesListVM
    {
        public IList<IndexPayScalesListVM_PayScales> _PayScales { get; set; }
        public IndexPayScalesListVM_PayScales PayScales { get; set; }
    }
    public class IndexPayScalesListVM_PayScales : PayScales
    {
        public string DesignationName { get; set; }       
        public string StaffName { get; set; }        
        public string Year { get; set; }        
    }
}