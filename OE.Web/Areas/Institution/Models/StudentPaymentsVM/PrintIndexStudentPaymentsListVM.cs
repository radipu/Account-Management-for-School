
using OE.Data;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.StudentPaymentsVM
{
    public class PrintIndexStudentPaymentsListVM
    {
        public IList<PrintIndexStudentPaymentsListVM_StudentPayments> _StudentPayments { get; set; }
        public PrintIndexStudentPaymentsListVM_StudentPayments StudentPayments { get; set; }
        public string SearchId { get; set; }

        public PrintIndexStudentPaymentsListVM_Institutions Institution { get; set; }

    }
    public class PrintIndexStudentPaymentsListVM_StudentPayments : StudentPayments
    {

        public string StudentName { get; set; }
        public string FeeType { get; set; }
        public decimal Amount { get; set; }
        public decimal FeeAmount { get; set; }
        public decimal AmountToPay { get; set; }
    }

    public class PrintIndexStudentPaymentsListVM_Institutions : Institutions
    {

    }
}
