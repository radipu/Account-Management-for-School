
using OE.Data;
using System;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.StudentPaymentsVM
{
    public class IndexPaymentDetailByIdVM    
    {        
        public IList<IndexPaymentDetailByIdVM_StudentPayments> _StudentPayments { get; set; }        
        public IList<IndexPaymentDetailByIdVM_FeeStructure> _FeeStructure { get; set; }        
        public IndexPaymentDetailByIdVM_StudentPayments StudentPayments { get; set; }        
        public Int64 ClassId { get; set; }    
        public string ClassName { get; set; }
        public long FeeYear { get; set; }   
        public Int64 StudentId { get; set; }      
        public string RegistrationId { get; set; }        
        public string StudentSearchName { get; set; }       
        public decimal? TotalPaid { get; set; }
        public decimal? TotalHavetoPay { get; set; }
        public decimal? TotalFine { get; set; }
        public IList<IndexPaymentDetailByIdVM_PaidList> _PaidList { get; set; }
    }    
    public class IndexPaymentDetailByIdVM_FeeStructure : FeeStructures   
    {
        public string FeeType { get; set; }
        public decimal DiscountAmount { get; set; }      
        public decimal? PaidAmount { get; set; }   
        public string TermName { get; set; }
        public long TermNo { get; set; }    
        public long FeeTermDescriptionId { get; set; }      
        public DateTime? PaymentDate { get; set; }     
        public decimal? Fine { get; set; }
        public string Remarks { get; set; }
        public DateTime? FeeYearDate { get; set; }
        public Int64? StudentId { get; set; }       
    }    
    public class IndexPaymentDetailByIdVM_StudentPayments : StudentPayments    
    {
        public string StudentName { get; set; }
        public string FeeType { get; set; }       
        public decimal? Amount { get; set; }
        public decimal? Discount { get; set; }
        public decimal TotalPaid { get; set; }      
        public string TermName { get; set; }
        public long TermNo { get; set; }     
        public decimal TotalHavetoPay { get; set; }      
        public decimal FeeAmount { get; set; }
        public decimal AmountToPay { get; set; }       
        public string ClassName { get; set; }       
        public string FeeYear { get; set; }        
    }
    public class IndexPaymentDetailByIdVM_PaidList
    {
        public long Id { get; set; }
        public long StuClassId { get; set; }
        public DateTime? StuFeeYear { get; set; }
        public long StuFeeTypeId { get; set; }
        public string StuClassName { get; set; }
        public string FeeTypeName { get; set; }
        public decimal? FeeAmount { get; set; }
        public DateTime? StuPaymentDate { get; set; }
        public decimal? StuPaidAmount { get; set; }
        public decimal? StuFine { get; set; }
        public string StuRemarks { get; set; }
        public decimal? StuDiscount { get; set; }

    }
}