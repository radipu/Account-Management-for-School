
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OE.Service;
using OE.Service.ServiceModels.SalarysServ;

using OE.Service.ServiceModels.StaffsServ;
using OE.Web.Areas.Institution.Models;
using OE.Web.Areas.Institution.Models.SalariesVM;
using OE.Web.Areas.Institution.Models.StaffsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OE.Web.Areas.Institution.Controllers
{
    [Area("Institution")]    
    public class SalariesController : Controller
    {
        #region "Variables"
        private readonly ISalariesServ _SalariesServ;
        private readonly IStaffsServ _StaffsServ;       
        IWebHostEnvironment _he;
        private readonly IGendersServ _GendersServ;
        private readonly IDesignationsServ _DesignationsServ;       
        #endregion "Variables"

        #region "Constructor"
        public SalariesController(
            ISalariesServ SalariesServ,           
            IWebHostEnvironment he,
             IGendersServ GendersServ,
             IDesignationsServ DesignationsServ,           
            IStaffsServ StaffsServ
        )
        {
            _SalariesServ = SalariesServ;
            _StaffsServ = StaffsServ;            
            _he = he;
            _GendersServ = GendersServ;
            _DesignationsServ = DesignationsServ;            
        }
        #endregion "Constructor"

        #region "Get methods"
        public async Task<IActionResult> SalariesList(long staffId, long salaryYear)
        {
            try
            {                
                var SalariesList = Task.Run(() => _SalariesServ.getSalariesList(staffId, salaryYear));
               var result = await SalariesList;               
                ViewBag.ddlTermNo = _SalariesServ.dropdown_TermNo(staffId, salaryYear);                         
                ViewBag.ddlBonusTermNo = _SalariesServ.dropdown_BonusTermNo(staffId,salaryYear);               
                ViewBag.ddlStaffs = _StaffsServ.dropdown_Staffs();               
                var getStaffs = new IndexSalariesListVM_Staffs()
                {
                    Id = result.Staffs.Id,
                    DesignationId = result.Staffs.DesignationId,
                    FirstName = result.Staffs.FirstName,
                    LastName = result.Staffs.LastName,
                    Name = result.Staffs.Name,
                    Designation = result.Staffs.Designation,
                    Cell = result.Staffs.Cell,
                    Email = result.Staffs.Email,
                    Address = result.Staffs.Address
                };                
                var list = new List<IndexSalariesListVM_Salaries>();
                foreach (var item in result._Salaries.ToList())
                {
                    var temp = new IndexSalariesListVM_Salaries()
                    {
                        Id = item.Id,
                        StaffId = item.StaffId,
                        StaffName = item.StaffName,                       
                        TermNo = item.TermNo,
                        SalaryTypeId = item.SalaryTypeId,                       
                        Date = item.Date,
                        Amount = item.Amount,
                        Remark = item.Remark
                    };
                    list.Add(temp);
                };

                var model = new IndexSalariesListVM()
                {                   
                    Amount = result.Amount,
                    BonusAmount = result.BonusAmount,                    
                    Staffs = getStaffs,                    
                    _Salaries = list,
                };
                
                
                return View("StaffDetailsWithSalary", model);                
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }        
        public async Task<IActionResult> SalariesListByAdmin(long staffId, long salaryYear)
        {
            try
            {                  
                var SalariesList = Task.Run(() => _SalariesServ.getSalariesList(staffId, salaryYear));               
                var result = await SalariesList;
                ViewBag.ddlStaffs = _StaffsServ.dropdown_Staffs();
                var list = new List<IndexSalariesListVM_Salaries>();
                foreach (var item in result._Salaries.ToList())
                {
                    var temp = new IndexSalariesListVM_Salaries()
                    {
                        Id = item.Id,
                        StaffId = item.StaffId,
                        StaffName = item.StaffName,
                        Date = item.Date,
                        Amount = item.Amount,
                        Remark = item.Remark
                    };
                    list.Add(temp);
                };

                var model = new IndexSalariesListVM()
                {
                    _Salaries = list
                };
                
                
                return View("SalariesListByAdmin", model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }      
        public async Task<IActionResult> StaffList()
        {
            try
            {
                ViewBag.ddlGenders = _GendersServ.Dropdown_Genders();
                var StaffsList = Task.Run(() => _SalariesServ.getStaffList(_he.WebRootPath));
                var result = await StaffsList;
                ViewBag.ddlDesignations = _DesignationsServ.dropdown_Designations();
                var list = new List<IndexStaffListVM_Staffs>();
                foreach (var item in result._Staffs.ToList())
                {
                    var temp = new IndexStaffListVM_Staffs()
                    {
                        Id = item.Id,
                        GenderId = item.GenderId,
                        SalaryYear = item.SalaryYear,
                        IP300X200 = item.IP300X200,
                        DesignationId = item.DesignationId,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Name = item.Name,
                        Designation = item.Designation,                       
                        YearlyTermNo = item.YearlyTermNo,                      
                        NetSalary = item.NetSalary,
                        Cell = item.Cell,
                        Email = item.Email,
                        Address = item.Address
                    };
                    list.Add(temp);
                };

                var model = new IndexStaffListVM()
                {
                    _Staffs = list
                };
                
                
                return View("StaffList", model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> ProduceSalary()
        {
            try
            {
                ViewBag.ddlGenders = _GendersServ.Dropdown_Genders();
                var StaffsList = Task.Run(() => _StaffsServ.getStaffsList(new Service.ServiceModels.StaffsServ.getStaffsList() { WebRootPath = _he.WebRootPath }));
                var result = await StaffsList;
                ViewBag.ddlDesignations = _DesignationsServ.dropdown_Designations();
                var list = new List<IndexStaffListVM_Staffs>();
                foreach (var item in result._Staffs.ToList())
                {
                    var temp = new IndexStaffListVM_Staffs()
                    {
                        Id = item.Id,
                        GenderId = item.GenderId,
                        GenderName = item.GenderName,
                        IP300X200 = item.IP300X200,
                        DesignationId = item.DesignationId,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Name = item.Name,
                        Designation = item.Designation,
                        Cell = item.Cell,
                        Email = item.Email,
                        Address = item.Address
                    };
                    list.Add(temp);
                };

                
                var model = new IndexStaffListVM()
                {
                    _Staffs = list
                };
                
                
                return View("StaffList", model);

            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        #endregion "Get methods"
       
        #region "Post_Methods"       
        [HttpPost]
        public async Task<IActionResult> InsertStaff(IndexStaffsListVM obj)
        {
            try
            {
                if (obj.Staffs != null)
                {
                    var Staffs = new InsertStaff_Staffs()
                    {
                        GenderId = obj.Staffs.GenderId,
                        IP300X200 = obj.Staffs.IP300X200,
                        fleImage = obj.Staffs.fleImage,
                        DesignationId = obj.Staffs.DesignationId,
                        FirstName = obj.Staffs.FirstName,
                        LastName = obj.Staffs.LastName,
                        Cell = obj.Staffs.Cell,
                        Email = obj.Staffs.Email,
                        Address = obj.Staffs.Address
                    };
                    var model = new InsertStaff()
                    {
                        Staffs = Staffs,
                        WebRootPath = _he.WebRootPath,
                    };
                    await Task.Run(() => _StaffsServ.InsertStaff(model));
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("StaffList");
        }
        public IActionResult InsertFormPage()
        {
            ViewBag.ddlStaffs = _StaffsServ.dropdown_Staffs();
            return View();
        }
        [HttpPost]
        public JsonResult InsertSalary(IndexSalariesListVM obj)
        {
            var result = (dynamic)null;
            string message = (dynamic)null;
            try
            {
                if (obj.Salaries != null)
                {
                    var Salaries = new InsertSalary_Salaries()
                    {
                        StaffId = obj.Salaries.StaffId,
                        Date = obj.Salaries.Date,
                        TermNo = obj.Salaries.TermNo,
                        SalaryTypeId = obj.Salaries.SalaryTypeId,
                        Amount = obj.Salaries.Amount,
                        Remark = obj.Salaries.Remark
                    };
                    var model = new InsertSalary()
                    {
                        Salaries = Salaries
                    };
                    message = _SalariesServ.InsertSalary(model);
                    result = Json(new { success = true, Message = message });
                }
            }
            catch (Exception ex)
            {
                result = Json(new { success = false, Message = "ERROR101:Salaries/InsertSalary - " + ex.Message });
            }
            return result;
        }
        [HttpPost]
        public JsonResult UpdateSalary(IndexSalariesListVM obj)
        {
            var result = (dynamic)null;
            string message = (dynamic)null;
            try
            {
                if (obj.Salaries != null)
                {
                    var Salaries = new UpdateSalary_Salaries()
                    {
                        Id = obj.Salaries.Id,
                        TermNo = obj.Salaries.TermNo,
                        SalaryTypeId = obj.Salaries.SalaryTypeId,
                        StaffId = obj.Salaries.StaffId,
                        Date = obj.Salaries.Date,
                        Amount = obj.Salaries.Amount,
                        Remark = obj.Salaries.Remark
                    };
                    var model = new UpdateSalary()
                    {
                        Salaries = Salaries
                    };
                    message = _SalariesServ.UpdateSalary(model);
                    result = Json(new { success = true, Message = message });
                }
            }
            catch (Exception ex)
            {
                result = Json(new { success = false, Message = "ERROR101:Salaries/UpdateSalary - " + ex.Message });
            }
            return result;
        }
        [HttpPost]
        public JsonResult DeleteSalary(long SalaryId)
        {
            var result = (dynamic)null;
            string message = (dynamic)null;
            try
            {
                var model = new DeleteSalary()
                {
                    SalaryId = SalaryId
                };
                message = _SalariesServ.DeleteSalary(model);
                result = Json(new { success = true, Message = message });
            }
            catch (Exception ex)
            {
                result = Json(new { success = false, Message = "ERROR101:Salaries/DeleteSalary - " + ex.Message });
            }
            return result;
        }
        #endregion "post method"        
    }

}
