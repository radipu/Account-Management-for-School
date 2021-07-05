
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.StudentDiscountsServ
{
    public class getStudentDiscountsList
    {
        public IEnumerable<getStudentDiscountsList_StudentDiscounts> _StudentDiscounts { get; set; }
    }
    public class getStudentDiscountsList_StudentDiscounts : StudentDiscounts
    {
        public string FeeType { get; set; }
        public string StudentName { get; set; }  
        public string RegistrationNo { get; set; }       
        public Int64 ClassId { get; set; }
        public string ClassName { get; set; }       
    }
}