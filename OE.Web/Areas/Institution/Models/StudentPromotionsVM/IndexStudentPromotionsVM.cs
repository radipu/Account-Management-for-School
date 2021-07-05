
using OE.Data;
using System;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.StudentPromotionsVM
{
    public class IndexStudentPromotionsVM
    {
        public IEnumerable<IndexStudentPromotionsVM_StudentPromotions> _StudentPromotions { get; set; }
        public IndexStudentPromotionsVM_StudentPromotions StudentPromotions { get; set; }
        

    }
    public class IndexStudentPromotionsVM_StudentPromotions: StudentPromotions
    {       
        public string Year { get; set; }      
        public string ClassName { get; set; }       
        public string RegistrationNo { get; set; }       
        public string PromotionYear { get; set; }       
    }
}
