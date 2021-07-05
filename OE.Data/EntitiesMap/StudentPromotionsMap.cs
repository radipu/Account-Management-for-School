
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OE.Data
{
    public class StudentPromotionsMap
    {
        public StudentPromotionsMap(EntityTypeBuilder<StudentPromotions> entityBuilder)
        {
            entityBuilder.Property(t => t.Id);
            entityBuilder.Property(t => t.ClassId);
            entityBuilder.Property(t => t.ClassId);
            entityBuilder.Property(t => t.RollNo);           
            entityBuilder.Property(t => t.ClassYear);          
            entityBuilder.Property(t => t.IsActive);
            entityBuilder.Property(t => t.AddedBy);
            entityBuilder.Property(t => t.AddedDate);
            entityBuilder.Property(t => t.ModifiedBy);
            entityBuilder.Property(t => t.ModifiedDate);
            entityBuilder.Property(t => t.DataType);            
        }
    }
}