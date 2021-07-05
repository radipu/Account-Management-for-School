using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OE.Data
{
    public class PayScales : BaseEntity
    {
        [Required(ErrorMessage ="Please select staff id")]
        public Int64 StaffId { get; set; }
        [Required(ErrorMessage ="Please enter the basic salary")]
        public decimal BasicSalary { get; set; }        
        public DateTime SalaryYear { get; set; }        
        public Int64 BasicSalaryTermNo { get; set; }
        public decimal BonusSalary { get; set; }
        public Int64 BonusSalaryTermNo { get; set; }       
    }
}