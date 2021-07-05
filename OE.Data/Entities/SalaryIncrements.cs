
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Data
{
    public class SalaryIncrements : BaseEntity
    {
        public Int64 StaffId { get; set; }
        public Int64 DesigignationId { get; set; }
        public Int64 PayScalesId { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}