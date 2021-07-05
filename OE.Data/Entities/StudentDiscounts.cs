
using System;

namespace OE.Data
{
    public class StudentDiscounts : BaseEntity 
    {
        public Int64 StudentId { get; set; }
        public Int64 FeeTypeId { get; set; }
        public decimal DiscountAmout { get; set; }
    }
}