
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OE.Data
{
    public class GendersMap 
    {
        public GendersMap(EntityTypeBuilder<Genders> entityBuilder)
        {
            entityBuilder.Property(t => t.Id);
            entityBuilder.Property(t => t.Name);
            entityBuilder.Property(t => t.IsActive);
            entityBuilder.Property(t => t.AddedBy);
            entityBuilder.Property(t => t.AddedDate);
            entityBuilder.Property(t => t.ModifiedBy);
            entityBuilder.Property(t => t.ModifiedDate);
            entityBuilder.Property(t => t.DataType);
        }
    }
}
