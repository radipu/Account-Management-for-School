using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using OE.Data;
using System;
namespace OE.Web.Areas.Institution.Models.UsersVM
{
    public class PrintIndexUserAuthenticationsVM
    {       
        public List<PrintIndexUserAuthenticationsVM_UserLicense> _UsersLicensesList { get; set; }
        public List<PrintIndexUserAuthenticationsVM_UserAuthentications> OEUserAuthenticationsListVM { get; set; }
        public PrintIndexUserAuthenticationsVM_UserAuthentication UserAuthentications { get; set; }        
        public SelectList _Users { get; set; }
        public string InstitutionName { get; set; }
        public string Logo { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; } 
    }
    
    public class PrintIndexUserAuthenticationsVM_UserLicense    
    {        
        public PrintIndexUserAuthenticationsVM_Users Users { get; set; }
        public List<PrintIndexUserAuthenticationsVM_UserAuthentication> _userAuthenticationList { get; set; }        
    }
    
    public class PrintIndexUserAuthenticationsVM_Users : Users   
    {
        //[NOTE: No property here]       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IP300X200 { get; set; }       
    }

    public class PrintIndexUserAuthenticationsVM_UserAuthentication : UserAuthentications   
    {
        public string ActorName { get; set; }
        public string UserIP300X200 { get; set; }
    }
    
    public class PrintIndexUserAuthenticationsVM_UserAuthentications : UserAuthentications    
    {
        //[NOTE: Extra Field]
        public string OurEduId { get; set; }
        public string ActorName { get; set; }
        public string UserIP300X200 { get; set; }

        //[NOTE: Extra Properties from 'Genders' entity]
        public Int64 GenderId { get; set; }

        //[NOTE: Extra Properties from 'Employees' entity]
        public string EmployeeName { get; set; }

        //[NOTE: Extra Properties from 'Users' entity]
        public string UserName { get; set; }

    }

}
