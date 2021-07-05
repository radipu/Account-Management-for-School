
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OE.Data
{
    public class StudentPaymentsMap : BaseEntity
    {
        public StudentPaymentsMap(EntityTypeBuilder<StudentPayments> entityBuilder)
        {
            entityBuilder.Property(t => t.Id);
            entityBuilder.Property(t => t.ClassId);
            entityBuilder.Property(t => t.FeeYearDate);
            entityBuilder.Property(t => t.StudentId);
            entityBuilder.Property(t => t.FeeTypeId);
            entityBuilder.Property(t => t.FeeTermDescriptionId);
            entityBuilder.Property(t => t.PaymentDate);
            entityBuilder.Property(t => t.Fine);
            entityBuilder.Property(t => t.PaidAmount);
            entityBuilder.Property(t => t.Remarks);
        }
    }
}