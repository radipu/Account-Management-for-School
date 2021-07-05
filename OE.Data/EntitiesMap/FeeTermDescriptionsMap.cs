
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OE.Data
{
    public class FeeTermDescriptionsMap
    {
        public FeeTermDescriptionsMap(EntityTypeBuilder<FeeTermDescriptions> entityBuilder)
        {
            entityBuilder.Property(t => t.Id);
            entityBuilder.Property(t => t.FeeStructureId);
            entityBuilder.Property(t => t.TermNo);
            entityBuilder.Property(t => t.TermName);
        }
    }
}
