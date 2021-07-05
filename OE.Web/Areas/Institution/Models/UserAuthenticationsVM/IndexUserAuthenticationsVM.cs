using OE.Data;
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
namespace OE.Web.Areas.Institution.Models.UserAuthenticationsVM
{
    public class IndexUserAuthenticationsVM
    {
        public List<IndexUserAuthenticationsVM_UserAuthentications> OELicensedUsersListVMs { get; set; }     
        public SelectList _Actors { get; set; }
        public SelectList _Users { get; set; }
        public List<IndexUserAuthenticationsVM_UserLicense> _UsersLicensesList { get; set; }
        public IndexUserAuthenticationsVM_UserAuthentication UserAuthentications { get; set; }
        
        public IndexUserAuthenticationsVM_Users Users { get; set; }
       
        public long Id { get; set; }
        public long UserAuthenticationId { get; set; }

        //[NOTE: Extra Fields]
        public long UserId { get; set; }
        public long ActorId { get; set; }        
        public string OurEduId { get; set; }       
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Int64 GenderId { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }        
        public bool IsActive { get; set; }
        public string Message { get; set; }        
    }

    public class IndexUserAuthenticationsVM_UserLicense
    {        
        public IndexUserAuthenticationsVM_Users Users { get; set; }
        public List<IndexUserAuthenticationsVM_UserAuthentication> _userAuthenticationList { get; set; }       
    }
   
    public class IndexUserAuthenticationsVM_Users : Users   
    {
        public long Id { get; set; }

        //[NOTE: Extra Fields]
        public long UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IP300X200 { get; set; }
        public string IP600X400 { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Int64 GenderId { get; set; }
        public bool? IsActive { get; set; }
    }

    public class IndexUserAuthenticationsVM_UserAuthentication : UserAuthentications   
    {
        public string ActorName { get; set; }
        public string UserIP300X200 { get; set; }
    }
   
    public class IndexUserAuthenticationsVM_UserAuthentications : UserAuthentications   
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

        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public bool? IsActive { get; set; }


    }

}
