
using OE.Service.ServiceModels.StudentPromotionsServ;
using OE.Service.ServiceModels.StudentsServ;
using System;
using System.Collections.Generic;
using System.Text;
using getStudentsList = OE.Service.ServiceModels.StudentsServ.getStudentsList;

namespace OE.Service
{
    public interface IStudentsServ
    {
        #region "Get Function Definitions"       
        getStudentsList.getStudentsList getStudentList(getStudentsList.getStudentsList obj);      
        IEnumerable<dropdown_Students> dropdown_Students();
        StudentDetails StudentDetails(StudentDetails obj);
        GetStudentsByAccountant GetStudentsByAccountant();
        SearchStudentsByClass SearchStudentsByClass(SearchStudentsByClass obj);
        #endregion "Get Function Definitions"

        
        #region "Insert update and delete Function Definitions"  
        string InsertStudent(InsertStudent obj);
        string UpdateStudent(UpdateStudent obj);
        DeleteStudent DeleteStudent(DeleteStudent obj);
        #endregion "Insert update and delete Function Definitions"         

        #region "Report Function Definitions"
        PrintGetStudentsList PrintGetStudentsList();
        #endregion "Report Function Definitions"
        

    }
}

