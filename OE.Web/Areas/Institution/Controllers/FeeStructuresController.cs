
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OE.Service;
using OE.Service.ServiceModels.FeeStructuresServ;
using OE.Web.Areas.Institution.Models;
using OE.Web.Areas.Institution.Models.FeeStructuresVM;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace OE.Web.Areas.Institution.Controllers
{
    [Area("Institution")]
    public class FeeStructuresController : Controller
    {      

        #region "Variables"
        private readonly IFeeStructuresServ _FeeStructuresServ;
        private readonly IFeeTypesServ _FeeTypesServ;
        private readonly IClassesServ _classesServ;
        #endregion "Variables"

        #region "Constructor"
        public FeeStructuresController(
            IFeeStructuresServ FeeStructuresServ, IFeeTypesServ FeeTypesServ, IClassesServ classesServ
        )
        {
            _FeeStructuresServ = FeeStructuresServ;
            _FeeTypesServ = FeeTypesServ;
            _classesServ = classesServ;
        }
        #endregion "Constructor"

        #region "Get methods"
     
        public async Task<IActionResult> FeeStructuresList(int pg = 1)
        {
            try
            {
                var FeeStructuresList = Task.Run(() => _FeeStructuresServ.getFeeStructuresList());
                var result = await FeeStructuresList;
                ViewBag.ddlClass = _classesServ.dropdown_Class();
                var list = new List<Vm_FeeStructures>();
                foreach (var item in result._FeeStructures.ToList())
                {
                    var temp = new Vm_FeeStructures()
                    {
                        Id = item.Id,
                        ClassId = item.ClassId,
                        Class = item.Class,
                        FeeTypeId = item.FeeTypeId,
                        FeeType = item.FeeType,
                        FeeTypeMood = item.FeeTypeMood,
                        Amount = item.Amount,
                        StartingYear = item.StartingYear,
                        EndingYear = item.EndingYear != null ? item.EndingYear : null,
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

                var model = new IndexFeeStructuresListVM()
                {
                    _FeeStructures = data
                };

                #endregion "Paging"
                
                return View("FeeStructuresList", model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> FeeStructuresListByAdmin(int pg = 1)
        {
            try
            {
                var FeeStructuresList = Task.Run(() => _FeeStructuresServ.getFeeStructuresList());
                var result = await FeeStructuresList;
                ViewBag.ddlClass = _classesServ.dropdown_Class();
                var list = new List<IndexFeeStructuresListByAdminVM_FeeStructures>();
                foreach (var item in result._FeeStructures.ToList())
                {
                    var temp = new IndexFeeStructuresListByAdminVM_FeeStructures()
                    {
                        Id = item.Id,
                        ClassId = item.ClassId,
                        Class = item.Class,
                        FeeTypeId = item.FeeTypeId,
                        FeeType = item.FeeType,
                        FeeTypeMood = item.FeeTypeMood,
                        Amount = item.Amount,
                        StartingYear = item.StartingYear,
                        EndingYear = item.EndingYear,
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

                var model = new IndexFeeStructuresListByAdminVM()
                {
                    _FeeStructures = data
                };

                #endregion "Paging"
                
                return View("FeeStructuresListByAdmin", model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> SearchFeeStructures(string SearchClassId, int pg = 1)
        {
            try
            {
                if (String.IsNullOrEmpty(SearchClassId))
                {
                    var model = new IndexFeeStructuresListVM()
                    {
                        _FeeStructures = null,
                        SearchClassId = null
                    };
                    return View("FeeStructuresList", model);
                }
                else
                {
                    var result = new SearchFeeStructures()
                    {
                        SearchClassId = SearchClassId
                    };
                    var SearchFeeStructures = await Task.Run(() => _FeeStructuresServ.SearchFeeStructures(result));
                    ViewBag.ddlClass = _classesServ.dropdown_Class();
                    var list = new List<Vm_FeeStructures>();
                    foreach (var item in SearchFeeStructures._FeeStructures.ToList())
                    {
                        var temp = new Vm_FeeStructures()
                        {
                            Id = item.Id,
                            ClassId = item.ClassId,
                            Class = item.Class,
                            FeeTypeId = item.FeeTypeId,
                            FeeType = item.FeeType,
                            FeeTypeMood = item.FeeTypeMood,
                            Amount = item.Amount,
                            StartingYear = item.StartingYear,
                            EndingYear = item.EndingYear,
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
                    var model = new IndexFeeStructuresListVM()
                    {
                        _FeeStructures = data,
                        SearchClassId = SearchClassId,
                        ammount = SearchFeeStructures.DateRangeAmount,
                        SearchClassName = SearchFeeStructures.SearchClassName
                    };
                    #endregion "Paging"
                  

                    return View("FeeStructuresList", model);
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
        public async Task<IActionResult> InsertFeeStructure(IndexFeeStructuresListVM obj)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if (obj.FeeStructures != null)
                    {
                        var FeeStructures = new InsertFeeStructure_FeeStructures()
                        {
                            ClassId = obj.FeeStructures.ClassId,
                            FeeTypeId = obj.FeeStructures.FeeTypeId,
                            Amount = obj.FeeStructures.Amount,
                            YearlyTermNo = obj.FeeStructures.YearlyTermNo,
                            StartYear = obj.FeeStructures.StartYear,
                            EndYear = obj.FeeStructures.EndYear,
                            IsActive = obj.FeeStructures.IsActive
                        };
                        var model = new InsertFeeStructure()
                        {
                            FeeStructures = FeeStructures
                        };
                        await Task.Run(() => _FeeStructuresServ.InsertFeeStructure(model));
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("FeeStructuresList");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeeStructure(IndexFeeStructuresListVM obj)
        {
            try
            {
                if (obj.FeeStructures != null)
                {
                    var FeeStructures = new UpdateFeeStructure_FeeStructures()
                    {
                        Id = obj.FeeStructures.Id,
                        ClassId = obj.FeeStructures.ClassId,
                        FeeTypeId = obj.FeeStructures.FeeTypeId,
                        Amount = obj.FeeStructures.Amount,
                        YearlyTermNo = obj.FeeStructures.YearlyTermNo,
                        StartYear = obj.FeeStructures.StartYear,
                        EndYear = obj.FeeStructures.EndYear,
                        IsActive = obj.FeeStructures.IsActive
                    };
                    var model = new UpdateFeeStructure()
                    {
                        FeeStructures = FeeStructures
                    };
                    await Task.Run(() => _FeeStructuresServ.UpdateFeeStructure(model));
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("FeeStructuresList");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteFeeStructure(long FeeStructureId)
        {
            try
            {
                var model = new DeleteFeeStructure()
                {
                    FeeStructureId = FeeStructureId
                };
                await Task.Run(() => _FeeStructuresServ.DeleteFeeStructure(model));
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("FeeStructuresList");
        }
        #endregion "Post_Methods"

        #region "Post Methods- dropdown"
        public JsonResult DropDown_FeeTypes(long ddlClassId)
        {
            var result = (dynamic)null;
            if (ddlClassId != 0)
            {
                var ddlFeeTypes = _FeeTypesServ.dropdown_FeeType(ddlClassId);
                result = Json(new SelectList(ddlFeeTypes, "Id", "Name"));
            }
            return result;
        }
        #endregion "Post Methods- dropdown"

        #region "Report Methods"
        public IActionResult PrintFeeStructuresList()
        {
            ViewBag.OeErrorMessage = null;
            var model = new PrintIndexFeeStructuresListVM();
            try
            {
                string footer = "--footer-center \"  Printed Date: " +
                      DateTime.Now.Date.ToString("dd/MM/yyyy") + " - " + "  Page: [page] to [toPage]\"" +
                      " --footer-line --footer-font-size \"10\" --footer-spacing 1 --footer-font-name \"Courier New\"";
                var result = _FeeStructuresServ.PrintGetFeeStructuresList();
                var list = new List<PrintIndexFeeStructuresListVM_FeeStructures>();
                foreach (var item in result._FeeStructures.ToList())
                {
                    var temp = new PrintIndexFeeStructuresListVM_FeeStructures()
                    {
                        Id = item.Id,
                        ClassId = item.ClassId,
                        Class = item.Class,
                        FeeTypeId = item.FeeTypeId,
                        FeeType = item.FeeType,
                        FeeTypeMood = item.FeeTypeMood,
                        Amount = item.Amount,
                        StartingYear = item.StartingYear,
                        EndingYear = item.EndingYear,
                        IsActive = item.IsActive
                    };
                    list.Add(temp);
                };

                //[NOTE: map institutions]
                var currentInstitution = new PrintIndexFeeStructuresListVM_Institutions()
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
                model = new PrintIndexFeeStructuresListVM()
                {
                    _FeeStructures = list,
                    Institution = currentInstitution
                };
                return new ViewAsPdf("PrintFeeStructuresList", model)
                {
                    CustomSwitches = footer
                };
            }
            catch (Exception ex)
            {
                ViewBag.OeErrorMessage = "ERROR101:ExamTypes/PrintExamTypes -" + ex.Message;
                return View("PrintFeeStructuresList");
            }
        }
        #endregion "Report Methods"       
        
    }
}
