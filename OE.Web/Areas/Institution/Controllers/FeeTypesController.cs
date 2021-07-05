
using Microsoft.AspNetCore.Mvc;
using OE.Service;
using OE.Service.ServiceModels.FeeTypesServ;
using OE.Web.Areas.Institution.Models;
using OE.Web.Areas.Institution.Models.FeeTypesVM;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OE.Web.Areas.Institution.Controllers
{
    [Area("Institution")]
    public class FeeTypesController : Controller
    {        
        #region "Variables"
        private readonly IFeeTypesServ _FeeTypesServ;
        private readonly IClassesServ _classesServ;
        #endregion "Variables"

        #region "Constructor"
        public FeeTypesController(
            IFeeTypesServ FeeTypesServ, IClassesServ classesServ
        )
        {
            _FeeTypesServ = FeeTypesServ;
            _classesServ = classesServ;
        }
        #endregion "Constructor"

        #region "Get methods"
      
        public async Task<IActionResult> FeeTypesList(int pg = 1)
        {
            try
            {
                var FeeTypesList = Task.Run(() => _FeeTypesServ.getFeeTypesList());
                var result = await FeeTypesList;
                ViewBag.ddlClass = _classesServ.dropdown_Class();
                var list = new List<IndexFeeTypesListVM_FeeTypes>();
                foreach (var item in result._FeeTypes.ToList())
                {
                    var temp = new IndexFeeTypesListVM_FeeTypes()
                    {
                        Id = item.Id,
                        ClassId = item.ClassId,
                        ClassName = item.ClassName,
                        Name = item.Name,
                        IsActive = item.IsActive
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

                var model = new IndexFeeTypesListVM()
                {
                    _FeeTypes = data
                };
                #endregion "Paging"
                
                return View("FeeTypesList", model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> FeeTypesListByAdmin(int pg = 1)
        {
            try
            {
                var FeeTypesList = Task.Run(() => _FeeTypesServ.getFeeTypesList());
                var result = await FeeTypesList;
                ViewBag.ddlClass = _classesServ.dropdown_Class();
                var list = new List<IndexFeeTypesListByAdminVM_FeeTypes>();
                foreach (var item in result._FeeTypes.ToList())
                {
                    var temp = new IndexFeeTypesListByAdminVM_FeeTypes()
                    {
                        Id = item.Id,
                        ClassId = item.ClassId,
                        ClassName = item.ClassName,
                        Name = item.Name,
                        IsActive = item.IsActive
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
                var model = new IndexFeeTypesListByAdminVM()
                {
                    _FeeTypes = data
                };
                #endregion "Paging"
                
                return View("FeeTypesListByAdmin", model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> SearchFeeTypesByAdmin(string SearchFeetypeClassId, int pg = 1)
        {
            try
            {
                if (String.IsNullOrEmpty(SearchFeetypeClassId))
                {
                    var model = new IndexFeeTypesListVM()
                    {
                        _FeeTypes = null,
                        SearchFeetypeClassId = null
                    };
                    return View("FeeTypesListByAdmin", model);
                }
                else
                {
                    var result = new SearchFeeTypes()
                    {
                        SearchFeetypeClassId = SearchFeetypeClassId
                    };
                    var SearchFeeTypes = await Task.Run(() => _FeeTypesServ.SearchFeeTypes(result));
                    ViewBag.ddlClass = _classesServ.dropdown_Class();
                    var list = new List<IndexFeeTypesListVM_FeeTypes>();
                    foreach (var item in SearchFeeTypes._FeeTypes.ToList())
                    {
                        var temp = new IndexFeeTypesListVM_FeeTypes()
                        {
                            Id = item.Id,
                            ClassId = item.ClassId,
                            ClassName = item.ClassName,
                            Name = item.Name,
                            IsActive = item.IsActive
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
                    var model = new IndexFeeTypesListVM()
                    {
                        _FeeTypes = data,
                        SearchFeetypeClassId = SearchFeetypeClassId,
                        SearchClassName = SearchFeeTypes.SearchClassName.ToString()
                    };
                    #endregion "Paging"
                    
                    return View("FeeTypesListByAdmin", model);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> SearchFeeTypes(string SearchFeetypeClassId, int pg = 1)
        {
            try
            {
                if (String.IsNullOrEmpty(SearchFeetypeClassId))
                {
                    var model = new IndexFeeTypesListVM()
                    {
                        _FeeTypes = null,
                        SearchFeetypeClassId = null
                    };
                    return View("FeeTypesList", model);
                }
                else
                {
                    var result = new SearchFeeTypes()
                    {
                        SearchFeetypeClassId = SearchFeetypeClassId
                    };
                    var SearchFeeTypes = await Task.Run(() => _FeeTypesServ.SearchFeeTypes(result));
                    ViewBag.ddlClass = _classesServ.dropdown_Class();
                    var list = new List<IndexFeeTypesListVM_FeeTypes>();
                    foreach (var item in SearchFeeTypes._FeeTypes.ToList())
                    {
                        var temp = new IndexFeeTypesListVM_FeeTypes()
                        {
                            Id = item.Id,
                            ClassId = item.ClassId,
                            ClassName = item.ClassName,
                            Name = item.Name,
                            IsActive = item.IsActive
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
                    var model = new IndexFeeTypesListVM()
                    {
                        _FeeTypes = data,
                        SearchFeetypeClassId = SearchFeetypeClassId,
                        SearchClassName = SearchFeeTypes.SearchClassName.ToString()
                    };
                    #endregion "Paging"
                   
                    return View("FeeTypesList", model);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        #endregion "Get methods"

       
        #region "Post_Methods"
        [HttpPost]
        public async Task<IActionResult> InsertFeeType(IndexFeeTypesListVM obj)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if (obj.FeeTypes != null)
                    {
                        var FeeTypes = new InsertFeeType_FeeTypes()
                        {
                            ClassId = obj.FeeTypes.ClassId,
                            Name = obj.FeeTypes.Name,
                            IsActive = obj.FeeTypes.IsActive
                        };

                        var model = new InsertFeeType()
                        {
                            FeeTypes = FeeTypes
                        };

                        await Task.Run(() => _FeeTypesServ.InsertFeeType(model));
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("FeeTypesList");

        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeeType(IndexFeeTypesListVM obj)
        {
            try
            {
                if (obj.FeeTypes != null)
                {
                    var FeeTypes = new UpdateFeeType_FeeTypes()
                    {
                        Id = obj.FeeTypes.Id,
                        ClassId = obj.FeeTypes.ClassId,
                        Name = obj.FeeTypes.Name,
                        IsActive = obj.FeeTypes.IsActive
                    };

                    var model = new UpdateFeeType()
                    {
                        FeeTypes = FeeTypes
                    };

                    await Task.Run(() => _FeeTypesServ.UpdateFeeType(model));
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return RedirectToAction("FeeTypesList");

        }
        [HttpPost]
        public async Task<IActionResult> DeleteFeeType(long FeeTypeId)
        {
            try
            {
                var model = new DeleteFeeType()
                {
                    FeeTypeId = FeeTypeId
                };
                await Task.Run(() => _FeeTypesServ.DeleteFeeType(model));
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return RedirectToAction("FeeTypesList");
        }
        #endregion "Post_Methods"

        #region "Report Methods"
        public IActionResult PrintFeeTypesList()
        {
            ViewBag.OeErrorMessage = null;
            var model = new PrintIndexFeeTypesListVM();
            try
            {

                string footer = "--footer-center \"  Printed Date: " +
                      DateTime.Now.Date.ToString("dd/MM/yyyy") + " - " + "  Page: [page] to [toPage]\"" +
                      " --footer-line --footer-font-size \"10\" --footer-spacing 1 --footer-font-name \"Courier New\"";


                var result = _FeeTypesServ.PrintGetFeeTypesList();

                var list = new List<PrintIndexFeeTypesListVM_FeeTypes>();
                foreach (var item in result._FeeTypes.ToList())
                {
                    var temp = new PrintIndexFeeTypesListVM_FeeTypes()
                    {
                        Id = item.Id,
                        ClassId = item.ClassId,
                        ClassName = item.ClassName,
                        Name = item.Name,
                        IsActive = item.IsActive
                    };
                    list.Add(temp);
                };


                //[NOTE: map institutions]
                var currentInstitution = new PrintIndexFeeTypesListVM_Institutions()
                {
                    Id = result.Institution.Id,
                    Name = result.Institution.Name,
                    IsActive = result.Institution.IsActive,
                    LogoPath = result.Institution.LogoPath,
                    FaviconPath = result.Institution.FaviconPath,
                    Email = result.Institution.Email,
                    ContactNo = result.Institution.ContactNo,
                    Address = result.Institution.Address
                };

                model = new PrintIndexFeeTypesListVM()
                {
                    _FeeTypes = list,
                    Institution = currentInstitution
                };

                return new ViewAsPdf("PrintFeeTypesList", model)
                {

                    CustomSwitches = footer

                };

            }
            catch (Exception ex)
            {
                ViewBag.OeErrorMessage = "ERROR101:ExamTypes/PrintExamTypes -" + ex.Message;
                return View("PrintFeeTypesList");
            }
        }
        #endregion "Report Methods"
       
    }
}

