using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http; //[NOTE: for session]
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OE.Data;
using OE.Service;

using OE.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OE.Web.Controllers
{
    public class HomeController : Controller, IActionFilter
    {
        #region "Variables"
        private IndexLayoutVM layout;

        private readonly IUsersServ _usersService;
        private readonly IUserAuthenticationsServ _userAuthenticationsService;
        
        private readonly IWebHostEnvironment he;
        #endregion "Variables"

        #region "Constructor"

        public HomeController(
            IUsersServ userServ,
            IUserAuthenticationsServ userAuthenticationServ,
           
            IWebHostEnvironment he
           
            )
        {
            _usersService = userServ;
            _userAuthenticationsService = userAuthenticationServ;
         
            this.he = he;
            
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            //var headerFooterDetials = _institutionServ.GetLicensesDetails();

            var layout = new List<IndexLayoutVM>();
            var myController = context.Controller as HomeController;

            //var inslink = (dynamic)null;
            var insLinksVM = new List<InstitutionLinksListVM>();
            //if (headerFooterDetials != null)
            //{
            //    //inslink = _insLinksServ.GetInstitutionLinks(new GetInstitutionLinks() {webRootPath = he.WebRootPath }, headerFooterDetials.Institution.Id);
                
            //    //foreach (var item in inslink)
            //    foreach (var item in inslink.institutionLinks)               
            //    {
            //        string path = string.IsNullOrEmpty(item.IP24X24) ? "" : item.IP24X24;
            //        var e = new InstitutionLinksListVM
            //        {
            //            Name = item.Name,
            //            IP24X24 = _commonServ.CommImage_WrapperDefaultImage(path, he.WebRootPath, 0),
            //            Url = item.Url
            //        };

            //        insLinksVM.Add(e);
            //    }
            //}
            //var listInsPages = _insPagesServ.GetInsPages(new GetInsPages() {webRootPath = he.WebRootPath });
            //var itemInsPages = new List<InsPages>();            
            //foreach (var item in listInsPages.insPages)            
            //{
            //    var insPages = new InsPages()
            //    {
            //        Id = item.Id,
            //        Title = item.Title,
            //        IP300X200 = item.IP300X200,
            //        IP600X400 = item.IP600X400,
            //        IsActive = item.IsActive

            //    };
            //    itemInsPages.Add(insPages);
            //}
            //var LicenceDetails = _commonServ.CommLicence_getLicenseDetails();
            myController.layout = new IndexLayoutVM
            {               
                //InstitutionName = headerFooterDetials != null ? headerFooterDetials.Institution.Name : "OurEdu",
                //Logo = headerFooterDetials?.Institution.LogoPath,
                //Favicon = headerFooterDetials?.Institution.FaviconPath,
                //Email = headerFooterDetials?.Institution.Email,
                //Contact = headerFooterDetials?.Institution.ContactNo,                
                //_insPagesVM = itemInsPages,                
                //LicenceDetails = LicenceDetails,                
                _insLinksVM = insLinksVM
            };
            myController.ViewBag.IndexLayoutVM = myController.layout;
        }
        #endregion "Constructor"

        #region "Get Functions"
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult InsPageDetails(long insPageId)
        {
            ViewBag.OeErrorMessage = null;
            try
            {
                //var insPageDetails = _insPageDetailsServ.GetInsPageDetailsByInsPageId(insPageId);
                var ipDetailsList = new List<InsPageDetailsListVM>();                
                //var LicenceDetails = _commonServ.CommLicence_getLicenseDetails();                
                //foreach (var item in insPageDetails._InsPageDatailsList)
                //{
                //    var temp = new InsPageDetailsListVM()
                //    {
                //        Id = item.Id,                        
                //        InsPageId = item.InsPageId.Value,                        
                //        Description = item.Description,
                //        Title = item.Title,                       
                //        Sorting = item.Sorting.Value                        
                //    };
                //    ipDetailsList.Add(temp);
                //}

                var model = new IndexInsPageDetailsVM()
                {
                    InsPageDetailsList = ipDetailsList,
                    //InsPageId = insPageDetails.InsPageId,
                    //InsPageTitle = insPageDetails.InsPageTitle,                    
                    //LicenceDetails = LicenceDetails,                    
                    //IP300X200 = insPageDetails.IP300X200,
                    //IP600X400 = insPageDetails.IP600X400
                };

                return View("InsPageDetails/InsPageDetails", model);
            }
            catch (Exception ex)
            {
                ViewBag.OeErrorMessage = "ERROR101:InsPages/InsPageDetails - " + ex.Message;
                return View("InsPageDetails/InsPageDetails");
            }
        }
        public IActionResult RedirectMessage(string msg)
        {          
            ViewBag.Message = msg;
            return View("AllMessages/RedirectMessage");
        }
        #endregion "Get Functions"    

        #region "Get Functions- Login"         
        public IActionResult Login(string msg = "")
        {
            ViewBag.OeErrorMessage = null;
            try
            {
                ViewBag.msg = msg;
                //var insInformation = _institutionServ.GetLicensesDetails();               
                //var LicenceDetails = _commonServ.CommLicence_getLicenseDetails();               
                var model = new IndexLoginVM()
                {      
                  
                    //LicenceDetails = LicenceDetails,                             
                    //InstitutionName = insInformation.Institution.Name,
                    //Logo = insInformation.Institution.LogoPath                   
                };
                return View("Login/Login", model);
            }
            catch (Exception ex)
            {
                ViewBag.OeErrorMessage = "ERROR101:Login - " + ex.Message;
                return View("Login/Login");
            }
        }

       
        #endregion "Get Functions- Login"               

        #region "POST Functions" 
        
        
        [HttpPost]
        public IActionResult Login(IndexLoginVM obj)
        {
            ViewBag.OeErrorMessage = null;
            try
            {
                var currentLoginDetails = _usersService.GetUserLogin(obj.OurEduId, obj.Password);
               
                //[NOTE:if login is not match]                
                if (currentLoginDetails.OurEduId == null)               
                {                   
                    
                    var model = new IndexLoginVM()
                    {                        
                        InstitutionName = "Shidlai Ashraf Secondary School, Brahmanpara, Cumilla",                       
                        Logo = null
                    };

                    ViewBag.msg = "Invalid User Information";
                    return View("Login/Login", model);
                }

                //[NOTE:Creating session and access the system actor wise.]
                else
                {
                    var userAuthenticationList = _userAuthenticationsService.GetUserAuthenticationsByUserId(currentLoginDetails.Id);
                    string result = "-1;";
                    if (userAuthenticationList != null)
                    {
                        foreach (var item in userAuthenticationList._UsersAuthencations)
                        {
                            result = result + item.ActorId.ToString() + ";";
                        }
                    }
                    
                    string activeUser = (currentLoginDetails.Id).ToString();                    
                    HttpContext.Session.SetString("session_CurrentActiveUserId", activeUser);
                    HttpContext.Session.SetString("session_UserName", currentLoginDetails.FirstName);
                    HttpContext.Session.SetString("session_currentUserAuthentications", result);
                    HttpContext.Session.SetString("session_currentActiveActorTab", "-1");
                    HttpContext.Session.SetString("session_currentUserOurEduDetailId", "-1");                    
                    HttpContext.Session.SetString("session_loginInstitutionName", "Shidlai Ashraf Secondary School, Brahmanpara, Cumilla");
                    
                    return RedirectToAction("Index", "Users", new { area = "Institution" });
                }
            }
            catch (Exception ex)
            {
                ViewBag.OeErrorMessage = "ERROR101:Login - " + ex.Message;
                return View("Login/Login");

            }
        }
       
        #endregion "POST Fuctions"
    }
}
