
using Microsoft.AspNetCore.Mvc;
using OE.Service;
using OE.Service.ServiceModels.PayScalesServ;
using OE.Web.Areas.Institution.Models;
using OE.Web.Areas.Institution.Models.PayScalesVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OE.Web.Areas.Institution.Controllers
{
    [Area("Institution")]
    public class PayScalesController : Controller
    {
        #region "Variables"
        private readonly IPayScalesServ _PayScalesServ;   
        private readonly IDesignationsServ _DesignationsServ;        
        private readonly IStaffsServ _StaffsServ;       
        #endregion "Variables"

        #region "Constructor"
        public PayScalesController(
            IPayScalesServ PayScalesServ,           
            IStaffsServ StaffsServ,            
            IDesignationsServ DesignationsServ
        )
        {
            _PayScalesServ = PayScalesServ;          
            _DesignationsServ = DesignationsServ;           
            _StaffsServ = StaffsServ;            
        }
        #endregion "Constructor"

        #region "Get methods"
        public async Task<IActionResult> PayScalesList(int pg = 1)
        {
            try
            {
                var PayScalesList = Task.Run(() => _PayScalesServ.getPayScalesList());
                var result = await PayScalesList;               
                ViewBag.ddlStaff = _StaffsServ.dropdown_Staffs();               
                ViewBag.ddlDesignation = _DesignationsServ.dropdown_Designations();
                var list = new List<IndexPayScalesListVM_PayScales>();
                foreach (var item in result._PayScales.ToList())
                {
                    var temp = new IndexPayScalesListVM_PayScales()
                    {
                        Id = item.Id,                        
                        StaffId = item.StaffId,
                        StaffName=item.StaffName,
                        DesignationName=item.DesignationName,
                        BasicSalary = item.BasicSalary,                        
                        SalaryYear = item.SalaryYear,                       
                        BasicSalaryTermNo = item.BasicSalaryTermNo,
                        BonusSalary = item.BonusSalary,
                        BonusSalaryTermNo = item.BonusSalaryTermNo                       
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
                var model = new IndexPayScalesListVM()
                {
                    _PayScales = data,
                };
                #endregion "Paging"
               
                return View("PayScalesList", model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }       
        public async Task<IActionResult> PayScalesListByAdmin(int pg = 1)
        {
            try
            {
                var PayScalesList = Task.Run(() => _PayScalesServ.getPayScalesList());
                var result = await PayScalesList;
                ViewBag.ddlDesignation = _DesignationsServ.dropdown_Designations();
                var list = new List<IndexPayScalesListByAdminVM_PayScales>();
                foreach (var item in result._PayScales.ToList())
                {
                    var temp = new IndexPayScalesListByAdminVM_PayScales()
                    {
                        Id = item.Id,                        
                        StaffId = item.StaffId,
                        BasicSalary = item.BasicSalary,                        
                        SalaryYear = item.SalaryYear,                      
                        BasicSalaryTermNo = item.BasicSalaryTermNo,
                        BonusSalary = item.BonusSalary,
                        BonusSalaryTermNo = item.BonusSalaryTermNo                       
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
                var model = new IndexPayScalesListByAdminVM()
                {
                    _PayScales = data,
                };
                #endregion "Paging"
               

                return View("PayScalesListByAdmin", model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion "Get methods"
        
        #region "Post_Methods"
        [HttpPost]
        public async Task<IActionResult> InsertPayScale(IndexPayScalesListVM obj)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if (obj.PayScales != null)
                    {
                        var PayScales = new InsertPayScale_PayScales()
                        {
                            StaffId = obj.PayScales.StaffId,
                            BasicSalary = obj.PayScales.BasicSalary,
                            Year = obj.PayScales.Year,
                            BasicSalaryTermNo = obj.PayScales.BasicSalaryTermNo,
                            BonusSalary = obj.PayScales.BonusSalary,
                            BonusSalaryTermNo = obj.PayScales.BonusSalaryTermNo
                        };
                        var model = new InsertPayScale()
                        {
                            PayScales = PayScales
                        };
                        await Task.Run(() => _PayScalesServ.InsertPayScale(model));
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("PayScalesList");

        }
        [HttpPost]
        public async Task<IActionResult> UpdatePayScale(IndexPayScalesListVM obj)
        {
            try
            {
                if (obj.PayScales != null)
                {
                    var PayScales = new UpdatePayScale_PayScales()
                    {
                        Id = obj.PayScales.Id,
                        StaffId = obj.PayScales.StaffId,
                        BasicSalary = obj.PayScales.BasicSalary,
                        Year = obj.PayScales.Year,
                        BasicSalaryTermNo = obj.PayScales.BasicSalaryTermNo,
                        BonusSalary = obj.PayScales.BonusSalary,
                        BonusSalaryTermNo = obj.PayScales.BonusSalaryTermNo
                    };
                    var model = new UpdatePayScale()
                    {
                        PayScales = PayScales
                    };
                    await Task.Run(() => _PayScalesServ.UpdatePayScale(model));
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("PayScalesList");

        }
        [HttpPost]
        public async Task<IActionResult> DeletePayScale(long PayScalesId)
        {
            try
            {
                var model = new DeletePayScale()
                {
                    PayScalesId = PayScalesId
                };
                await Task.Run(() => _PayScalesServ.DeletePayScale(model));
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("PayScalesList");
        }
        #endregion "post method"       
    }
}
