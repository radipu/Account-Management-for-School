
using OE.Data;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.StaffsServ
{
    public class PrintGetStaffsList
    {
        public IEnumerable<PrintGetStaffsList_Staffs> _Staffs { get; set; }
        public PrintGetStaffsList_Institutions Institution { get; set; }
    }
    public class PrintGetStaffsList_Staffs : Staffs
    {
        public string Name { get; set; }
        public string Designation { get; set; }

    }
    public class PrintGetStaffsList_Institutions : Institutions
    {

    }
}