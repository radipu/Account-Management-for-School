
using OE.Service.ServiceModels.ClassesServ;
using System;
using System.Collections.Generic;
using System.Text;
using getClassList = OE.Service.ServiceModels.ClassesServ.getClassList;
using InsertClass2 = OE.Service.ServiceModels.ClassesServ.InsertClass2;
using UpdateClass = OE.Service.ServiceModels.ClassesServ.UpdateClass;



namespace OE.Service
{
    public interface IClassesServ
    {
        #region "Get Function Definitions"
        getClassList.getClassList2 getClassList();
        IEnumerable<dropdown_Class2> dropdown_Class();
        #endregion "Get Function Definitions"

        #region "Insert update and delete Function Definitions"  
        string InsertClass(InsertClass2 obj);
        string UpdateClass(UpdateClass obj);
        DeleteClass2 DeleteClass(DeleteClass2 obj);
        #endregion "Insert update and delete Function Definitions"
    }
}


