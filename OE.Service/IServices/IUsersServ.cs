using OE.Data;
using OE.Service.ServiceModels;
using OE.Service.ServiceModels.UsersServ.GetUsersList;
using System;
using System.Collections.Generic;
namespace OE.Service
{
    public interface IUsersServ
    {
        #region "Get Function Definitions"
        Users GetUserLogin(string UserId, string Password);
        Users GetUserByEmail(string email);
        UsersWithGenders GetUserByID(Int64 id, string webRootPath);
        UserAuthentications GetOE_UserAuthenticationsById(long Id);
        GetUsersList GetUsersList();
        #endregion "Get Function Definitions"

        #region "Insert, delete and update Function Definitions"

        #endregion"Insert, delete and update Function Definitions"

        #region "DropDown Function Definitions"
        IEnumerable<dropdown_Users> Dropdown_Users();
        #endregion "DropDown Function Definitions"        

    }
}
