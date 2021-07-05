
using OE.Data;
using System;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.StudentPaymentsVM
{
    public class IndexStudentPaymentsListVM
    {
        public IList<IndexStudentPaymentsListVM_StudentPayments> _StudentPayments { get; set; }
        public IndexStudentPaymentsListVM_StudentPayments StudentPayments { get; set; }
        public string SearchId { get; set; }      
        public Int64 StudentId { get; set; }
        
    }
    public class IndexStudentPaymentsListVM_StudentPayments : StudentPayments
    {
        public string StudentName { get; set; }
        public string FeeType { get; set; }
        public decimal Amount { get; set; }        
        public decimal FeeAmount { get; set; }
        public decimal AmountToPay { get; set; }
        
    }

}