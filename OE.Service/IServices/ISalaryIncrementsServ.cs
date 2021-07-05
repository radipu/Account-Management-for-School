
using OE.Service.ServiceModels.SalaryIncrementsServ;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service
{
    public interface ISalaryIncrementsServ
    {
        #region "Get Function Definitions"
        getSalaryIncrementsList getSalaryIncrementsList();

        #endregion "Get Function Definitions"

        #region "Insert update and delete Function Definitions"  
        string InsertSalaryIncrement(InsertSalaryIncrement obj);
        string UpdateSalaryIncrement(UpdateSalaryIncrement obj);
        DeleteSalaryIncrement DeleteSalaryIncrement(DeleteSalaryIncrement obj);
        #endregion "Insert update and delete Function Definitions"  
    }
}
