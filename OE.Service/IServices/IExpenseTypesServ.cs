
using System;
using System.Collections.Generic;
using OE.Service.ServiceModels.ExpenseTypesServ;
using System.Text;

namespace OE.Service
{
    public interface IExpenseTypesServ
    {
        #region "Get Function Definitions"
        getExpenseTypeList getExpenseTypesList();
        IEnumerable<dropdown_ExpenseTypes> dropdown_ExpenseTypes();
        #endregion "Get Function Definitions"

        
        #region "Insert update and delete Function Definitions"  
        string InsertExpenseType(InsertExpenseType obj);
        string UpdateExpenseType(UpdateExpenseType obj);
        DeleteExpenseType DeleteExpenseType(DeleteExpenseType obj);

        //StudentDetails StudentDetails(StudentDetails obj);

        #endregion "Insert update and delete Function Definitions"         

        #region "Report Function Definitions"
        PrintGetExpenseTypeList PrintGetExpenseTypesList();
        #endregion "Report Function Definitions"
      


    }
}
