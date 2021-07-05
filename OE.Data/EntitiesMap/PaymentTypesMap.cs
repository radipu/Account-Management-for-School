
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OE.Data
{
    public class PaymentTypesMap
    {
        public PaymentTypesMap(EntityTypeBuilder<PaymentTypes> entityBuilder)
        {
            entityBuilder.Property(t => t.Id);
            entityBuilder.Property(t => t.Name);            
        }
    }
}
