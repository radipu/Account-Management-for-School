using OE.Data;
using OE.Repo;
using OE.Service.ServiceModels.UsersServ;
using OE.Service.ServiceModels;
using System;
using System.Collections.Generic;
using System.Linq;
namespace OE.Service
{
    public class UserAuthenticationsServ : IUserAuthenticationsServ
    {
        #region "Variables"
        private IUserAuthenticationsRepo<UserAuthentications> _userAuthenticationsRepo;
        private IActorsRepo<Actors> _actorsRepo;
        private readonly IUsersRepo<Users> _usersRepo;
        //private readonly ICommonServ _commonServ;
        #endregion "Variables"

        #region "Constructor"
        public UserAuthenticationsServ
            (
            IUserAuthenticationsRepo<UserAuthentications> userAuthenticationsRepo,
            IActorsRepo<Actors> actorsRepo,
            IUsersRepo<Users> usersRepo
            //ICommonServ commonServ
            )
        {
            _userAuthenticationsRepo = userAuthenticationsRepo;
            _actorsRepo = actorsRepo;
            _usersRepo = usersRepo;
            //_commonServ = commonServ;
        }
        #endregion "Constructor"

        #region "Get Methods"       
        public bool IsAuthorized(long instituteId, long userId, long actorId)
        {
            var flagReturn = false;
            try
            {
                var userAuthtic = _userAuthenticationsRepo.GetAll().ToList();
                var checkIsAuthorized = (dynamic)null;
                checkIsAuthorized = (from ua in userAuthtic
                                     where ua.UserId == userId && ua.ActorId == actorId
                                     select ua.IsActive).SingleOrDefault();
                flagReturn = checkIsAuthorized;
            }
            catch (Exception)
            {
                flagReturn = false;
            }
            return flagReturn;
        }
        public GetUserAuthenticationsByUserId2 GetUserAuthenticationsByUserId(Int64 userId)
        {
            var userAuthenticationQuery = _userAuthenticationsRepo.GetAll().ToList();
            var ActorsQuery = _actorsRepo.GetAll().ToList();
            var query = (from ua in userAuthenticationQuery
                         join a in ActorsQuery on ua.ActorId equals a.Id
                         where ua.UserId == userId
                         && ua.IsActive == true
                         orderby a.OrderNo ascending
                         select new UserAuthentications { ActorId = ua.ActorId, UserId = ua.UserId }
                         );

            //[BR: if query is not null then update "LastEntryDate" Column will be updated]
            if (query != null)
            {
                var user = _usersRepo.GetAll().Where(u => u.Id == userId).SingleOrDefault();
                _usersRepo.Update(user);
            }
            var userAuthentication = new List<GetUserAuthenticationsByUserId_UsersAuthencation>();
            foreach (var item in query)
            {
                var userAuthen = new GetUserAuthenticationsByUserId_UsersAuthencation()
                {
                    Id = item.Id,
                    ActorId = item.ActorId,
                    UserId = item.UserId,
                };
                userAuthentication.Add(userAuthen);
            }
            var model = new GetUserAuthenticationsByUserId2()
            {
                _UsersAuthencations = userAuthentication
            };
            return model;
        }        
        public GetLicenses GetLicenses()
        {
            var model = new GetLicenses();
            try
            {
                var UsersList = _usersRepo.GetAll().ToList();
                var userAuthenticationList = _userAuthenticationsRepo.GetAll().ToList();
                var ActorList = _actorsRepo.GetAll().ToList();
                var query = (from _userAuthentication in userAuthenticationList
                             join _User in UsersList on _userAuthentication?.UserId equals _User?.Id
                             join _actor in ActorList on _userAuthentication?.ActorId equals _actor?.Id
                             select new { _userAuthentication, _User, _actor });

                var list = new List<GetLicenses_UserAuthentications>();
                foreach (var item in query)
                {
                    var temp = new GetLicenses_UserAuthentications()
                    {
                        Id = item._userAuthentication.Id,
                        ActorId = item._userAuthentication.ActorId,
                        Actor = item._actor.Name,
                        UserId = item._userAuthentication.UserId,
                        IsActive = item._userAuthentication.IsActive,
                        UserName = item._User.FirstName + " " + item._User.LastName,
                        OurEduId = item._User.OurEduId,
                        FirstName = item._User.FirstName,
                        LastName = item._User.LastName,
                        Password = item._User.Password,
                        Email = item._User.EmailAddress,
                        Contact = item._User.ContactNo,
                        GenderId = item._User.GenderId
                    };
                    list.Add(temp);
                };
                model = new GetLicenses()
                {
                    _UserAuthentications = list
                };
            }
            catch (Exception ex) 
            { 
                var test = ex.Message;
            }
            return model;
        }     
        #endregion "Get Methods"

        #region "Insert Update Delete Methods"
       
