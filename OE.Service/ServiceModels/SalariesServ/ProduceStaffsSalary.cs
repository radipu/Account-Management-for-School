
using OE.Data;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.SalariesServ
{
    public class ProduceStaffsSalary
    {
        public IEnumerable<ProduceStaffsSalary_Staffs> _Staffs { get; set; }
        public string WebRootPath { get; set; }
        public ProduceStaffsSalary_Staffs Staffs { get; set; }
    }
    public class ProduceStaffsSalary_Staffs : Staffs
    {
        public string Name { get; set; }
        public string Designation { get; set; }
        public string GenderName { get; set; }
    }
}