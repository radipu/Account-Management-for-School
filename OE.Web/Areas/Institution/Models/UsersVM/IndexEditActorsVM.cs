using OE.Data;
using System.Collections.Generic;
namespace OE.Web.Areas.Institution.Models.UsersVM
{
    public class IndexEditActorsVM
    {        
        public List<IndexEditActorsVM_EditUsersAuthentication> _userAuthentication { get; set; }
        public IndexEditActorsVM_EditUsersAuthentication userAuthentication { get; set; }        
        public long Id { get; set; }
        //[NOTE: Extra Fields]
        public long UserId { get; set; }
        public string Message { get; set; }

    }
   
    public class IndexEditActorsVM_EditUsersAuthentication : UserAuthentications  
    {
        //[NOTE: Fields from 'Actors' entity]
        public string ActorsName { get; set; }

    }

}

