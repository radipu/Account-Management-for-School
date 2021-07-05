
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OE.Data
{
    public class StudentsMap
    {
        public StudentsMap(EntityTypeBuilder<Students> entityBuilder)
        {
            entityBuilder.Property(t => t.Id);
            entityBuilder.Property(t => t.ClassId);
            entityBuilder.Property(t => t.GenderId);           
            entityBuilder.Property(t => t.RegistrationNo);            
            entityBuilder.Property(t => t.FirstName);
            entityBuilder.Property(t => t.LastName);
            entityBuilder.Property(t => t.IP300X200);
            entityBuilder.Property(t => t.AdmittedYear);
            entityBuilder.Property(t => t.PresentAddress);
            entityBuilder.Property(t => t.PermanentAddress);
            entityBuilder.Property(t => t.DOB);
            entityBuilder.Property(t => t.IsActive);
            entityBuilder.Property(t => t.AddedBy);
            entityBuilder.Property(t => t.AddedDate);
            entityBuilder.Property(t => t.ModifiedBy);
            entityBuilder.Property(t => t.ModifiedDate);
            entityBuilder.Property(t => t.DataType);
            entityBuilder.Property(t => t.FatherName);
            entityBuilder.Property(t => t.MotherName);
        }
    }
}