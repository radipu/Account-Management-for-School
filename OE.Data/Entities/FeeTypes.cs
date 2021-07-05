
using System;
using System.ComponentModel.DataAnnotations;

namespace OE.Data
{
    public class FeeTypes : BaseEntity
    {
        [Required(ErrorMessage ="Please select a class")]
        public Int64 ClassId { get; set; }
        [Required(ErrorMessage ="Please enter a type name")]
        public string Name { get; set; }        
        public bool IsActive { get; set; }        
    }
}
