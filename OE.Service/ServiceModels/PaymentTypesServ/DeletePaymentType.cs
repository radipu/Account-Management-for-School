
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.PaymentTypesServ
{
    public class DeletePaymentType
    {
        public PaymentTypes PaymentTypes { get; set; }
        public long PaymentTypeId { get; set; }

        public string Message { get; set; }
    }
}