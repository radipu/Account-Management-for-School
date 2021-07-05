
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.StudentPromotionsServ
{
    public class UpdateStudentPromotion
    {
        public IEnumerable<UpdateStudentPromotion_StudentPromotions> _StudentPromotions { get; set; }
        public UpdateStudentPromotion_StudentPromotions StudentPromotions { get; set; }
    }
    public class UpdateStudentPromotion_StudentPromotions : StudentPromotions
    {       
        public string Year { get; set; }       
    }
}
