
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.StudentPromotionsServ
{
    public class InsertStudentPromotions
    {
        public IEnumerable<InsertStudentPromotions_StudentPromotions> _StudentPromotions { get; set; }
        public InsertStudentPromotions_StudentPromotions StudentPromotions { get; set; }

    }
    public class InsertStudentPromotions_StudentPromotions : StudentPromotions
    {        
        public string PromotionYear { get; set; }       
        public string Year { get; set; }       
    }
}