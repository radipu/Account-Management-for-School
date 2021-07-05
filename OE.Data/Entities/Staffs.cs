using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OE.Data
{
    public class Staffs : BaseEntity
    {
        [Required(ErrorMessage ="Please enter designation")]
        public Int64 DesignationId { get; set; }
        [Required(ErrorMessage ="Please enter the first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Please enter the last name")]
        public string LastName { get; set; }      
        public string IP300X200 { get; set; }
        public Int64 GenderId { get; set; }
        [Required(ErrorMessage ="Please enter cell number")]
        public string Cell { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Education { get; set; }
    }
}