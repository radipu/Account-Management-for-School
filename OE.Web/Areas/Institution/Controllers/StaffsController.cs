
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OE.Service;
using OE.Service.ServiceModels.StaffsServ;
using OE.Web.Areas.Institution.Models;
using OE.Web.Areas.Institution.Models.StaffsVM;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OE.Web.Areas.Institution.Controllers
{
    [Area("Institution")]
    public class StaffsController : Controller
    {
        #region "Variables"
        private readonly IStaffsServ _StaffsServ;
        private readonly IDesignationsServ _DesignationsServ;
        IWebHostEnvironment _he;
        private readonly IGendersServ _GendersServ;
        #endregion "Variables"

        #region "Constructor"
        public StaffsController(
             IStaffsServ StaffsServ,
             IWebHostEnvironment he,
             IGendersServ GendersServ,
             IDesignationsServ DesignationsServ
        )
        {
            _StaffsServ = StaffsServ;
            _he = he;
            _GendersServ = GendersServ;
            _DesignationsServ = DesignationsServ;
        }
        #endregion "Constructor"

        #region "Get Methods"       
        public async Task<IActionResult> StaffsList(int pg = 1)
        {
            try
            {
                ViewBag.ddlGenders = _GendersServ.Dropdown_Genders();
                var StaffsList = Task.Run(() => _StaffsServ.getStaffsList(new Service.ServiceModels.StaffsServ.getStaffsList() { WebRootPath = _he.WebRootPath }));
                var result = await StaffsList;
                ViewBag.ddlDesignations = _DesignationsServ.dropdown_Designations();
                var list = new List<IndexStaffsListVM_Staffs>();
                foreach (var item in result._Staffs.ToList())
                {
                    var temp = new IndexStaffsListVM_Staffs()
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
                        Education = item.Education,
                        Address = item.Address
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
                var model = new IndexStaffsListVM()
                {
                    _Staffs = data
                };
                #endregion "Paging"
                
                return View("StaffsList", model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> StaffsListByAdmin(int pg = 1)
        {
            try
            {
                ViewBag.ddlGenders = _GendersServ.Dropdown_Genders();
                var StaffsList = Task.Run(() => _StaffsServ.getStaffsList(new Service.ServiceModels.StaffsServ.getStaffsList() { WebRootPath = _he.WebRootPath }));
                var result = await StaffsList;
                ViewBag.ddlDesignations = _DesignationsServ.dropdown_Designations();
                var list = new List<IndexStaffsListByAdminVM_Staffs>();
                foreach (var item in result._Staffs.ToList())
                {
                    var temp = new IndexStaffsListByAdminVM_Staffs()
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
                        Education = item.Education,
                        Address = item.Address
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
                var model = new IndexStaffsListByAdminVM()
                {
                    _Staffs = data
                };
                #endregion "Paging"
                
                return View("StaffsListByAdmin", model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        
        public async Task<IActionResult> StaffsListByAccountant(Int64 StaffId, int pg = 1)
        {
            try
            {
                var result = new StaffDetails()
                {
                    StaffId = StaffId
                };
                var staffList = await Task.Run(() => _StaffsServ.StaffDetails(result));
                ViewBag.ddlDesignations = _DesignationsServ.dropdown_Designations();
                var temp = new StaffDetailsVM_Staffs()
                {
                    Id = staffList.Staffs.Id,
                    DesignationId = staffList.Staffs.DesignationId,
                    FirstName = staffList.Staffs.FirstName,
                    LastName = staffList.Staffs.LastName,
                    Name = staffList.Staffs.Name,
                    Designation = staffList.Staffs.Designation,
                    Cell = staffList.Staffs.Cell,
                    Email = staffList.Staffs.Email,
                    Education = staffList.Staffs.Education,
                    Address = staffList.Staffs.Address
                };


                var model = new StaffDetailsVM()
                {
                    Staffs = temp
                };
                return View("StaffsListByAccountant", model);
            }
            catch
            {
                return BadRequest();
            }
        }
       

      
        public async Task<IActionResult> StaffsaddDetails()
        {
            try
            {
                ViewBag.ddlGenders = _GendersServ.Dropdown_Genders();
                var StaffsList = Task.Run(() => _StaffsServ.getStaffsList(new Service.ServiceModels.StaffsServ.getStaffsList() { WebRootPath = _he.WebRootPath }));

                var result = await StaffsList;
                ViewBag.ddlDesignations = _DesignationsServ.dropdown_Designations();
                var list = new List<IndexStaffsListByAdminVM_Staffs>();
                foreach (var item in result._Staffs.ToList())
                {
                    var temp = new IndexStaffsListByAdminVM_Staffs()
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
                        Education = item.Education,
                        Address = item.Address
                    };
                    list.Add(temp);
                };

                var model = new IndexStaffsListByAdminVM()
                {
                    _Staffs = list,

                };
                return View("StaffsaddDetails", model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        public async Task<IActionResult> StaffDetails(Int64 StaffId)
        {
            try
            {
                var result = new StaffDetails()
                {
                    StaffId = StaffId

                };
                var staffList = await Task.Run(() => _StaffsServ.StaffDetails(result));
                ViewBag.ddlDesignations = _DesignationsServ.dropdown_Designations();
                var temp = new StaffDetailsVM_Staffs()
                {
                    Id = staffList.Staffs.Id,
                    DesignationId = staffList.Staffs.DesignationId,
                    FirstName = staffList.Staffs.FirstName,
                    LastName = staffList.Staffs.LastName,
                    Name = staffList.Staffs.Name,
                    Designation = staffList.Staffs.Designation,
                    Cell = staffList.Staffs.Cell,
                    Email = staffList.Staffs.Email,
                    Education = staffList.Staffs.Education,
                    Address = staffList.Staffs.Address
                };
                var model = new StaffDetailsVM()
                {
                    Staffs = temp
                };
                return View("StaffDetails", model);
            }

            catch
            {
                return BadRequest();
            }


        }
       
        #endregion "Get Methods"
        
        #region "Post_Methods"
        [HttpPost]
        //public async Task<IActionResult>InsertStaff(IndexStaffsListVM obj)
        public JsonResult InsertStaff(IndexStaffsListVM obj)
        {
            var result = (dynamic)null;            //for jsonResult
            string message = (dynamic)null;
            try
            {
                if(ModelState.IsValid)
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
                            Education = obj.Staffs.Education,
                            Address = obj.Staffs.Address

                        };

                        var model = new InsertStaff()
                        {
                            Staffs = Staffs,
                            WebRootPath = _he.WebRootPath,
                        };

                        // await Task.Run(() => _StaffsServ.InsertStaff(model));
                        message = _StaffsServ.InsertStaff(model);
                        result = Json(new { success = true, Message = message });

                    }
                }
            }
            catch (Exception ex)
            {

                // return BadRequest();
                result = Json(new { success = false, Message = "ERROR101:Students/InsertStudent - " + ex.Message });
            }
            //return RedirectToAction("StaffsListByAdmin");
            //  return RedirectToRoute("StaffsListByAdmin");
            // return View ("StaffsListByAdmin");
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStaff(IndexStaffsListVM obj)
        {
            try
            {
                if (obj.Staffs != null)
                {
                    var Staffs = new UpdateStaff_Staffs()
                    {
                        Id = obj.Staffs.Id,
                        GenderId = obj.Staffs.GenderId,
                        IP300X200 = obj.Staffs.IP300X200,
                        fleImage = obj.Staffs.fleImage,
                        DesignationId = obj.Staffs.DesignationId,
                        FirstName = obj.Staffs.FirstName,
                        LastName = obj.Staffs.LastName,
                        Cell = obj.Staffs.Cell,
                        Email = obj.Staffs.Email,
                        Education = obj.Staffs.Education,
                        Address = obj.Staffs.Address
                    };

                    var model = new UpdateStaff()
                    {
                        WebRootPath = _he.WebRootPath,
                        Staffs = Staffs
                    };

                    await Task.Run(() => _StaffsServ.UpdateStaff(model));
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return RedirectToAction("StaffsList");

        }

        [HttpPost]
        public async Task<IActionResult> DeleteStaff(long StaffId)
        {
            try
            {

                var model = new DeleteStaff()
                {
                    WebRootPath = _he.WebRootPath,
                    StaffId = StaffId

                };
                await Task.Run(() => _StaffsServ.DeleteStaff(model));

            }
            catch (Exception)
            {

                return BadRequest();
            }
            return RedirectToAction("StaffsList");
        }
        #endregion "post method"

        #region "Report Methods"
        public IActionResult PrintStaffsList()
        {
            ViewBag.OeErrorMessage = null;
            var model = new PrintIndexStaffsListVM();
            try
            {

                string footer = "--footer-center \"  Printed Date: " +
                      DateTime.Now.Date.ToString("dd/MM/yyyy") + " - " + "  Page: [page] to [toPage]\"" +
                      " --footer-line --footer-font-size \"10\" --footer-spacing 1 --footer-font-name \"Courier New\"";


                var result = _StaffsServ.PrintGetStaffsList();

                var list = new List<PrintIndexStaffsListVM_Staffs>();
                foreach (var item in result._Staffs.ToList())
                {
                    var temp = new PrintIndexStaffsListVM_Staffs()
                    {
                        Id = item.Id,
                        DesignationId = item.DesignationId,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Name = item.Name,
                        Designation = item.Designation,
                        Cell = item.Cell,
                        Email = item.Email,
                        Education = item.Education,
                        Address = item.Address
                    };
                    list.Add(temp);
                };


                //[NOTE: map institutions]
                var currentInstitution = new PrintIndexStaffsListVM_Institutions()
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


                model = new PrintIndexStaffsListVM()
                {
                    _Staffs = list,
                    Institution = currentInstitution
                };

                return new ViewAsPdf("PrintStaffsList", model)
                {

                    CustomSwitches = footer

                };

            }
            catch (Exception ex)
            {
                ViewBag.OeErrorMessage = "ERROR101:ExamTypes/PrintExamTypes -" + ex.Message;
                return View("PrintStaffsList");
            }
        }
        #endregion "Report Methods"
        
    }
}
