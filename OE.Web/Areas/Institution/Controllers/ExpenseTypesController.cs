
using Microsoft.AspNetCore.Mvc;
using OE.Service;
using OE.Service.ServiceModels.ExpenseTypesServ;
using OE.Web.Areas.Institution.Models;
using OE.Web.Areas.Institution.Models.ExpenseTypesVM;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace OE.Web.Areas.Institution.Controllers
{
    [Area("Institution")]
    public class ExpenseTypesController : Controller
    {
        #region "Variables"
        private readonly IExpenseTypesServ _ExpenseTypesServ;
        #endregion "Variables"

        #region "Constructor"
        public ExpenseTypesController(
            IExpenseTypesServ ExpenseTypesServ
        )
        {
            _ExpenseTypesServ = ExpenseTypesServ;

        }
        #endregion "Constructor"

        #region "Get methods"
        public async Task<IActionResult> ExpenseTypeList(int pg = 1)
        {
            try
            {
                var ExpenseTypeList = Task.Run(() => _ExpenseTypesServ.getExpenseTypesList());
                var result = await ExpenseTypeList;
                var list = new List<IndexExpensesListVM_ExpenseTypes>();
                foreach (var item in result._ExpenseTypes.ToList())
                {
                    var temp = new IndexExpensesListVM_ExpenseTypes()
                    {
                        Id = item.Id,
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
                var model = new IndexExpenseTypeListVM()
                {
                    _ExpenseTypes = data
                };
                #endregion "Paging"
               
                return View("ExpenseTypeList", model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

       
        public async Task<IActionResult> ExpenseTypeListByAdmin()
        {
            try
            {
                var ExpenseTypeList = Task.Run(() => _ExpenseTypesServ.getExpenseTypesList());
                var result = await ExpenseTypeList;
                var list = new List<IndexExpenseTypesListByAdminVM_ExpenseTypes>();
                foreach (var item in result._ExpenseTypes.ToList())
                {
                    var temp = new IndexExpenseTypesListByAdminVM_ExpenseTypes()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        IsActive = item.IsActive
                    };
                    list.Add(temp);
                };
                var model = new IndexExpenseTypesListByAdminVM()
                {
                    _ExpenseTypes = list,
                };
                return View("ExpenseTypeListByAdmin", model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion "Get methods"

        #region "Post_Methods"
        [HttpPost]
        public async Task<IActionResult> InsertExpenseType(IndexExpenseTypeListVM obj)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if (obj.ExpenseTypes != null)
                    {
                        var ExpenseTypes = new InsertExpenseType_ExpenseTypes()
                        {
                            Name = obj.ExpenseTypes.Name,
                            IsActive = obj.ExpenseTypes.IsActive
                        };
                        var model = new InsertExpenseType()
                        {
                            ExpenseTypes = ExpenseTypes
                        };
                        await Task.Run(() => _ExpenseTypesServ.InsertExpenseType(model));
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("ExpenseTypeList");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateExpenseType(IndexExpenseTypeListVM obj)
        {
            try
            {
                if (obj.ExpenseTypes != null)
                {
                    var ExpenseTypes = new UpdateExpenseType_ExpenseTypes()
                    {
                        Id = obj.ExpenseTypes.Id,
                        Name = obj.ExpenseTypes.Name,
                        IsActive = obj.ExpenseTypes.IsActive
                    };
                    var model = new UpdateExpenseType()
                    {
                        ExpenseTypes = ExpenseTypes
                    };
                    await Task.Run(() => _ExpenseTypesServ.UpdateExpenseType(model));
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("ExpenseTypeList");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteExpenseType(long ExpenseTypeId)
        {
            try
            {
                var model = new DeleteExpenseType()
                {
                    ExpenseTypeId = ExpenseTypeId
                };
                await Task.Run(() => _ExpenseTypesServ.DeleteExpenseType(model));
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("ExpenseTypeList");
        }
        #endregion "post method"

        #region "Report Methods"
        public IActionResult PrintExpenseTypeList()
        {
            ViewBag.OeErrorMessage = null;
            var model = new PrintIndexExpenseTypeListVM();
            try
            {
                string footer = "--footer-center \"  Printed Date: " +
                      DateTime.Now.Date.ToString("dd/MM/yyyy") + " - " + "  Page: [page] to [toPage]\"" +
                      " --footer-line --footer-font-size \"10\" --footer-spacing 1 --footer-font-name \"Courier New\"";
                var result = _ExpenseTypesServ.PrintGetExpenseTypesList();
                var list = new List<PrintIndexExpenseTypeListVM_ExpenseTypes>();
                foreach (var item in result._ExpenseTypes.ToList())
                {
                    var temp = new PrintIndexExpenseTypeListVM_ExpenseTypes()
                    {
                        Id = item.Id,
                        Name = item.Name,
                        IsActive = item.IsActive
                    };
                    list.Add(temp);
                };
                //[NOTE: map institutions]
                var currentInstitution = new PrintIndexExpenseTypeListVM_Institutions()
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
                //model._ExpenseTypes = list;
                model = new PrintIndexExpenseTypeListVM()
                {
                    _ExpenseTypes = list,
                    Institution = currentInstitution
                };
                return new ViewAsPdf("PrintExpenseTypeList", model)
                {
                    CustomSwitches = footer
                };
            }
            catch (Exception ex)
            {
                ViewBag.OeErrorMessage = "ERROR101:ExamTypes/PrintExamTypes -" + ex.Message;
                return View("PrintExpenseTypeList");
            }
        }
        #endregion "Report Methods"
       
    }
}
