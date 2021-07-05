
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace OE.Data
{
    public class SalariesMap
    {
        public SalariesMap(EntityTypeBuilder<Salaries> entityBuilder)
        {
            entityBuilder.Property(t => t.Id);           
            entityBuilder.Property(t => t.TermNo);
            entityBuilder.Property(t => t.SalaryTypeId);           
            entityBuilder.Property(t => t.StaffId);
            entityBuilder.Property(t => t.Date);
            entityBuilder.Property(t => t.Amount);
            entityBuilder.Property(t => t.Remark);
        }
    }
}
