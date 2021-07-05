
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OE.Data
{
    public class Designations : BaseEntity
    {
        [Required(ErrorMessage = "Please enter designation name")]
        public string Name { get; set; }
    }
}
