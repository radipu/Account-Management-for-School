
using System;
using System.ComponentModel.DataAnnotations;

namespace OE.Data
{
    public class FeeStructures : BaseEntity
    {
        public Int64 FeeTypeId { get; set; }
        public Int64 ClassId { get; set; }
        [Required(ErrorMessage ="Please enter the amount")]
        public decimal Amount { get; set; }      
        public Int64 YearlyTermNo { get; set; }       
        public DateTime? StartingYear { get; set; }
        public DateTime? EndingYear { get; set; }       
        public bool IsActive { get; set; }
    }
}
