
using OE.Data;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.StudentDiscountsVM
{
    public class PrintIndexStudentDiscountsListVM
    {
        public IList<PrintIndexStudentDiscountsListVM_StudentDiscounts> _StudentDiscounts { get; set; }
        public PrintIndexStudentDiscountsListVM_StudentDiscounts StudentDiscounts { get; set; }
        public PrintIndexStudentDiscountsListVM_Institutions Institution { get; set; }
    }
    public class PrintIndexStudentDiscountsListVM_StudentDiscounts : StudentDiscounts
    {
        public string FeeType { get; set; }
        public string StudentName { get; set; }
        public decimal Amount { get; set; }
    }
    public class PrintIndexStudentDiscountsListVM_Institutions : Institutions
    {
    }
}