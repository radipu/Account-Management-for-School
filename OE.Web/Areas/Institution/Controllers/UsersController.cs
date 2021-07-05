using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http; //[NOTE: for session]
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OE.Data;
using OE.Service;
using OE.Service.ServiceModels.UsersServ;
using OE.Web.Areas.Institution.Models.UserAuthenticationsVM;
using OE.Web.Areas.Institution.Models.UsersVM;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
namespace OE.Web.Areas.Institution.Controllers
{
    [Area("Institution")]
    public class UsersController : Controller, IActionFilter
    {
        #region "Variables"
        private readonly IUsersServ _oeUsersServ;
        private readonly IActorsServ _oeActorsServ;
        //private readonly IGendersServ _comGendersServ;
        //private readonly ICommonServ _commonServ;
        //private readonly IInstitutionsServ _oeInstitutionsServ;
        private readonly IWebHostEnvironment he;
        #endregion "Variables"

        #region "Constructor"
        public UsersController(
            IUsersServ oeUsersServ,
            IActorsServ oeActorsServ,
            //IInstitutionsServ oeInstitutionsServ,
            //IGendersServ comGendersServ,
            //ICommonServ commonServ,
            IWebHostEnvironment he
            )
        {
            _oeUsersServ = oeUsersServ;
            //_comGendersServ = comGendersServ;
            _oeActorsServ = oeActorsServ;
            //_oeInstitutionsServ = oeInstitutionsServ;
            //_commonServ = commonServ;
            this.he = he;
        }
        #endregion "Constructor"

        #region "GET Functions"        
        public IActionResult Index()
        {
            try
            {
                string CurrentActiveUserId = HttpContext.Session.GetString("session_CurrentActiveUserId");
                string CurrentActiveActorId = HttpContext.Session.GetString("session_currentActiveActorTab"); //[NOTE: 11=admin]
                if (!string.IsNullOrEmpty(CurrentActiveUserId) && (CurrentActiveActorId == "-1" || CurrentActiveActorId == "10" || CurrentActiveActorId == "11" || CurrentActiveActorId == "12" || CurrentActiveActorId == "13" || CurrentActiveActorId == "14"))
                {
                    var p = _oeUsersServ.GetUserByID(Convert.ToInt64(HttpContext.Session.GetString("session_CurrentActiveUserId")), he.WebRootPath);
                    var temp = new IndexUsersVM_Users()
                    {
                        Id = p.Users.Id,
                      
                        GenderId = p.Users.GenderId,
                        IP300X200 = p.Users.IP300X200
                      
                    };
                    var model = new IndexUsersVM()                   
                    {
                        users = temp
                    };

                    return View("Index/Index", model);
                }
                else
                {
                    return RedirectToAction("Login", "Home", new { area = "" });
                }

            }
            catch (Exception)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
        }        
       
        #endregion "GET Functions"

