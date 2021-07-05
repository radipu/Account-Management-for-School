
using Microsoft.AspNetCore.Mvc;
using OE.Service;
using OE.Service.ServiceModels.SalaryIncrementsServ;
using OE.Web.Areas.Institution.Models;
using OE.Web.Areas.Institution.Models.SalaryIncrementsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OE.Web.Areas.Institution.Controllers
{
    [Area("Institution")]
    public class SalaryIncrementsController : Controller
    {
        #region "Variables"
        private readonly ISalaryIncrementsServ _SalaryIncrementsServ;
        private readonly IStaffsServ _StaffsServ;
        #endregion "Variables"

        #region "Constructor"
        public SalaryIncrementsController(
            ISalaryIncrementsServ SalaryIncrementsServ, IStaffsServ StaffsServ
        )
        {
            _SalaryIncrementsServ = SalaryIncrementsServ;
            _StaffsServ = StaffsServ;

        }
        #endregion "Constructor"

        #region "Get methods"
        public async Task<IActionResult> SalaryIncrementsList(int pg = 1)
        {
            try
            {
                var SalaryIncrementsList = Task.Run(() => _SalaryIncrementsServ.getSalaryIncrementsList());
                var result = await SalaryIncrementsList;
                ViewBag.ddlStaffs = _StaffsServ.dropdown_Staffs();
                //var totalAmount = _ExpensesServ.allExpenses();
                var list = new List<IndexSalaryIncrementsListVM_SalaryIncrements>();
                foreach (var item in result._SalaryIncrements.ToList())
                {
                    var temp = new IndexSalaryIncrementsListVM_SalaryIncrements()
                    {
                        Id = item.Id,
                        StaffId = item.StaffId,
                        DesigignationId = item.DesigignationId,
                        PayScalesId = item.PayScalesId,
                        Date = item.Date,
                        Amount = item.Amount
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
                var model = new IndexSalaryIncrementsListVM()
                {
                    _SalaryIncrements = data
                };
                #endregion "Paging"
                
                return View("SalaryIncrementsList", model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion "Get methods"

        #region "Post_Methods"
        [HttpPost]
        public async Task<IActionResult> InsertSalaryIncrement(IndexSalaryIncrementsListVM obj)
        {
            try
            {
                if (obj.SalaryIncrements != null)
                {                    
                    var SalaryIncrements = new InsertSalaryIncrement_SalaryIncrements()                   
                    {

                        StaffId = obj.SalaryIncrements.StaffId,
                        DesigignationId = obj.SalaryIncrements.DesigignationId,
                        PayScalesId = obj.SalaryIncrements.PayScalesId,
                        Date = obj.SalaryIncrements.Date,
                        Amount = obj.SalaryIncrements.Amount

                    };

                    var model = new InsertSalaryIncrement()
                    {
                        SalaryIncrements = SalaryIncrements
                    };

                    await Task.Run(() => _SalaryIncrementsServ.InsertSalaryIncrement(model));

                }

            }
            catch (Exception)
            {

                return BadRequest();
            }
            return RedirectToAction("SalaryIncrementsList");

        }

        [HttpPost]
        public async Task<IActionResult> UpdateSalaryIncrement(IndexSalaryIncrementsListVM obj)
        {

            try
            {
                if (obj.SalaryIncrements != null)
                {                   
                     var SalaryIncrements = new UpdateSalaryIncrement_SalaryIncrements()                     
                     {
                        Id = obj.SalaryIncrements.Id,
                        StaffId = obj.SalaryIncrements.StaffId,
                        DesigignationId = obj.SalaryIncrements.DesigignationId,
                        PayScalesId = obj.SalaryIncrements.PayScalesId,
                        Date = obj.SalaryIncrements.Date,
                        Amount = obj.SalaryIncrements.Amount
                    };

                    var model = new UpdateSalaryIncrement()
                    {
                        SalaryIncrements = SalaryIncrements
                    };

                    await Task.Run(() => _SalaryIncrementsServ.UpdateSalaryIncrement(model));
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return RedirectToAction("SalaryIncrementsList");

        }

        [HttpPost]
        public async Task<IActionResult> DeleteSalaryIncrement(long SalaryIncrementId)
        {
            try
            {

                var model = new DeleteSalaryIncrement()
                {
                    SalaryIncrementId = SalaryIncrementId

                };
                await Task.Run(() => _SalaryIncrementsServ.DeleteSalaryIncrement(model));

            }
            catch (Exception)
            {

                return BadRequest();
            }
            return RedirectToAction("SalaryIncrementsList");
        }
        #endregion "post method"
    }
}
