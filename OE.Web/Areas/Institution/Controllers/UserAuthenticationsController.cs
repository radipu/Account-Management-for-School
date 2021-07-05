using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using OE.Service;
using OE.Web.Areas.Institution.Models.UserAuthenticationsVM;
using OE.Service.ServiceModels;
using Microsoft.AspNetCore.Hosting;
using OE.Web.Areas.Institution.Models;

namespace OE.Web.Areas.Institution.Controllers
{
    [Area("Institution")]
    public class UserAuthenticationsController : Controller
    {        
        #region "Variables"
        private readonly IUsersServ _userServ;
        private readonly IUserAuthenticationsServ _userAuthentication;
        private readonly IActorsServ _actorServ;
       
        private readonly IWebHostEnvironment he;
        private readonly IGendersServ _GenderServ;
       
        #endregion "Variables"

        #region "Constructor"
        public UserAuthenticationsController(
            IUsersServ userServ,
            IUserAuthenticationsServ userAuthentication,
            IActorsServ actorServ,
           
            IGendersServ GenderServ,
            IWebHostEnvironment he
            
            )
        {
            _userServ = userServ;
            _userAuthentication = userAuthentication;
            _actorServ = actorServ;
           
            _GenderServ = GenderServ;
            this.he = he;
           
        }
        #endregion "Constructor"

        #region "Get Method"        
        public async Task<IActionResult> LicensedUserList(int pg = 1)       
        {
            try
            {
                var LicensedUserList = Task.Run(() => _userAuthentication.GetLicenses());
                var result = await LicensedUserList;
                ViewBag.ddlActors = _actorServ.Dropdown_Actors();
               
                ViewBag.ddlGender = _GenderServ.Dropdown_Genders();
               
                var list = new List<IndexUserAuthenticationsVM_UserAuthentications>();
                foreach(var item in result._UserAuthentications.ToList())
                {
                    var temp = new IndexUserAuthenticationsVM_UserAuthentications()
                    {
                        Id = item.Id,
                        ActorId = item.ActorId,
                        UserId = item.UserId,
                        IsActive = item.IsActive,
                        UserName = item.UserName,
                        ActorName = item.Actor,
                        OurEduId = item.OurEduId,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Password = item.Password,
                        Email = item.Email,
                        Contact = item.Contact,
                        GenderId = item.GenderId
                    };
                    list.Add(temp);
                };
                #region "Paging"
                const int pageSize = 5;
                if (pg < 1)
                    pg = 1;
                int recsCount = list.Count();
                var pager = new Pager(recsCount, pg, pageSize);
                int recSkip = (pg - 1) * pageSize;
                var data = list.Skip(recSkip).Take(pager.PageSize).ToList();
                this.ViewBag.Pager = pager;
                var model = new IndexUserAuthenticationsVM()
                {
                    OELicensedUsersListVMs = data
                };
                #endregion "Paging"
                
                return View("LicensedUserList", model);
        }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion "Get Method"        

        #region "Post Method"
        [HttpPost]
        //[Rahul - update 20Apr21]
        //public async Task<IActionResult> InsertLicensedUser(IndexUserAuthenticationsVM obj)
        public JsonResult InsertLicensedUser(IndexUserAuthenticationsVM obj)
        {
            var result = (dynamic)null;
            string message = (dynamic)null;
            try
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
                        IsActive = obj.Users.IsActive,
                    };

                    var UserAuthentications = new GetLicenses_UserAuthentications()
                    {
                        ActorId = obj.UserAuthentications.ActorId,
                        UserId = obj.Users.Id,
                        IsActive = obj.Users.IsActive,
                    };

                    var model = new GetLicenses()
                    {                       
                        Users = Users,
                        UserAuthentications = UserAuthentications
                    };
                    //await Task.Run(() => _userAuthentication.InsertLicensesedUser(model));
                    message = _userAuthentication.InsertLicensesedUser(model);
                    result = Json(new { success = true, Message = message });
                }
              
            }
            catch (Exception ex)
            {
                //return BadRequest();
                result = Json(new { success = false, Message = "ERROR101:Students/InsertStudent - " + ex.Message });
            }
            //return RedirectToAction("LicensedUserList");
            return result;
        }
        //[~Rahul - update 20Apr21]
        [HttpPost]
        public async Task<IActionResult> UpdateLicensedUser(IndexUserAuthenticationsVM obj)
        {

            try
            {
                if (obj.Users != null)
                {
                     
                    var Users = new GetLicenses_Users()
                    {
                        Id = obj.Users.UserId,
                        UserAuthenticationId = obj.UserAuthenticationId,
                        OurEduId = obj.Users.OurEduId,
                        Password = obj.Users.Password,
                        LastEntryDate = DateTime.Now,
                        LastLogoutDate = null,
                        GenderId = obj.Users.GenderId,
                        FirstName = obj.Users.FirstName,
                        LastName = obj.Users.LastName,
                        IP300X200 = null,
                        IP600X400 = null,
                        EmailAddress = obj.Users.EmailAddress !=null? obj.Users.EmailAddress:"",
                        ContactNo = obj.Users.ContactNo != null ? obj.Users.ContactNo : "",
                        DateOfBirth = null,
                        IsForgetPassword = false,
                        IsActive = obj.Users.IsActive,


                    };
                    //var UserAuthentications = new GetLicenses_UserAuthentications()
                    //{
                    //    Id = obj.UserAuthentications.Id,
                    //    ActorId = obj.UserAuthentications.ActorId,
                    //    UserId = obj.Users.Id,
                    //    IsActive = obj.Users.IsActive,
                    //};



                    var model = new GetLicenses()
                    {
                        // WebRootPath = _he.WebRootPath,
                        Users = Users
                        //UserAuthentications = UserAuthentications
                    };

                    await Task.Run(() => _userAuthentication.UpdateLicensedUser(model));

                }
              

            }
            catch (Exception ex)
            {

                return BadRequest();
            }
            return RedirectToAction("LicensedUserList");

        }

        [HttpPost]
        public async Task<IActionResult> DeleteLicensedUser(long LicensedId)
        {
            try
            {
                var model = new GetLicenses()
                {
                    //WebRootPath = _he.WebRootPath,
                    LicensedId = LicensedId

                };
                await Task.Run(() => _userAuthentication.DeleteLicensedUser(model));

            }
            catch (Exception)
            {

                return BadRequest();
            }
            return RedirectToAction("LicensedUserList");

        }
        #endregion "Post Method"        
    }
}