        public string InsertLicensesedUser(GetLicenses obj)
        {
            string retrurnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    if (obj.Users != null)
                    {
                        var Users = new GetLicenses_Users()
                        {
                            OurEduId = obj.Users.OurEduId,
                            Password = obj.Users.Password,
                            LastEntryDate = DateTime.Now,
                            LastLogoutDate = null,
                            GenderId = obj.Users.GenderId,                           
                            FirstName = obj.Users.FirstName,
                            LastName = obj.Users.LastName,
                            IP300X200 = null,
                            IP600X400 = null,
                            EmailAddress = obj.Users.EmailAddress,
                            ContactNo = obj.Users.ContactNo,                            
                            DateOfBirth = null,                          
                            IsForgetPassword = false,
                            IsActive = obj.Users.IsActive
                        };
                        _usersRepo.Insert(Users);
                        retrurnResult = "Saved";
                    }
                    var getLastId = _usersRepo.GetLastId();
                    var usersList = _usersRepo.Get(getLastId);
                    if (obj.UserAuthentications != null)
                    {
                        var UserAthentications = new GetLicenses_UserAuthentications()
                        {
                            ActorId = obj.UserAuthentications.ActorId,
                            UserId = getLastId,
                            IsActive = obj.Users.IsActive
                        };
                        _userAuthenticationsRepo.Insert(UserAthentications);
                        retrurnResult = "Saved";
                    }
                }
            }
            catch (Exception ex)
            {
                retrurnResult = "ERROR102: userServ/InsertuserList -" + ex.Message;
            }            
            return retrurnResult;
        }
        public string UpdateLicensedUser(GetLicenses obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                var getLicensedUserList = _userAuthenticationsRepo.GetAll().ToList();
                
                //var getUserId = (from p in getLicensedUserList
                //                 join s in userList on p?.UserId equals s?.Id
                //                 where  s.Id == p.UserId
                //                 select s).SingleOrDefault();
                if (obj != null)
                {

                    if (obj.Users != null)
                    {
                        var currentItem = _usersRepo.GetAll().Where(u => u.Id == obj.Users.Id).FirstOrDefault();
                        currentItem.Id = obj.Users.Id;
                        currentItem.OurEduId = obj.Users.OurEduId;
                        currentItem.Password = obj.Users.Password;
                        currentItem.LastEntryDate = DateTime.Now;
                        currentItem.LastLogoutDate = null;
                        currentItem.GenderId = obj.Users.GenderId;
                        currentItem.FirstName = obj.Users.FirstName;
                        currentItem.LastName = obj.Users.LastName;
                        currentItem.IP300X200 = null;
                        currentItem.IP600X400 = null;
                        currentItem.EmailAddress = obj.Users.EmailAddress;
                        currentItem.ContactNo = obj.Users.ContactNo;
                        currentItem.DateOfBirth = null;
                        currentItem.IsForgetPassword = false;
                        currentItem.IsActive = obj.Users.IsActive;
                        _usersRepo.Update(currentItem);
                        returnResult = "Saved";

                    }

                }
                //if (obj != null)
                //{

                //    if (obj.UserAuthentications != null)
                //    {
                //        var currentItem = _userAuthenticationsRepo.Get(obj.UserAuthentications.Id);
                //        currentItem.Id = obj.UserAuthentications.Id;
                //        currentItem.ActorId = obj.UserAuthentications.ActorId;
                //        currentItem.UserId = getUserId.Id;
                //        currentItem.IsActive = obj.UserAuthentications.IsActive;
                //        _userAuthenticationsRepo.Update(currentItem);
                //        returnResult = "Saved";

                //    }

                //}

            }
            catch (Exception ex)
            {
                returnResult = "ERROR102:FeeTypesServ/UpdateFeeTypes - " + ex.Message;
            }

            return returnResult;

        }
        public GetLicenses DeleteLicensedUser(GetLicenses obj)
        {
            var returnModel = new GetLicenses();
            var getLicensedUserList = _userAuthenticationsRepo.GetAll().ToList();
            var userList = _usersRepo.GetAll().ToList();
            var getUserId = (from p in getLicensedUserList
                             join s in userList on p?.UserId equals s?.Id
                             where p.Id == obj.LicensedId && s.Id == p.UserId
                             select s).SingleOrDefault();
            var Users = _usersRepo.Get(getUserId.Id);
            var UserAuthentications = _userAuthenticationsRepo.Get(obj.LicensedId);

            if (UserAuthentications != null)
            {
                _userAuthenticationsRepo.Delete(UserAuthentications);

                // returnModel.Message = "Delete Successful.";
            }
            if (Users != null)
            {
                _usersRepo.Delete(Users);

                // returnModel.Message = "Delete Successful.";
            }
            return returnModel;
        }

        #endregion "Insert Update Delete Methods"
    }
}
