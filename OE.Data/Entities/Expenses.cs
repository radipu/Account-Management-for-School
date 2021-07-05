using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OE.Data
{
    public class Expenses : BaseEntity
    {
        public string Name { get; set; }
        [Required(ErrorMessage ="Please enter the expense amount")]
        public decimal Amount { get; set; }
        [Required(ErrorMessage ="Please enter the expense date")]
        public DateTime Date { get; set; }
        public Int64 ExpenseTypeId { get; set; }
    }
}

