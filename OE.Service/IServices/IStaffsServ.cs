
using OE.Service.ServiceModels.StaffsServ;
using System.Collections.Generic;

namespace OE.Service
{
    public interface IStaffsServ
    {
        #region "Get Function Definitions"
        getStaffsList getStaffsList(getStaffsList obj);       
        IEnumerable<dropdown_Staffs> dropdown_Staffs();

       
        StaffDetails StaffDetails(StaffDetails obj);
        
        #endregion "Get Function Definitions"

       
        #region "Insert update and delete Function Definitions"  
        string InsertStaff(InsertStaff obj);
        string UpdateStaff(UpdateStaff obj);
        DeleteStaff DeleteStaff(DeleteStaff obj);

        #endregion "Insert update and delete Function Definitions" 

        #region "Report Function Definitions"
        PrintGetStaffsList PrintGetStaffsList();
        #endregion "Report Function Definitions"
        
    }
}
