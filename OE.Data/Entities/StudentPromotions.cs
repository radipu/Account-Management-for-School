using System;
using System.ComponentModel.DataAnnotations;

namespace OE.Data
{
    public class StudentPromotions:BaseEntity
    {
        public Int64 StudentId { get; set; }
        public Int64 ClassId { get; set; }
        [Required(ErrorMessage ="Please enter roll no.")]
        public Int64 RollNo { get; set; }
        public Nullable<DateTime> ClassYear { get; set; }
        public bool IsActive { get; set; }
        public Int64 AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public Int64 ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string DataType { get; set; }
    }
}