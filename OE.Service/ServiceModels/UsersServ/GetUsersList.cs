using OE.Data;
using System.Collections.Generic;
namespace OE.Service.ServiceModels.UsersServ.GetUsersList
{    
    public class GetUsersList 
    {
        public List<M_Users> _Users { get; set; }
        
        //[NOTE: Extra Fields]        
        public string searchString { get; set; }
        public string imageRootPath { get; set; }


    }

    public class M_Users : Users
    {
        public string GenderName { get; set; }      
        public string FullName { get; set; }
        public string ActorName { get; set; }
        public string UserId { get; set; }     
    }


}
