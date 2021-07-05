//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using OE.Service;
//using OE.Service.ServiceModels;
//using OE.Service.ServiceModels.ClassesServ;
//using OE.Web.Areas.Institution.Models.ClassesVM;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace OE.Web.Areas.Institution.Controllers
//{
//    [Area("Institution")]
//    public class ClassesController : Controller
//    {
//        #region "Variables"
//        private readonly IClassesServ _classesServ;
       

        

//        #endregion "Variables"

//        #region "Constructor"
//        public ClassesController(
//            IClassesServ classesServ
           
//            )
//        {
//            _classesServ = classesServ;
           
//        }
//        #endregion "Constructor"

//        #region "Get_Methods"
//        public IActionResult Classes()
//        {
//            ViewBag.OeErrorMessage = null;
//            try
//            {
//                string CurrentActiveUserId = HttpContext.Session.GetString("session_CurrentActiveUserId");
//                string CurrentActiveActorId = HttpContext.Session.GetString("session_currentActiveActorTab"); //[NOTE: 10=Student, 11=Admin, 12=Register,13=Accountant, 14=Teacher]
//                if (!string.IsNullOrEmpty(CurrentActiveUserId) && (CurrentActiveActorId == "11"))

//                {
//                    var listClasses = _classesServ.getClassList();
//                    //var currentInstitutionDetails = _oeInstitutionsServ.GetInstitutionsById(1);
//                    ViewBag.msg = TempData["error"];
//                    var classList = new List<IndexClassesVM_Classes>();
//                    foreach (var item in listClasses._Classes)
//                    {
//                        var e = new IndexClassesVM_Classes
//                        {
//                            Id = item.Id,
//                            Name = item.Name
//                        };
//                        classList.Add(e);
//                    }

//                    //[NOTE: integrate all records for the specific page. ]                    
//                    var model = new IndexClassesVM()
//                    {
//                        InstitutionName =  "",
//                        _classesVM = classList
//                    };
//                    return View("Classes", model);
//                }
//                else
//                {
//                    if (HttpContext.Session.GetString("session_currentUserAuthentications") == null)
//                    {
//                        string msg = "ERROR101:Classes/Classes -unauthorized access is not permitted";
//                        return RedirectToAction("RedirectMessage", "Home", new { msg = msg, area = " " });
//                    }
//                    else
//                    {
//                        return RedirectToAction("RedirectMessage", "AllMessages", new { area = "Institution" });
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                ViewBag.OeErrorMessage = "ERROR101:Classes/Classes -" + ex.Message;
//                return View("Classes");
//            }
//        }
//        #endregion "Get_Methods"

//        //#region "Post_Methods"

//        //public async Task<IActionResult> InsertClasses(IndexClassListVM obj)
//        //{
//        //    try
//        //    {
//        //        if (ModelState.IsValid)
//        //        {
//        //            ViewBag.Message = obj.Classes.Name + " " + "Successfully registered!";
//        //        }
//        //        if (obj.Classes != null)
//        //        {
//        //            var Classes = new InsertClass_Classes()
//        //            {
//        //                Id = obj.Classes.Id,
//        //                Name = obj.Classes.Name
//        //            };

//        //            var model = new InsertClass()
//        //            {
//        //                Classes = Classes
//        //            };

//        //            await Task.Run(() => _classesServ.InsertClass(model));
//        //        }
//        //    }
//        //    catch (Exception)
//        //    {
//        //        return BadRequest();
//        //    }
//        //    return RedirectToAction("ClassList");
//        //}

//        //#endregion "Post_Methods"

//        #region "Post Methods"
//        
//        #region "Post_Methods"        
//        [HttpPost]
//        public async Task<IActionResult> InsertClasses(IndexClassListVM obj)
//        {
//            try
//            {
//                //if (ModelState.IsValid)
//                //{
//                //    ViewBag.Message = obj.Classes.Name + " " + "Successfully registered!";
//                //}
//                if (obj.Classes != null)
//                {
//                    var Classes = new InsertClass_Classes()
//                    {
//                        Id = obj.Classes.Id,
//                        Name = obj.Classes.Name
//                    };

