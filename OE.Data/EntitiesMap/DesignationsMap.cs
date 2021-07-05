using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Data
{
    public class DesignationsMap
    {
        public DesignationsMap(EntityTypeBuilder<Designations> entityBuilder)
        {
            entityBuilder.Property(t => t.Name);
        }
    }
}
