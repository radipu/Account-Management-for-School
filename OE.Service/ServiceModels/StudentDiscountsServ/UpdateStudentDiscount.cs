
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.StudentDiscountsServ
{
    public class UpdateStudentDiscount
    {
        public IList<UpdateStudentDiscount_StudentDiscounts> _StudentDiscounts { get; set; }
        public UpdateStudentDiscount_StudentDiscounts StudentDiscounts { get; set; }
    }

    public class UpdateStudentDiscount_StudentDiscounts : StudentDiscounts
    {      
        public string RegistrationNo { get; set; }     
    }

}