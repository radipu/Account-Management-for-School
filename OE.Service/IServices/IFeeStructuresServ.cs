
using OE.Service.ServiceModels.FeeStructuresServ;
using System.Collections.Generic;
namespace OE.Service
{
    public interface IFeeStructuresServ
    {        

        #region "Get Function Definitions"
        getFeeStructuresList getFeeStructuresList();
        GetFeeStructuresByClass GetFeeStructuresByClass(long StudentId, long ClassId, long ClassYear);
        dropdown_FeeStructures dropdown_FeeStructures(long feeTypeId);
        SearchFeeStructures SearchFeeStructures(SearchFeeStructures obj);
        #endregion "Get Function Definitions"

        IEnumerable<dropdown_TermNo> dropdown_TermNo(long feeTypeId, long classId);

        

        #region "Insert update and delete Function Definitions"  
        string InsertFeeStructure(InsertFeeStructure obj);
        string UpdateFeeStructure(UpdateFeeStructure obj);
        DeleteFeeStructure DeleteFeeStructure(DeleteFeeStructure obj);
        #endregion "Insert update and delete Function Definitions"  

        #region "Report Function Definitions"
        PrintGetFeeStructuresList PrintGetFeeStructuresList();
        #endregion "Report Function Definitions" 
       
    }
}
