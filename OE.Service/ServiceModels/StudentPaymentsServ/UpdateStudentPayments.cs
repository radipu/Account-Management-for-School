
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.StudentPaymentsServ
{
    public class UpdateStudentPayment
    {
        public IList<UpdateStudentPayment_StudentPayments> _StudentPayments { get; set; }       
        public UpdateStudentPayment_StudentPayments StudentPayments { get; set; }       
    }
    public class UpdateStudentPayment_StudentPayments : StudentPayments
    {  
        public string FeeYear { get; set; }
       
    }
}