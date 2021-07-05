
using OE.Data;
using System;
using System.Collections.Generic;

namespace OE.Service.ServiceModels.StudentPaymentsServ
{
    public class SearchPaymentDetailById
    {
        
        public Int64 StudentId { get; set; }       
        public Int64 ClassId { get; set; }       
        public string RegistrationId { get; set; }        
        public IEnumerable<SearchPaymentDetailById_StudentPayments> _StudentPayments { get; set; }       
        public string StudentSearchName { get; set; }        
        public decimal? TotalPaid { get; set; }
        public decimal? TotalFine { get; set; }
        public decimal? TotalHavetoPay { get; set; }        
    }
    
    public class SearchPaymentDetailById_StudentPayments : StudentPayments
    {
        public string StudentName { get; set; }
        public string FeeType { get; set; }
        public decimal Amount { get; set; }
        public string ClassName { get; set; }
        public string TermName { get; set; }
        public long TermNo { get; set; }
        public decimal? FeeAmount { get; set; }
        public decimal? Discount { get; set; }
        public decimal AmountToPay { get; set; }
    } 
}