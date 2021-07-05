using System;
namespace OE.Data
{
    public class Salaries : BaseEntity
    {
        public Int64 StaffId { get; set; }
        public DateTime Date { get; set; }        
        public Int64 TermNo { get; set; }
        public Int64 SalaryTypeId { get; set; }
        public decimal Amount { get; set; }
        public string Remark { get; set; }
    }
}