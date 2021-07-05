using OE.Data;
using System.Collections.Generic;
namespace OE.Web.Areas.Institution.Models.UsersVM
{
    public class PrintIndexUsersListVM
    {
        public List<PrintIndexUsersListVM_Users> _oeusers { get; set; }
       
        //[NOTE: Extra fields]
        public string SearchString { get; set; }
        public string InstitutionName { get; set; }
        public string Logo { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public string ImageRootPath { get; set; }
    }
    
    public class PrintIndexUsersListVM_Users : Users    
    {
        public string GenderName { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string IP300X200 { get; set; }        
    }

}
