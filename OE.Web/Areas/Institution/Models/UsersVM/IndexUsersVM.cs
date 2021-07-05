using Microsoft.AspNetCore.Mvc.Rendering;
using OE.Data;
using System;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.UsersVM
{
    public class IndexUsersVM
    {       
        public List<IndexUsersVM_Users> OEUsersListVMs { get; set; }
        public IndexUsersVM_Users users { get; set; }        
        public SelectList _ddlUserlist { get; set; }
    }
    
    public class IndexUsersVM_Users : Users   
    {
        //[NOTE: Extra Field]       
        public string GenderName { get; set; }      
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IP300X200 { get; set; }
        public string IP600X400 { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Int64 GenderId { get; set; }       
    }

}
