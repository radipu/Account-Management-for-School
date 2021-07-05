
using OE.Service.ServiceModels.FeeTermDescriptionsServ;
namespace OE.Service
{
    public interface IFeeTermDescriptionsServ
    {
        #region "Get Function Definitions"
        GetFeeTermDescriptionsList GetFeeTermDescriptionsList();

        #endregion "Get Function Definitions"

        
        #region "Insert update and delete Function Definitions"  
        string InsertFeeTermDescriptions(InsertFeeTermDescriptions obj);
        string UpdateFeeTermDescriptions(UpdateFeeTermDescriptions obj);
        DeleteFeeTermDescriptions DeleteFeeTermDescriptions(DeleteFeeTermDescriptions obj);
        #endregion "Insert update and delete Function Definitions"  

        #region "Report Function Definitions"

        #endregion "Report Function Definitions"
        


    }
}
