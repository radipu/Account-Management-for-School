
using OE.Service.ServiceModels.StudentPromotionsServ;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service
{
    public interface IStudentPromotionsServ
    {
        #region "Get Function Definitions"
        getStudentPromotionsList  getStudentPromotionsList();
        //IEnumerable<dropdown_Class> dropdown_Class();
        #endregion "Get Function Definitions"

        
        #region "Post method"        
        string InsertStudentPromotions(InsertStudentPromotions obj);
        string UpdateStudentPromotion(UpdateStudentPromotion obj);
        DeleteStudentPromotion DeleteStudentPromotion(DeleteStudentPromotion obj);
        #endregion "post method"
        

    }
}
