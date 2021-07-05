
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OE.Data
{
    public class SalaryIncrementsMap
    {
        public SalaryIncrementsMap(EntityTypeBuilder<SalaryIncrements> entityBuilder)
        {
            entityBuilder.Property(t => t.Id);
            entityBuilder.Property(t => t.StaffId);
            entityBuilder.Property(t => t.DesigignationId);
            entityBuilder.Property(t => t.PayScalesId);
            entityBuilder.Property(t => t.Date);
            entityBuilder.Property(t => t.Amount);
        }
    }
}
