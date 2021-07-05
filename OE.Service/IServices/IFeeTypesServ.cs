
using System;
using System.Collections.Generic;
using System.Text;
using OE.Service.ServiceModels.FeeTypesServ;


namespace OE.Service
{
    public interface IFeeTypesServ
    {        
        #region "Get Function Definitions"
        getFeeTypesList getFeeTypesList();
        IEnumerable<dropdown_FeeType> dropdown_FeeType(long classId);
        SearchFeeTypes SearchFeeTypes(SearchFeeTypes obj);
        #endregion "Get Function Definitions"

        #region "Insert update and delete Function Definitions"
       
        string InsertFeeType(InsertFeeType obj);
        string UpdateFeeType(UpdateFeeType obj);
        DeleteFeeType DeleteFeeType(DeleteFeeType obj);
        #endregion "Insert update and delete Function Definitions"  

        #region "Report Function Definitions"
        PrintGetFeeTypesList PrintGetFeeTypesList();

        
        #endregion "Report Function Definitions"        
    }
}
