using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OE.Data
{
    public class ClassesMap
    {
        public ClassesMap(EntityTypeBuilder<Classes> entityBuilder)
        {
            entityBuilder.Property(t => t.Name);          
        }
    }
}
