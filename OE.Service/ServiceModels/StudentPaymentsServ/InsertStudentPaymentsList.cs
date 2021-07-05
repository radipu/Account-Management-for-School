
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.StudentPaymentsServ
{
    public class InsertStudentPayment
    {
        public IList<InsertStudentPayment_StudentPayments> _StudentPayments { get; set; }        
        public InsertStudentPayment_StudentPayments StudentPayments { get; set; }       
    }
    public class InsertStudentPayment_StudentPayments : StudentPayments
    {       
        public string FeeYear { get; set; }      
    }

}