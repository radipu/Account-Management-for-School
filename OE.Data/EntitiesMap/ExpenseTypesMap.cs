
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Data
{
    public class ExpenseTypesMap
    {
        public ExpenseTypesMap(EntityTypeBuilder<ExpenseTypes> entityBuilder)
        {
            entityBuilder.Property(t => t.Id);
            entityBuilder.Property(t => t.Name);
            entityBuilder.Property(t => t.IsActive);
        }
    }
}
