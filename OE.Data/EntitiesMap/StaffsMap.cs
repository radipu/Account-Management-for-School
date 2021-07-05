
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Data
{
    public class StaffsMap
    {
        public StaffsMap(EntityTypeBuilder<Staffs> entityBuilder)
        {
            entityBuilder.Property(t => t.Id);
            entityBuilder.Property(t => t.DesignationId);
            entityBuilder.Property(t => t.FirstName);
            entityBuilder.Property(t => t.LastName);            
            entityBuilder.Property(t => t.IP300X200);
            entityBuilder.Property(t => t.GenderId);            
            entityBuilder.Property(t => t.Cell);
            entityBuilder.Property(t => t.Email);
            entityBuilder.Property(t => t.Address);
            entityBuilder.Property(t => t.Education);
        }
    }
}

