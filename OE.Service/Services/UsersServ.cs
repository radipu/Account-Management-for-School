//using Microsoft.AspNetCore.Http;
using OE.Data;
using OE.Repo;
using OE.Service.ServiceModels;
using OE.Service.ServiceModels.UsersServ.GetUsersList;
using System;
using System.Collections.Generic;
using System.Linq;
namespace OE.Service
{
    public class UsersServ :  IUsersServ
    {
        #region "Variables"   
      //private readonly IGendersRepo<Genders> _gendersRepo;       
        private readonly IUsersRepo<Users> _oeUsersRepo;
        private readonly IActorsRepo<Actors> _oeActorsRepo;
        private readonly IUserAuthenticationsRepo<UserAuthentications> _oeUserAuthenticationsRepo;
       
        
        #endregion "Variables"

        #region "Constructor"

        public UsersServ(
             //GendersRepo<Genders> gendersRepo,
            IActorsRepo<Actors> oeActorsRepo,
            IUserAuthenticationsRepo<UserAuthentications> oeUserAuthenticationsRepo,
            IUsersRepo<Users> oeUsersRepo
            
            )
        {
           // _gendersRepo = gendersRepo;
            _oeUserAuthenticationsRepo = oeUserAuthenticationsRepo;
            _oeUsersRepo = oeUsersRepo;
            _oeActorsRepo = oeActorsRepo;
            
        }

        #endregion "Constructor"

        #region "GET Methods"     
        
        public Users GetUserLogin(string OurEduId, string password)
        {
            Users model = new Users();
            try {
                var queryAll = _oeUsersRepo.GetAll().ToList();

                var query = (from u in queryAll
                             where u.OurEduId == OurEduId
                             && u.Password == password
                             && u.IsActive == true
                             select u).SingleOrDefault();
               
                model = query;

            }
            catch(Exception ex) {
                var test = ex.Message;
            }
            return model;
        }
        public Users GetUserByEmail(string email)
        {
            var queryAll = _oeUsersRepo.GetAll();
            var query = from e in queryAll
                        where e.EmailAddress == email
                        select e;
            return query.FirstOrDefault();
        }
        public UsersWithGenders GetUserByID(Int64 id, string webRootPath)
        {
            var queryAll = _oeUsersRepo.GetAll();
           // var queryGender = _gendersRepo.GetAll();

            var returnQuery = (dynamic)null;

            //var jointQuery = from e in queryAll
            //                 where e.Id == id
            //                 join g in queryGender on e.GenderId equals g.Id
            //                 select new { e, g };

            var jointQuery = from e in queryAll
                             where e.Id == id
                             
                             select new { e};
            foreach (var item in jointQuery)
            {
                string path = string.IsNullOrEmpty(item.e.IP300X200) ? "" : item.e.IP300X200;
               // item.e.IP300X200 = _commonServ.CommImage_WrapperDefaultImage(path, webRootPath, item.g.Id);
                returnQuery = new UsersWithGenders()
                {
                    //Genders = item.g,
                    Users = item.e
                };
            }

            return returnQuery;

        }
        public UserAuthentications GetOE_UserAuthenticationsById(long Id)
        {
            var queryAll = _oeUserAuthenticationsRepo.GetAll();

            var query = (from u in queryAll
                         where u.Id == Id
                         select u).FirstOrDefault();
            return query;
        }
       
        public GetUsersList GetUsersList()
        {
            var model = new GetUsersList();
            try
            {
                var UsersList = _oeUsersRepo.GetAll();
               
                
                
                var list = new List<M_Users>();
                foreach (var item in UsersList)
                {
                    var temp = new M_Users()
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName=item.LastName,
                        FullName=item.FirstName + " "+item.LastName,
                        IP300X200=item.IP300X200,
                        IP600X400=item.IP600X400,
                        EmailAddress=item.EmailAddress,
                        ContactNo=item.ContactNo,
                        DateOfBirth=item.DateOfBirth,
                        GenderId=item.GenderId,                       
                        OurEduId=item.OurEduId,
                        Password=item.Password,
                        IsForgetPassword=item.IsForgetPassword,
                        IsActive=item.IsActive,
                        LastEntryDate=item.LastEntryDate,
                        LastLogoutDate=item.LastLogoutDate


                    };
                    list.Add(temp);
                };


                model = new GetUsersList()
                {
                    _Users = list
                };

            }
            catch (Exception)
            {

            }
            return model;
        }
        
        #endregion "GET Methods"

        #region "Insert, Delete and Update Methods"


        #endregion "Insert, Delete and Update Methods"        

        #region "Dropdown Methods"
        public IEnumerable<dropdown_Users> Dropdown_Users()
        {

            var getUser = _oeUsersRepo.GetAll().ToList();
            var queryResult = new List<dropdown_Users>();

            foreach (var item in getUser)
            {
                var u = new dropdown_Users()
                {
                    Id = item.Id,
                    Name = item.OurEduId
                };
                queryResult.Add(u);
            }

            return queryResult;

        }
        #endregion "Dropdown Methods"

        #region "private Methods"
        public bool IsSameActorInPerson( long userId, long actorId)
        {
            bool flagReturn = false;
            var userAuthtic = _oeUserAuthenticationsRepo.GetAll();
            var checkIsActorIsSame = (dynamic)null;
            if ( userId != 0 && actorId != 0)
            {
                checkIsActorIsSame = (from ua in userAuthtic
                                      where ua.UserId == userId && ua.ActorId == actorId
                                      select ua).SingleOrDefault();
            }

            if (checkIsActorIsSame != null)
            {
                flagReturn = true;
            }
            return flagReturn;
        }
        #endregion "private Methods"
    }
}
