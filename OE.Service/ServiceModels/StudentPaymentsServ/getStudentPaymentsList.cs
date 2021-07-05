
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.StudentPaymentsServ
{
    public class getStudentPaymentsList
    {
        public IEnumerable<getStudentPaymentsList_StudentPayments> _StudentPayments { get; set; }

    }
    public class getStudentPaymentsList_StudentPayments : StudentPayments
    {
        public string StudentName { get; set; }
        public string FeeType { get; set; }
        public decimal Amount { get; set; }       
        public decimal FeeAmount { get; set; }
        public decimal AmountToPay { get; set; }       
    }
}