
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.PaymentTypesServ
{
    public class UpdatePaymentType
    {
        public IList<UpdatePaymentType_PaymentTypes> _PaymentTypes { get; set; }
        public PaymentTypes PaymentTypes { get; set; }
    }

    public class UpdatePaymentType_PaymentTypes : PaymentTypes
    {

    }
}