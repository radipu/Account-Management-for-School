
using System;
using System.ComponentModel.DataAnnotations;
namespace OE.Data
{
    public class FeeTermDescriptions : BaseEntity
    {
        public Int64 FeeStructureId { get; set; }
        public Int64 TermNo { get; set; }
        [Required(ErrorMessage ="Please enter the term name")]
        public string TermName { get; set; }
    }
}
