using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OE.Data
{
    public class ActorsMap
    {
        public ActorsMap(EntityTypeBuilder<Actors> entityBuilder)
        {
            entityBuilder.Property(t => t.Name);
            entityBuilder.Property(t => t.OrderNo);
        }
    }
}
