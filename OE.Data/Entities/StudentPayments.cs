
using System;

namespace OE.Data
{
    public class StudentPayments : BaseEntity
    {       
        public Int64 ClassId { get; set; }
        public DateTime? FeeYearDate { get; set; }    
        public Int64? StudentId { get; set; }             
        public Int64 FeeTypeId { get; set; }       
        public decimal? PaidAmount { get; set; }       
        public Int64 FeeTermDescriptionId { get; set; }        
        public DateTime? PaymentDate { get; set; }       
        public decimal? Fine { get; set; }       
        public string Remarks { get; set; }      
    }
}