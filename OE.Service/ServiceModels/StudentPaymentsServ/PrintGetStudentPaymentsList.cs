
using OE.Data;
using System;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.StudentPaymentsServ
{
    public class PrintGetStudentPaymentsList
    {
        public IEnumerable<PrintGetStudentPaymentsList_StudentPayments> _StudentPayments { get; set; }
        public PrintGetStudentPaymentsList_StudentPayments StudentPayments { get; set; }
        public Int64 PaymentId { get; set; }
        public PrintGetStudentPaymentsList_Institutions Institution { get; set; }
    }
    public class PrintGetStudentPaymentsList_StudentPayments : StudentPayments
    {
        public string StudentName { get; set; }
        public string FeeType { get; set; }
        public decimal Amount { get; set; }     
        public decimal FeeAmount { get; set; }
        public decimal AmountToPay { get; set; }       
    }
    public class PrintGetStudentPaymentsList_Institutions : Institutions
    {

    }
}
