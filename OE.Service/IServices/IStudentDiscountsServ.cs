
using System;
using System.Collections.Generic;
using System.Text;
using OE.Service.ServiceModels.StudentDiscountsServ;

namespace OE.Service
{
    public interface IStudentDiscountsServ
    {
        #region "Get Function Definitions"
        getStudentDiscountsList getStudentDiscountsList();         
        dropdown_StudentDiscounts dropdown_StudentDiscounts(long feeTypeId);
        #endregion "Get Function Definitions"

        
        #region "Insert update and delete Function Definitions"  
        string InsertStudentDiscount(InsertStudentDiscount obj);
        string UpdateStudentDiscount(UpdateStudentDiscount obj);
        DeleteStudentDiscount DeleteStudentDiscount(DeleteStudentDiscount obj);
        #endregion "Insert update and delete Function Definitions" 

        #region "Report Function Definitions"
        PrintGetStudentDiscountsList PrintGetStudentDiscountsList();
        #endregion "Report Function Definitions"
       

    }
}
