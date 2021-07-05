using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.PaymentTypesServ
{
    public class InsertPaymentType
    {
        public IList<InsertPaymentTypet_PaymentTypes> _PaymentTypes { get; set; }
        public InsertPaymentTypet_PaymentTypes PaymentTypes { get; set; }
    }
    public class InsertPaymentTypet_PaymentTypes : PaymentTypes
    {
        
    }    
}