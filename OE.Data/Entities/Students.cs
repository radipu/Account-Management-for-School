using System;
using System.ComponentModel.DataAnnotations;

namespace OE.Data
{
    public class Students : BaseEntity
    {
        public Int64 ClassId { get; set; }
        public Int64 GenderId { get; set; }
        [Required(ErrorMessage ="Please enter a valid reg. ID")]
        public string RegistrationNo { get; set; }
        [Required(ErrorMessage ="Please enter student first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Please enter student last name")]
        public string LastName { get; set; }
        public string IP300X200 { get; set; }
        public DateTime AdmittedYear { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        [Required(ErrorMessage ="Student age must be at least 10 years")]
        //[MinimumAge(10)]
        //[DataType(DataType.Date), DisplayFormat(DisplayFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        public Boolean IsActive { get; set; }
        public Int64 AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public Int64 ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string DataType { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
    }
}