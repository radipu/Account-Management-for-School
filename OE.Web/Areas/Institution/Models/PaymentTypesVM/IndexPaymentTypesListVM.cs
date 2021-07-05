
using OE.Data;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.PaymentTypesVM
{
    public class IndexPaymentTypesListVM
    {
        public IList<Vm_PaymentTypes> _PaymentTypes { get; set; }
        public Vm_PaymentTypes PaymentTypes { get; set; }
    }
    public class Vm_PaymentTypes : PaymentTypes
    {

    }
}