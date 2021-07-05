
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.PaymentTypesServ
{
    public class getPaymentTypesList
    {
        public IEnumerable<getPaymentTypesList_PaymentTypes> _PaymentTypes { get; set; }
    }
    public class getPaymentTypesList_PaymentTypes : PaymentTypes
    {

    }
}