
using OE.Service.ServiceModels.PayScalesServ;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service
{
    public interface IPayScalesServ
    {
        #region "Get Function Definitions"
        getPayScalesList getPayScalesList();
        #endregion "Get Function Definitions"

        
        #region "Insert update and delete Function Definitions"  
        string InsertPayScale(InsertPayScale obj);
        string UpdatePayScale(UpdatePayScale obj);
        DeletePayScale DeletePayScale(DeletePayScale obj);
        #endregion "Insert update and delete Function Definitions"  
        
    }
}
