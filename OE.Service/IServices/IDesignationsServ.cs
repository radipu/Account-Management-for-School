
using OE.Service.ServiceModels.DesignationsServ;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service
{
    public interface IDesignationsServ
    {
        #region "Get Function Definitions"
        getDesignationsList getDesignationsList();
        
        IEnumerable<dropdown_Designations> dropdown_Designations();
       
        #endregion "Get Function Definitions"
        
        #region "Insert Update Delete"
        string InsertDesignation(InsertDesignation obj);
        
        string UpdateDesignation(UpdateDesignation obj);
      
        DeleteDesignation DeleteDesignation(DeleteDesignation obj);
       
        #endregion "Insert Update Delete"

    }
}

