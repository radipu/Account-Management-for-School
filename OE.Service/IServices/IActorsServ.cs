using System;
using OE.Data;
using OE.Service.ServiceModels;
using System.Collections.Generic;

namespace OE.Service
{
    public interface IActorsServ
    {

        #region "DropDown Function Definitions"        
        IEnumerable<dropdown_Actors> Dropdown_Actors(Int64 id);
        IEnumerable<dropdown_Actors> Dropdown_Actors();
        #endregion "DropDown Function Definitions"

    }
}
