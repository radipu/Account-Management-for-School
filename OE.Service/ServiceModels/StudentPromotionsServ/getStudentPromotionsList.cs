
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.StudentPromotionsServ
{
    public class getStudentPromotionsList
    {
        public IEnumerable<getStudentPromotionsList_StudentPromotions> _StudentPromotions { get; set; }
        
    }
    public class getStudentPromotionsList_StudentPromotions: StudentPromotions
    {
        public string ClassName { get; set; }       
        public string RegistrationNo { get; set; }
       
    }
}
