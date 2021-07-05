using OE.Data;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.PayScalesVM
{
    public class IndexPayScalesListByAdminVM
    {
        public IList<IndexPayScalesListByAdminVM_PayScales> _PayScales { get; set; }
        public IndexPayScalesListByAdminVM_PayScales PayScales { get; set; }
    }
    public class IndexPayScalesListByAdminVM_PayScales : PayScales
    {
        public string DesignationName { get; set; }      
        public string StaffName { get; set; }       
    }
}