
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OE.Data
{
    public class PayScalesMap
    {
        public PayScalesMap(EntityTypeBuilder<PayScales> entityBuilder)
        {
            entityBuilder.Property(t => t.Id);           
            entityBuilder.Property(t => t.StaffId);
            entityBuilder.Property(t => t.BasicSalary);           
            entityBuilder.Property(t => t.SalaryYear);           
            entityBuilder.Property(t => t.BasicSalaryTermNo);
            entityBuilder.Property(t => t.BonusSalary);
            entityBuilder.Property(t => t.BonusSalaryTermNo);           
        }
    }
}
