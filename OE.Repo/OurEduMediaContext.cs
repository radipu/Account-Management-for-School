using OE.Data;
using Microsoft.EntityFrameworkCore;

namespace OE.Repo
{
    public class OurEduMediaContext : DbContext
    {
        public OurEduMediaContext(DbContextOptions<OurEduMediaContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //[NOTE: A series] 
            new ActorsMap(modelBuilder.Entity<Actors>());

            //[NOTE: C series] 
            new ClassesMap(modelBuilder.Entity<Classes>());

            //[NOTE: D series] 
            new DesignationsMap(modelBuilder.Entity<Designations>());

           
            //[NOTE: E series]    
            new ExpensesMap(modelBuilder.Entity<Expenses>());
            new ExpenseTypesMap(modelBuilder.Entity<ExpenseTypes>());
           
            //[NOTE: F series]
            new FeeTypesMap(modelBuilder.Entity<FeeTypes>());
            new FeeStructuresMap(modelBuilder.Entity<FeeStructures>());
            new FeeTermDescriptionsMap(modelBuilder.Entity<FeeTermDescriptions>());
            

            //[NOTE: G series]  
            new GendersMap(modelBuilder.Entity<Genders>());

            //[NOTE: I series] 
            new InstitutionsMap(modelBuilder.Entity<Institutions>());


            //[NOTE: P series] 

           
            new PaymentTypesMap(modelBuilder.Entity<PaymentTypes>());
            
            new PayScalesMap(modelBuilder.Entity<PayScales>());
            

            //[NOTE: S series]
            new StaffsMap(modelBuilder.Entity<Staffs>());
            
            new SalariesMap(modelBuilder.Entity<Salaries>());
          
           
            new StudentDiscountsMap(modelBuilder.Entity<StudentDiscounts>());
          

           
            new StudentsMap(modelBuilder.Entity<Students>());
            new StudentPromotionsMap(modelBuilder.Entity<StudentPromotions>());
           
            new StudentPaymentsMap(modelBuilder.Entity<StudentPayments>());
           
            new StudentDiscountsMap(modelBuilder.Entity<StudentDiscounts>());
          

            //[NOTE: U series]            
            new UsersMap(modelBuilder.Entity<Users>());
            new UserAuthenticationsMap(modelBuilder.Entity<UserAuthentications>());
        }
    }
}
