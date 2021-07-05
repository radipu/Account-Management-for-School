
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OE.Data
{
    public class FeeStructuresMap
    {
        public FeeStructuresMap(EntityTypeBuilder<FeeStructures> entityBuilder)
        {
            entityBuilder.Property(t => t.Id);
            entityBuilder.Property(t => t.FeeTypeId);
            entityBuilder.Property(t => t.ClassId);
            entityBuilder.Property(t => t.Amount);           
            entityBuilder.Property(t => t.YearlyTermNo);           
            entityBuilder.Property(t => t.StartingYear);          
            entityBuilder.Property(t => t.EndingYear);            
            entityBuilder.Property(t => t.IsActive);
        }
    }
}
