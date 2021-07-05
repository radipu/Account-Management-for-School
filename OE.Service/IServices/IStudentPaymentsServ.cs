
using OE.Service.ServiceModels.StudentPaymentsServ;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service
{
    public interface IStudentPaymentsServ
    {        
        #region "Get Function Definitions"
        getStudentPaymentsList getStudentPaymentsList();
        SearchStudentList SearchStudentList(SearchStudentList obj);
        SearchPaymentDetailById SearchPaymentDetailById(SearchPaymentDetailById obj);
        SearchPaymentDetailById SearchPaymentDetailById2(SearchPaymentDetailById obj);
        ClassByYear ClassByYear(long year, long studentId);
        #endregion "Get Function Definitions"    
        IEnumerable<dropdown_Year> dropdown_Year(long studentId);

        
        #region "Insert update and delete Function Definitions"  
        string InsertStudentPayment(InsertStudentPayment obj);
        string UpdateStudentPayment(UpdateStudentPayment obj);
        string DeleteStudentPayment(DeleteStudentPayment obj);
        #endregion "Insert update and delete Function Definitions"

        #region "Report Function Definitions"        
        PrintGetStudentPaymentsList PrintGetStudentPaymentsList();
        #endregion "Report Function Definitions"
        


    }
}
