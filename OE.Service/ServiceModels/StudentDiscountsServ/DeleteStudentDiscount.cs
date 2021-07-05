
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.StudentDiscountsServ
{
    public class DeleteStudentDiscount
    {
        public StudentDiscounts StudentDiscounts { get; set; }
        public long StudentDiscountId { get; set; }

        public string Message { get; set; }
    }
}