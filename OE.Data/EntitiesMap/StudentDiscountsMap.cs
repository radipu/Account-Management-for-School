
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OE.Data
{
    public class StudentDiscountsMap
    {
        public StudentDiscountsMap(EntityTypeBuilder<StudentDiscounts> entityBuilder)
        {
            entityBuilder.Property(t => t.Id);
            entityBuilder.Property(t => t.StudentId);
            entityBuilder.Property(t => t.FeeTypeId);
            entityBuilder.Property(t => t.DiscountAmout);
        }
    }
}