        #region "GET Functions -Login"
        public ActionResult LogOut(DateTime? logoutDate = null)
        {
            try
            {                
                string currentUserId = HttpContext.Session.GetString("session_CurrentActiveUserId");
                if(currentUserId!=null && logoutDate != null)
                {
                    //[NOTE: store logout date]
                    //_oeUsersServ.UpdateLastLogoutDate(Convert.ToInt64(currentUserId), logoutDate);
                }
                
                if (HttpContext.Session.GetString("session_CurrentActiveUserId") != null)
                {
                    HttpContext.Session.Clear();
                    return RedirectToAction("Login", "Home", new { area = "" });
                }
                else
                {
                    return RedirectToAction("Login", "Home", new { area = "" });
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
        }
        public IActionResult ChangePassword()
        {
            try
            {
                if (HttpContext.Session.GetString("session_CurrentActiveUserId") != null)
                {
                    var currentUser = _oeUsersServ.GetUserByID(Convert.ToInt64(HttpContext.Session.GetString("session_CurrentActiveUserId")), he.WebRootPath);                   
                    var userList = new List<IndexUsersVM_Users>();
                    var u = new IndexUsersVM_Users                    
                    {
                        Id = currentUser.Users.Id,
                       
                        GenderId = currentUser.Users.GenderId,
                        FirstName = currentUser?.Users?.FirstName,
                        LastName = currentUser?.Users?.LastName,
                        IP300X200 = currentUser?.Users?.IP300X200,
                        IP600X400 = currentUser?.Users?.IP600X400,
                      
                        OurEduId = currentUser?.Users?.OurEduId,
                        Password = currentUser?.Users?.Password
                    };

                    userList.Add(u);                    
                    var model = new IndexUsersVM()                   
                    {
                        OEUsersListVMs = userList
                    };
                    return View("ChangePassword/ChangePassword", model);
                }
                else
                {
                    return RedirectToAction("Login", "Home", new { area = "" });
                }
            }
            catch (Exception)
            {

                return RedirectToAction("Login", "Home", new { area = "" });

            }
        }
        public IActionResult ChangeUserLogin()
        {
            try
            {
                if (HttpContext.Session.GetString("session_CurrentActiveUserId") != null)
                {
                    var currentUser = _oeUsersServ.GetUserByID(Convert.ToInt64(HttpContext.Session.GetString("session_CurrentActiveUserId")), he.WebRootPath);                    
                    var user = new IndexUsersVM_Users                    
                    {
                        Id = currentUser.Users.Id
                    };                    
                    var model = new IndexUsersVM()                   
                    {
                        users = user,
                    };
                    return View("ChangeUserLogin/ChangeUserLogin", model);
                }
                else
                {
                    return RedirectToAction("Login", "Home", new { area = "" });
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Login", "Home", new { area = "" });
            }
        }            
        #endregion "GET Functions -Login"
        
        #region "Post function"       
        
        #endregion "Post function"

        #region "Security methods"

        //[HttpPost]
        //public IActionResult SetCurrentActorTab(string CurrentActorTabId)
        //{            
        //   // HttpContext.Session.SetString("session_currentActiveActorTab", CurrentActorTabId);
        //   //HttpContext.Session.SetString("session_currentUserOurEduDetailId", CurrentActorTabId);

        //   // //[NOTE: set defalut page]
        //   // string CurrentActiveActorId = HttpContext.Session.GetString("session_currentActiveActorTab");
        //   // if (CurrentActiveActorId == "-1") //[NOTE: user Tab]
        //   // {
        //   //     return RedirectToAction("Index", "Users", new { area = "Institution" });                
        //   // }
        //   // else if (CurrentActiveActorId == "10") //[NOTE: Student Tab]
        //   // {
        //   //     return RedirectToAction("ResultSearchByStudent", "Results", new { area = "Institution" });

        //   // }
        //   // else if (CurrentActiveActorId == "11") //[NOTE: Admin Tab]
        //   // {
        //   //     return RedirectToAction("MyInstitutionDetails", "Institutions", new { area = "Institution" });

        //   // }
        //   // else if (CurrentActiveActorId == "12") //[NOTE: Register Tab]
        //   // {
        //   //     return RedirectToAction("AssignedSections", "AssignedSections", new { area = "Institution" });
        //   // }
        //   // else if (CurrentActiveActorId == "13") //[NOTE: Accountant Tab]
        //   // {
        //   //     return RedirectToAction("Students", "Students", new { area = "Institution" });
        //   // }
        //   // else if (CurrentActiveActorId == "14") //[NOTE: Teacher Tab]
        //   // {
        //   //     return RedirectToAction("GetCoursesList", "AssignedTeachers", new { area = "Institution" });
        //   // }
        //   // else
        //   // {
        //   //     return RedirectToAction("Index", "Users", new { area = "Institution" });
        //   // }

        //}

        [HttpPost]
        public JsonResult SetCurrentActorTab(string CurrentActorTabId)
        {
            var actorId = (dynamic)null;
            if (CurrentActorTabId != null)
            {
                HttpContext.Session.SetString("session_currentActiveActorTab", CurrentActorTabId);

                //[NOTE: set defalut page]
                actorId = HttpContext.Session.GetString("session_currentActiveActorTab");               
            }
           
            return Json(new { actorId });

        }
              
        [HttpPost]
        public JsonResult SetActiveMenu(string ActiveMenuName = null)
        {
            var menuName = (dynamic)null;
            if (ActiveMenuName != null)
            {
                //[NOTE: set current active menu bar]
                HttpContext.Session.SetString("session_currentActiveMenuName", ActiveMenuName);
            }
            return Json(new { menuName });
        }        
        #endregion "Security methods"

        #region "Report Method"
     
        #endregion "Report Method"
    }
}
