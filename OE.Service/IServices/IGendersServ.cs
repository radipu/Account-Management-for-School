
using System;
using OE.Data;
using System.Collections.Generic;
using OE.Service.ServiceModels.GendersServ;

namespace OE.Service
{
    public interface IGendersServ
    {

        #region "Get Function Definitions"

        #endregion "Get Function Definitions"

        #region "Insert Update Delete Function Definitions"

        #endregion "Insert Update Delete Function Definitions"

        #region "Dropdown Function Definitions"
        IEnumerable<dropdown_Genders> Dropdown_Genders();
        #endregion "Dropdown Function Definitions"

    }
}

