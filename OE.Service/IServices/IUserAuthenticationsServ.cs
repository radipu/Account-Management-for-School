using OE.Service.ServiceModels.UsersServ;
using System;
using OE.Data;
using System.Collections.Generic;
using OE.Service.ServiceModels;
namespace OE.Service
{
    public interface IUserAuthenticationsServ
    {
        #region "Get Function Definitions"
        bool IsAuthorized(long instituteId, long userId, long actorId);
        GetUserAuthenticationsByUserId2 GetUserAuthenticationsByUserId(Int64 userId);        
        GetLicenses GetLicenses();       
        #endregion "Get Function Definitions"

        #region "Insert Update Delete Function Definitions"        
        string InsertLicensesedUser(GetLicenses obj);
        string UpdateLicensedUser(GetLicenses obj);
        GetLicenses DeleteLicensedUser(GetLicenses obj);
        #endregion "Insert Update Delete Function Definitions"


    }
}