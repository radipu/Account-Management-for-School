
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.SalarysServ
{
    public class DeleteSalary
    {
        public Salaries Salarys { get; set; }
        public long SalaryId { get; set; }
    }
}