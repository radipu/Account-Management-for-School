using System;
using System.ComponentModel.DataAnnotations;

namespace OE.Data
{
    public class Users : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IP300X200 { get; set; }
        public string IP600X400 { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Int64 GenderId { get; set; }
        public string OurEduId { get; set; }
        public string Password { get; set; }
        public bool IsForgetPassword { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? LastEntryDate { get; set; }
        public DateTime? LastLogoutDate { get; set; }
        public string RegistrationNo { get; set; }
    }
}
