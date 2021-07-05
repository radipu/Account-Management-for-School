
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.StudentDiscountsServ
{
    public class InsertStudentDiscount
    {
        public IList<InsertStudentDiscount_StudentDiscounts> _StudentDiscounts { get; set; }
        public InsertStudentDiscount_StudentDiscounts StudentDiscounts { get; set; }
    }
    public class InsertStudentDiscount_StudentDiscounts : StudentDiscounts
    {
        public string FeeType { get; set; }
        public string StudentName { get; set; }
        public decimal Amount { get; set; }
        public string RegistrationNo { get; set; }        
    }
}