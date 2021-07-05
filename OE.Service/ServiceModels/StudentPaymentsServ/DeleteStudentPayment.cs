
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.StudentPaymentsServ
{
    public class DeleteStudentPayment
    {
        public StudentPayments StudentPayments { get; set; }
        public long StudentPaymentId { get; set; }

        public string Message { get; set; }

    }
}