using OE.Data;
using System;
using System.Collections.Generic;
namespace OE.Web.Areas.Institution.Models.UsersVM
{
    public class IndexUsersListVM
    {        
        public List<IndexUsersListVM_Users> _oeusers { get; set; }
       
        //[NOTE: Extra fields]
        public string SearchString { get; set; }
        public string ImageRootPath { get; set; }
    }
   
    public class IndexUsersListVM_Users : Users   
    {
        public string GenderName { get; set; }       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IP300X200 { get; set; }
        public string EmailAddress { get; set; }
        public string ContactNo { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Int64 GenderId { get; set; }       
    }

}

