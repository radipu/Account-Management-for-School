
using OE.Data;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.StudentPaymentsServ
{
    public class SearchStudentList
    {
        public IEnumerable<SearchStudentList_Students> _Students { get; set; }
        public SearchStudentList_Students Students { get; set; }
        public string RegistrationId { get; set; }
    }
    public class SearchStudentList_Students : Students
    {
        public string ClassName { get; set; }
        public string GenderName { get; set; }
        public string StudentName { get; set; }
    }
}