
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OE.Data
{
    public class InstitutionsMap
    {
        public InstitutionsMap(EntityTypeBuilder<Institutions> entityBuilder)
        {
            entityBuilder.HasKey(t => t.Id);
            entityBuilder.Property(t => t.Name);
            entityBuilder.Property(t => t.IsActive);
            entityBuilder.Property(t => t.LogoPath);
            entityBuilder.Property(t => t.FaviconPath);
            entityBuilder.Property(t => t.Email);
            entityBuilder.Property(t => t.ContactNo);
            entityBuilder.Property(t => t.Address);
        }
    }
}
