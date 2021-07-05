
using System;
using System.Collections.Generic;
using System.Text;
using OE.Data;

namespace OE.Service.ServiceModels
{
    public class GetLicenses
    {        
        public Actors Actors { get; set; }       
        public List<GetLicenses_UserAuthentications> _UserAuthentications { get; set; }
        public List<GetLicenses_Users> _Users { get; set; }
        public GetLicenses_Users Users { get; set; }
        public GetLicenses_UserAuthentications UserAuthentications { get; set; }
        public long LicensedId { get; set; }
       
    }
  
    public class GetLicenses_UserAuthentications: UserAuthentications
    {
        public string UserName { get; set; }
        public string Actor { get; set; }
        public string OurEduId { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Int64 GenderId { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
    }
    public class GetLicenses_Users: Users
    {
        public long UserAuthenticationId { get; set; }
        
    }
    
}

