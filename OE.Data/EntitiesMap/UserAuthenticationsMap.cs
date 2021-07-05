using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OE.Data
{
    public class UserAuthenticationsMap
    {
        public UserAuthenticationsMap(EntityTypeBuilder<UserAuthentications> entityBuilder)
        {
            entityBuilder.Property(t => t.ActorId);
            entityBuilder.Property(t => t.UserId);
        }
    }
}
