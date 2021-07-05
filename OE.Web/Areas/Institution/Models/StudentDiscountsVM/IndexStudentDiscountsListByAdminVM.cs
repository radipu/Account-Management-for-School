
using OE.Data;
using System;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.StudentDiscountsVM
{
    public class IndexStudentDiscountsListByAdminVM
    {
        public IList<IndexStudentDiscountsListByAdminVM_StudentDiscounts> _StudentDiscounts { get; set; }
        public IndexStudentDiscountsListByAdminVM_StudentDiscounts StudentDiscounts { get; set; }
    }
    public class IndexStudentDiscountsListByAdminVM_StudentDiscounts : StudentDiscounts
    {
        public string FeeType { get; set; }
        public string StudentName { get; set; }
        public decimal Amount { get; set; }
        public string RegistrationNo { get; set; }
        public Int64 ClassId { get; set; }
        public string ClassName { get; set; }
    }
}