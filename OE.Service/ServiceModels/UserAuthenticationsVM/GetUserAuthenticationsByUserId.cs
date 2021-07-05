using OE.Data;
using System.Collections.Generic;
namespace OE.Service.ServiceModels.UsersServ
{
    public class GetUserAuthenticationsByUserId2
    {
        public long userid { get; set; }
        public List<GetUserAuthenticationsByUserId_UsersAuthencation> _UsersAuthencations { get; set; }
    }

    public class GetUserAuthenticationsByUserId_UsersAuthencation : UserAuthentications
    {
        //[NOTE: Fields from 'Actors' entity]
        public string ActorsName { get; set; }    //[NOTE: original name is 'Name']   
    }

}

