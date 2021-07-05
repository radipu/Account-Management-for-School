
using OE.Data;
using System;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.StudentPaymentsVM
{
    public class IndexSearchStudentListVM
    {
        public IList<IndexSearchStudentListVM_Students> _Students { get; set; }
        public IndexSearchStudentListVM_Students Students { get; set; }
        public string RegistrationId { get; set; }

    }

    public class IndexSearchStudentListVM_Students : Students
    {
        public string ClassName { get; set; }
        public string GenderName { get; set; }
        public string StudentName { get; set; }
        public Int64 StudentId { get; set; }
        public decimal FeeAmount { get; set; }
        public decimal AmountToPay { get; set; }
    }
}