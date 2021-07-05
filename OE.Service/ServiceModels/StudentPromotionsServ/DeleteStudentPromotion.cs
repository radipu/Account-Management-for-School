
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.StudentPromotionsServ
{
    public class DeleteStudentPromotion
    {
        public IEnumerable<DeleteStudentPromotion_StudentPromotion> _StudentPromotions { get; set; }
        public DeleteStudentPromotion_StudentPromotion StudentPromotions { get; set; }
        public long StudentPromotionsId { get; set; }
    }
    public class DeleteStudentPromotion_StudentPromotion: StudentPromotions
    {

    }
}