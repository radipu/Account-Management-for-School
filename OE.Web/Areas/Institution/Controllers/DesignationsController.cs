using Microsoft.AspNetCore.Mvc;
using OE.Service;
using OE.Service.ServiceModels.DesignationsServ;
using OE.Web.Areas.Institution.Models;
using OE.Web.Areas.Institution.Models.DesignationsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace OE.Web.Areas.Institution.Controllers
{
    [Area("Institution")]
    public class DesignationsController : Controller
    {
        #region "Variables"
        private readonly IDesignationsServ _DesignationsServ;
        #endregion "Variables"

        #region "Constructor"
        public DesignationsController(
            IDesignationsServ DesignationsServ
        )
        {
            _DesignationsServ = DesignationsServ;

        }
        #endregion "Constructor"

        #region "Get methods"
        public async Task<IActionResult> DesignationsList(int pg = 1)
        {
            try
            {
                var DesignationsList = Task.Run(() => _DesignationsServ.getDesignationsList());
                var result = await DesignationsList;
                //ViewBag.ddlExpenseType = _ExpenseTypesServ.dropdown_ExpenseTypes();
                //var totalAmount = _ExpensesServ.allExpenses();
                var list = new List<IndexDesignationsListVM_Designations>();
                foreach (var item in result._Designations.ToList())
                {
                    var temp = new IndexDesignationsListVM_Designations()
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

                var model = new IndexDesignationsListVM()
                {
                    _Designations = data,
                };
                #endregion "Paging"

                return View("DesignationsList", model);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        public async Task<IActionResult> DesignationsListByAdmin(int pg = 1)
        {
            try
            {
                var DesignationsList = Task.Run(() => _DesignationsServ.getDesignationsList());
                var result = await DesignationsList;
                var list = new List<IndexDesignationsListByAdminVM_Designations>();
                foreach (var item in result._Designations.ToList())
                {
                    var temp = new IndexDesignationsListByAdminVM_Designations()
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
                var model = new IndexDesignationsListByAdminVM()
                {
                    _Designations = data,

                };
                #endregion "Paging"
               

                return View("DesignationsListByAdmin", model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion "Get methods"

        #region "Post_Methods"
        [HttpPost]
        public async Task<IActionResult> InsertDesignation(IndexDesignationsListVM obj)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if (obj.Designations != null)
                    {
                        var Designations = new InsertDesignation_Designations()
                        {
                            Name = obj.Designations.Name
                        };
                        var model = new InsertDesignation()
                        {
                            Designations = Designations
                        };
                        await Task.Run(() => _DesignationsServ.InsertDesignation(model));
                    }
                }
                
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("DesignationsListByAdmin");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDesignation(IndexDesignationsListVM obj)
        {
            try
            {
                if (obj.Designations != null)
                {
                    var Designations = new UpdateDesignation_Designations()
                    {
                        Id = obj.Designations.Id,
                        Name = obj.Designations.Name
                    };
                    var model = new UpdateDesignation()
                    {
                        Designations = Designations
                    };
                    await Task.Run(() => _DesignationsServ.UpdateDesignation(model));
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("DesignationsList");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDesignation(long DesignationId)
        {
            try
            {
                var model = new DeleteDesignation()
                {
                    DesignationId = DesignationId
                };
                await Task.Run(() => _DesignationsServ.DeleteDesignation(model));
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("DesignationsList");
        }
        #endregion "post method"
    }
}