
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Data
{
    public class ExpensesMap
    {
        public ExpensesMap(EntityTypeBuilder<Expenses> entityBuilder)
        {
            entityBuilder.Property(t => t.Id);
            entityBuilder.Property(t => t.Name);
            entityBuilder.Property(t => t.Amount);
            entityBuilder.Property(t => t.Date);
            entityBuilder.Property(t => t.ExpenseTypeId);
        }
    }
}
