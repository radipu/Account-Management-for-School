
using System;

namespace OE.Web.Models
{
    public class IndexLoginVM
    {
        public string InstitutionName { get; set; }
        public string Logo { get; set; }

        //[NOTE: Extra field from Users]
        public string OurEduId { get; set; }
        public string Password { get; set; }
        public Nullable<DateTime> LastEntryDate { get; set; }       
           
    }
}
