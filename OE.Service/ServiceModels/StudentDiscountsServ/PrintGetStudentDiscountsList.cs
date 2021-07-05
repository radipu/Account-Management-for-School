
using OE.Data;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.StudentDiscountsServ
{
    public class PrintGetStudentDiscountsList
    {
        public IEnumerable<PrintGetStudentDiscountsList_StudentDiscounts> _StudentDiscounts { get; set; }
        public PrintGetStudentDiscountsList_Institutions Institution { get; set; }
    }
    public class PrintGetStudentDiscountsList_StudentDiscounts : StudentDiscounts
    {
        public string FeeType { get; set; }
        public string StudentName { get; set; }
    }
    public class PrintGetStudentDiscountsList_Institutions : Institutions
    {


    }
}

