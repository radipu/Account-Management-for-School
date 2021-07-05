
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OE.Data
{
    public class FeeTypesMap
    {
        public FeeTypesMap(EntityTypeBuilder<FeeTypes> entityBuilder)
        {
            entityBuilder.Property(t => t.Id);
            entityBuilder.Property(t => t.ClassId);
            entityBuilder.Property(t => t.Name);           
            entityBuilder.Property(t => t.IsActive);            
        }
    }
}
