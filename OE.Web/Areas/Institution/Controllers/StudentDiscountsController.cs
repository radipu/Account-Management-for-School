
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OE.Service;
using OE.Service.ServiceModels.StudentDiscountsServ;
using OE.Web.Areas.Institution.Models;
using OE.Web.Areas.Institution.Models.StudentDiscountsVM;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace OE.Web.Areas.Institution.Controllers
{
    [Area("Institution")]
    public class StudentDiscountsController : Controller
    {
        #region "Variables"
        private readonly IStudentDiscountsServ _StudentDiscountsServ;
        private readonly IFeeTypesServ _FeeTypesServ;
        private readonly IStudentsServ _studentsServ;        
        private readonly IClassesServ _classesServ;        
        #endregion "Variables"

        #region "Constructor"
        public StudentDiscountsController(
            IStudentDiscountsServ StudentDiscountsServ,            
            IClassesServ classesServ,           
            IStudentsServ studentsServ, IFeeTypesServ FeeTypesServ
        )
        {
            _StudentDiscountsServ = StudentDiscountsServ;
            _studentsServ = studentsServ;
            _FeeTypesServ = FeeTypesServ;           
            _classesServ = classesServ;          
        }
        #endregion "Constructor"

        #region "Get methods"
      
        public async Task<IActionResult> StudentDiscountsList(int pg = 1)
        {
            try
            {
                var StudentDiscountsList = Task.Run(() => _StudentDiscountsServ.getStudentDiscountsList());
                var result = await StudentDiscountsList;               
                ViewBag.ddlStudent = _studentsServ.dropdown_Students();               
                ViewBag.ddlClass = _classesServ.dropdown_Class();                
                var list = new List<IndexStudentDiscountsListVM_StudentDiscounts>();
                foreach (var item in result._StudentDiscounts.ToList())
                {
                    var temp = new IndexStudentDiscountsListVM_StudentDiscounts()
                    {
                        Id = item.Id,
                        StudentId = item.StudentId,                       
                        ClassId=item.ClassId,
                        ClassName=item.ClassName,                       
                        RegistrationNo = item.RegistrationNo,                       
                        StudentName = item.StudentName,
                        FeeTypeId = item.FeeTypeId,
                        FeeType = item.FeeType,
                        DiscountAmout = item.DiscountAmout
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
                var model = new IndexStudentDiscountsListVM()
                {
                    _StudentDiscounts = data
                };
                #endregion "Paging"
                
                return View("StudentDiscountsList", model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

       
        public async Task<IActionResult> StudentDiscountsListByAdmin(int pg = 1)
        {
            try
            {
                var StudentDiscountsList = Task.Run(() => _StudentDiscountsServ.getStudentDiscountsList());
                var result = await StudentDiscountsList;
                ViewBag.ddlStudent = _studentsServ.dropdown_Students();
                ViewBag.ddlClass = _classesServ.dropdown_Class();
                var list = new List<IndexStudentDiscountsListByAdminVM_StudentDiscounts>();
                foreach (var item in result._StudentDiscounts.ToList())
                {
                    var temp = new IndexStudentDiscountsListByAdminVM_StudentDiscounts()
                    {
                        Id = item.Id,
                        StudentId = item.StudentId,
                        ClassId = item.ClassId,
                        ClassName = item.ClassName,
                        RegistrationNo = item.RegistrationNo,
                        StudentName = item.StudentName,
                        FeeTypeId = item.FeeTypeId,
                        FeeType = item.FeeType,
                        DiscountAmout = item.DiscountAmout
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
                var model = new IndexStudentDiscountsListByAdminVM()
                {
                    _StudentDiscounts = data
                };
                #endregion "Paging"
               

                return View("StudentDiscountsListByAdmin", model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion "Get methods"

        #region "Post_Methods"
        [HttpPost]
        public async Task<IActionResult> InsertStudentDiscount(IndexStudentDiscountsListVM obj)
        {
            try
            {
                if (obj.StudentDiscounts != null)
                {
                    var StudentDiscounts = new InsertStudentDiscount_StudentDiscounts()
                    {
                        StudentId = obj.StudentDiscounts.StudentId,
                        RegistrationNo = obj.StudentDiscounts.RegistrationNo,
                        StudentName = obj.StudentDiscounts.StudentName,
                        FeeTypeId = obj.StudentDiscounts.FeeTypeId,
                        FeeType = obj.StudentDiscounts.FeeType,
                        DiscountAmout = obj.StudentDiscounts.DiscountAmout
                    };
                    var model = new InsertStudentDiscount()
                    {
                        StudentDiscounts = StudentDiscounts
                    };
                    await Task.Run(() => _StudentDiscountsServ.InsertStudentDiscount(model));
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("StudentDiscountsList");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateStudentDiscount(IndexStudentDiscountsListVM obj)
        {
            try
            {
                if (obj.StudentDiscounts != null)
                {
                    var StudentDiscounts = new UpdateStudentDiscount_StudentDiscounts()
                    {
                        Id = obj.StudentDiscounts.Id,
                        StudentId = obj.StudentDiscounts.StudentId,
                        RegistrationNo = obj.StudentDiscounts.RegistrationNo,
                        FeeTypeId = obj.StudentDiscounts.FeeTypeId,
                        DiscountAmout = obj.StudentDiscounts.DiscountAmout
                    };

                    var model = new UpdateStudentDiscount()
                    {
                        StudentDiscounts = StudentDiscounts
                    };
                    await Task.Run(() => _StudentDiscountsServ.UpdateStudentDiscount(model));
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("StudentDiscountsList");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteStudentDiscount(long StudentDiscountId)
        {
            try
            {
                var model = new DeleteStudentDiscount()
                {
                    StudentDiscountId = StudentDiscountId
                };
                await Task.Run(() => _StudentDiscountsServ.DeleteStudentDiscount(model));
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("StudentDiscountsList");
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
        public IActionResult PrintStudentDiscountsList()
        {
            ViewBag.OeErrorMessage = null;
            var model = new PrintIndexStudentDiscountsListVM();
            try
            {
                string footer = "--footer-center \"  Printed Date: " +
                      DateTime.Now.Date.ToString("dd/MM/yyyy") + " - " + "  Page: [page] to [toPage]\"" +
                      " --footer-line --footer-font-size \"10\" --footer-spacing 1 --footer-font-name \"Courier New\"";
                var result = _StudentDiscountsServ.PrintGetStudentDiscountsList();
                var list = new List<PrintIndexStudentDiscountsListVM_StudentDiscounts>();
                foreach (var item in result._StudentDiscounts.ToList())
                {
                    var temp = new PrintIndexStudentDiscountsListVM_StudentDiscounts()
                    {
                        Id = item.Id,
                        StudentId = item.StudentId,
                        StudentName = item.StudentName,
                        FeeTypeId = item.FeeTypeId,
                        FeeType = item.FeeType,
                        DiscountAmout = item.DiscountAmout
                    };
                    list.Add(temp);
                };

                //[NOTE: map institutions]
                var currentInstitution = new PrintIndexStudentDiscountsListVM_Institutions()
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
                model = new PrintIndexStudentDiscountsListVM()
                {
                    _StudentDiscounts = list,
                    Institution = currentInstitution
                };
                return new ViewAsPdf("PrintStudentDiscountsList", model)
                {
                    CustomSwitches = footer
                };
            }
            catch (Exception ex)
            {
                ViewBag.OeErrorMessage = "ERROR101:ExamTypes/PrintExamTypes -" + ex.Message;
                return View("PrintStudentDiscountsList");
            }
        }
        #endregion "Report Methods"

       
    }
}

