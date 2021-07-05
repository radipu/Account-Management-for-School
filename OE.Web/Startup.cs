using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OE.Repo;
using OE.Service;
using Rotativa.AspNetCore;
using System;
namespace OE.Web
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.        
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => false; //[OE_NOTE:Default is true, make it false]
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddMvc(options =>
            {
                options.Filters.Add(new ResponseCacheAttribute() { NoStore = true, Location = ResponseCacheLocation.None });
            });
            services.AddDistributedMemoryCache();
            services.AddAutoMapper(typeof(Startup));            

            //services.AddAutoMapper();

            //[NOTE: set session time for 1 year]
            services.AddSession(options => {
                options.Cookie.HttpOnly = true;
                options.Cookie.Name = ".ASPNetCoreSession";
                options.IdleTimeout = TimeSpan.FromMinutes(525600);
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
                options.Cookie.Path = "/";

            });

            //Add database connection
            services.AddDbContext<OurEduMediaContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            #region "A series"           

            //[NOTE:Actors]
            services.AddScoped(typeof(IActorsRepo<>), typeof(ActorsRepo<>));
            services.AddTransient<IActorsServ, ActorsServ>();
            #endregion "A series"

            #region "C series"           

            //[NOTE:Classes]
            services.AddScoped(typeof(IClassesRepo<>), typeof(ClassesRepo<>));
            services.AddTransient<IClassesServ, ClassesServ>();
                                  
            //[NOTE:Common]
            services.AddTransient<ICommonServ, CommonServ>();
            
            #endregion "C series

            #region "D series" 
            //[NOTE:Designations]
            services.AddScoped(typeof(IDesignationsRepo<>), typeof(DesignationsRepo<>));
            services.AddTransient<IDesignationsServ, DesignationsServ>();
            #endregion "D series"

            #region "E series"          

            services.AddScoped(typeof(IExpensesRepo<>), typeof(ExpensesRepo<>));
            services.AddTransient<IExpensesServ, ExpensesServ>();
            services.AddScoped(typeof(IExpenseTypesRepo<>), typeof(ExpenseTypesRepo<>));
            services.AddTransient<IExpenseTypesServ, ExpenseTypesServ>();
            
            #endregion "E series"

            #region "F series"
            
            //[NOTE:FeeTypes]
            services.AddScoped(typeof(IFeeTypesRepo<>), typeof(FeeTypesRepo<>));
            services.AddTransient<IFeeTypesServ, FeeTypesServ>();

            //[NOTE:FeeStructures]
            services.AddScoped(typeof(IFeeStructuresRepo<>), typeof(FeeStructuresRepo<>));
            services.AddTransient<IFeeStructuresServ, FeeStructuresServ>();

            //[NOTELFeeTermDescriptions]
            services.AddScoped(typeof(IFeeTermDescriptionsRepo<>), typeof(FeeTermDescriptionsRepo<>));
            services.AddTransient<IFeeTermDescriptionsServ, FeeTermDescriptionsServ>();
            
            #endregion "F series"

            #region "G series"
            //[NOTE:Genders]
            services.AddScoped(typeof(IGendersRepo<>), typeof(GendersRepo<>));
            services.AddTransient<IGendersServ, GendersServ>();
            #endregion "G series"

            #region "I series"
            //[NOTE:Genders]
            services.AddScoped(typeof(IInstitutionsRepo<>), typeof(InstitutionsRepo<>));
            #endregion "I series"

            #region "P series"
           
            //[NOTE:PaymentTypes]
            services.AddScoped(typeof(IPaymentTypesRepo<>), typeof(PaymentTypesRepo<>));
            services.AddTransient<IPaymentTypesServ, PaymentTypesServ>();
            

           

            //[NOTE:PayScales]
            services.AddScoped(typeof(IPayScalesRepo<>), typeof(PayScalesRepo<>));
            services.AddTransient<IPayScalesServ, PayScalesServ>();
                       


            #endregion "P series"

            #region "S series"
            //[NOTE:Staffs]
            services.AddScoped(typeof(IStaffsRepo<>), typeof(StaffsRepo<>));
            services.AddTransient<IStaffsServ, StaffsServ>();

            //[NOTE:Salarys]            
            services.AddScoped(typeof(ISalariesRepo<>), typeof(SalariesRepo<>));
            services.AddTransient<ISalariesServ, SalariesServ>();
            
            //[NOTE:SalaryIncrements]
            services.AddScoped(typeof(ISalaryIncrementsRepo<>), typeof(SalaryIncrementsRepo<>));
            services.AddTransient<ISalaryIncrementsServ, SalaryIncrementsServ>();
            
            //[NOTE:Students]
            services.AddScoped(typeof(IStudentsRepo<>), typeof(StudentsRepo<>));
            services.AddTransient<IStudentsServ, StudentsServ>();
                        
            //[NOTE:StudentDiscounts]
            services.AddScoped(typeof(IStudentDiscountsRepo<>), typeof(StudentDiscountsRepo<>));
            services.AddTransient<IStudentDiscountsServ, StudentDiscountsServ>();
            
            //[NOTE:StudentPayments]
            services.AddScoped(typeof(IStudentPaymentsRepo<>), typeof(StudentPaymentsRepo<>));
            services.AddTransient<IStudentPaymentsServ, StudentPaymentsServ>();
           
            //[NOTE:StudentPromotions]
            services.AddScoped(typeof(IStudentPromotionsRepo<>), typeof(StudentPromotionsRepo<>));
            services.AddTransient<IStudentPromotionsServ, StudentPromotionsServ>();
           
            #endregion "S series"

            #region "U series"
            //[NOTE:Users]
            services.AddScoped(typeof(IUsersRepo<>), typeof(UsersRepo<>));
            services.AddTransient<IUsersServ, UsersServ>();

            //[NOTE:UserAuthentications]
            services.AddScoped(typeof(IUserAuthenticationsRepo<>), typeof(UserAuthenticationsRepo<>));
            services.AddTransient<IUserAuthenticationsServ, UserAuthenticationsServ>();
            #endregion "U series"

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                   name: "areaRoute",
                   template: "{area:exists}/{controller=User}/{action=Login}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Login}/{id?}");
            });
            //[NOTE: for report]
            //RotativaConfiguration.Setup(IWebHostEnvironment he, "DataDictionary\\Rotativa");
            //RotativaConfiguration.Setup(env.WebRootPath, "DataDictionary\\Rotativa");

            //[Rahul - update 27Apr21]
            //RotativaConfiguration.Setup(env, "DataDictionary\\Rotativa");
            RotativaConfiguration.Setup((Microsoft.AspNetCore.Hosting.IHostingEnvironment)env);
            //[~Rahul - update 27Apr21]
        }
    }
}
