
using System;
using System.Collections.Generic;
using System.Text;
using OE.Service.ServiceModels.PaymentTypesServ;

namespace OE.Service
{
    public interface IPaymentTypesServ
    {
        #region "Get Function Definitions"
        getPaymentTypesList getPaymentTypesList();
        IEnumerable<dropdown_PaymentTypes> dropdown_PaymentTypes();
        #endregion "Get Function Definitions"

        #region "Insert update and delete Function Definitions"  
        string InsertPaymentType(InsertPaymentType obj);
        string UpdatePaymentType(UpdatePaymentType obj);
        DeletePaymentType DeletePaymentType(DeletePaymentType obj);
        #endregion "Insert update and delete Function Definitions" 
    }
}