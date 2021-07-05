using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OE.Data
{
    public class ExpenseTypes : BaseEntity
    {
        [Required(ErrorMessage ="Please enter the expense name")]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