//                    var model = new InsertClass()
//                    {
//                        Classes = Classes
//                    };

//                    await Task.Run(() => _classesServ.InsertClass(model));
//                }
//            }
//            catch (Exception)
//            {

//                return BadRequest();
//            }
//            return RedirectToAction("ClassList");
//        }

//        [HttpPost]
//        public async Task<IActionResult> UpdateClass(IndexClassListVM obj)
//        {
//            try
//            {
//                if (obj.Classes != null)
//                {
//                    var Classes = new UpdateClass_Classes()
//                    {
//                        Id = obj.Classes.Id,
//                        Name = obj.Classes.Name

//                    };

//                    var model = new UpdateClass()
//                    {
//                        Classes = Classes
//                    };

//                    await Task.Run(() => _classesServ.UpdateClass(model));
//                }
//            }
//            catch (Exception)
//            {

//                return BadRequest();
//            }
//            return RedirectToAction("ClassList");

//        }
//        [HttpPost]
//        public async Task<IActionResult> DeleteClass(long classid)
//        {
//            try
//            {
//                var model = new DeleteClass()
//                {
//                    ClassId = classid
//                };
//                await Task.Run(() => _classesServ.DeleteClass(model));
//            }
//            catch (Exception)
//            {

//                return BadRequest();
//            }
//            return RedirectToAction("ClassList");
//        }
//        #endregion "Post_Methods"
//        
//        #endregion "Post Methods"
//    }
//}


using Microsoft.AspNetCore.Mvc;
using OE.Service;
using OE.Service.ServiceModels.ClassesServ;
using OE.Web.Areas.Institution.Models;
using OE.Web.Areas.Institution.Models.ClassesVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace OE.Web.Areas.Institution.Controllers
{
    [Area("Institution")]
    public class ClassesController : Controller
    {
        #region "Variables"
        private readonly IClassesServ _classesServ;
        #endregion "Variables"

        #region "Constructor"
        public ClassesController(
            IClassesServ classesServ
        )
        {
            _classesServ = classesServ;
        }
        #endregion "Constructor"

        #region "Get methods"
        public async Task<IActionResult> ClassList(int pg = 1, bool isSuccess=false)
        {
            try
            {
                var classList = Task.Run(() => _classesServ.getClassList());
                var result = await classList;
                var list = new List<Vm_Classes>();
                foreach (var item in (dynamic)result._Classes.ToList())
                {
                    var temp = new Vm_Classes()
                    {
                        Id = item.Id,
                        Name = item.Name
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
                var model = new IndexClassListVM()
                {
                    _Classes = data
                };
                #endregion "Paging"
                
                return View("ClassList", model);
            }
            catch (Exception ex)
            {
                var test = ex.Message;
                return BadRequest();
            }
        }
        #endregion "Get methods"

        #region "Post_Methods"
        [HttpPost]
        public async Task<IActionResult> InsertClasses(IndexClassListVM obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (obj.Classes != null)
                    {
                        var Classes = new InsertClass_Classes()
                        {
                            Id = obj.Classes.Id,
                            Name = obj.Classes.Name
                        };
                        var model = new InsertClass2()
                        {
                            Classes = Classes
                        };
                        await Task.Run(() => _classesServ.InsertClass(model));
                    }                   
                }               
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("ClassList");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateClass(IndexClassListVM obj)
        {
            try
            {
                if (obj.Classes != null)
                {
                    var Classes = new UpdateClass_Classes()
                    {
                        Id = obj.Classes.Id,
                        Name = obj.Classes.Name
                    };
                    var model = new UpdateClass()
                    {
                        Classes = Classes
                    };
                    await Task.Run(() => _classesServ.UpdateClass(model));
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("ClassList");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteClass(long classid)
        {
            try
            {
                var model = new DeleteClass2()
                {
                    ClassId = classid
                };
                await Task.Run(() => _classesServ.DeleteClass(model));
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("ClassList");
        }
        #endregion "Post_Methods"
    }
}

