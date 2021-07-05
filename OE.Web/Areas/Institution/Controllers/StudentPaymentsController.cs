
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OE.Service;
using OE.Service.ServiceModels.StudentDiscountsServ;
using OE.Service.ServiceModels.StudentPaymentsServ;
using OE.Web.Areas.Institution.Models.StudentPaymentsVM;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http; //[NOTE: for session]
using Microsoft.AspNetCore.Hosting;
namespace OE.Web.Areas.Institution.Controllers
{
    [Area("Institution")]
    public class StudentPaymentsController : Controller
    {
        #region "Variables"
        private readonly IUsersServ _oeUsersServ;
        private readonly IStudentPaymentsServ _StudentPaymentsServ;
        private readonly IStudentsServ _studentsServ;
        private readonly IFeeTypesServ _FeeTypesServ;
        private readonly IFeeStructuresServ _FeeStructuresServ;
        private readonly IStudentDiscountsServ _StudentDiscountsServ;
        private readonly IClassesServ _classesServ;
        private readonly IGendersServ _GendersServ;
        private readonly IWebHostEnvironment he;
        #endregion "Variables"

        #region "Constructor"
        public StudentPaymentsController(
             IUsersServ oeUsersServ,
            IStudentPaymentsServ StudentPaymentsServ,
            IClassesServ classesServ,
            IGendersServ GendersServ,
            IStudentDiscountsServ StudentDiscountsServ,
            IFeeTypesServ FeeTypesServ,
            IFeeStructuresServ FeeStructuresServ,
            IStudentsServ studentsServ,
             IWebHostEnvironment he
        )
        {
            _oeUsersServ = oeUsersServ;
            _StudentPaymentsServ = StudentPaymentsServ;
            _StudentDiscountsServ = StudentDiscountsServ;
            _FeeTypesServ = FeeTypesServ;
            _FeeStructuresServ = FeeStructuresServ;
            _studentsServ = studentsServ;
            _classesServ = classesServ;
            _GendersServ = GendersServ;
            this.he = he;
        }
        #endregion "Constructor"

        #region "Get methods"        
        public async Task<IActionResult> StudentPaymentsList()
        {
            try
            {
                var StudentPaymentsList = Task.Run(() => _StudentPaymentsServ.getStudentPaymentsList());
                var result = await StudentPaymentsList;
                ViewBag.ddlStudents = _studentsServ.dropdown_Students();
                var list = new List<IndexStudentPaymentsListVM_StudentPayments>();
                foreach (var item in result._StudentPayments.ToList())
                {
                    var temp = new IndexStudentPaymentsListVM_StudentPayments()
                    {
                        Id = item.Id,
                        PaymentDate = item.PaymentDate,
                        StudentId = item.StudentId,
                        ClassId = item.ClassId,
                        FeeYearDate = item.FeeYearDate,
                        StudentName = item.StudentName,
                        FeeTypeId = item.FeeTypeId,
                        FeeType = item.FeeType,
                        Amount = item.Amount,
                        Fine = item.Fine,
                        PaidAmount = item.PaidAmount,
                        Remarks = item.Remarks
                    };
                    list.Add(temp);
                };
                var model = new IndexStudentPaymentsListVM()
                {
                    _StudentPayments = list
                };
                return View("StudentPaymentsList", model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> StudentPaymentsListByAdmin()
        {
            try
            {
                var StudentPaymentsList = Task.Run(() => _StudentPaymentsServ.getStudentPaymentsList());
                var result = await StudentPaymentsList;
                ViewBag.ddlStudents = _studentsServ.dropdown_Students();
                var list = new List<IndexStudentPaymentsListVM_StudentPayments>();
                foreach (var item in result._StudentPayments.ToList())
                {
                    var temp = new IndexStudentPaymentsListVM_StudentPayments()
                    {
                        Id = item.Id,
                        ClassId = item.ClassId,
                        FeeYearDate = item.FeeYearDate,
                        PaymentDate = item.PaymentDate,
                        StudentId = item.StudentId,
                        StudentName = item.StudentName,
                        FeeTypeId = item.FeeTypeId,
                        FeeType = item.FeeType,
                        Amount = item.Amount,
                        Fine = item.Fine,
                        PaidAmount = item.PaidAmount,
                        Remarks = item.Remarks
                    };
                    list.Add(temp);
                };
                var model = new IndexStudentPaymentsListVM()
                {
                    _StudentPayments = list
                };
                return View("StudentPaymentsListByAdmin", model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> SearchStudentList(string RegistrationId)
        {
            try
            {
                if (String.IsNullOrEmpty(RegistrationId))
                {
                    var model = new IndexSearchStudentListVM()
                    {
                        //Students = null,
                        RegistrationId = null
                    };
                    return View("SearchStudentList", model);
                }
                else
                {
                    var result = new SearchStudentList()
                    {
                        RegistrationId = RegistrationId
                    };
                    var studentList = await Task.Run(() => _StudentPaymentsServ.SearchStudentList(result));
                    ViewBag.ddlClasses = _classesServ.dropdown_Class();
                    ViewBag.ddlGenders = _GendersServ.Dropdown_Genders();
                    if (studentList.Students != null)
                    {
                        var temp = new IndexSearchStudentListVM_Students()
                        {
                            Id = studentList.Students.Id,
                            ClassId = studentList.Students.ClassId,
                            RegistrationNo = studentList.Students.RegistrationNo,
                            ClassName = studentList.Students.ClassName,
                            GenderId = studentList.Students.GenderId,
                            GenderName = studentList.Students.GenderName,
                            FirstName = studentList.Students.FirstName,
                            LastName = studentList.Students.LastName,
                            StudentName = studentList.Students.StudentName,
                            IP300X200 = studentList.Students.IP300X200,
                            AdmittedYear = studentList.Students.AdmittedYear,
                            PresentAddress = studentList.Students.PresentAddress,
                            PermanentAddress = studentList.Students.PermanentAddress,
                            DOB = studentList.Students.DOB,
                            IsActive = studentList.Students.IsActive,
                            AddedBy = studentList.Students.AddedBy = 0,
                            AddedDate = DateTime.Now,
                            ModifiedBy = 0,
                            ModifiedDate = DateTime.Now,
                            DataType = null
                        };
                        var model = new IndexSearchStudentListVM()
                        {
                            Students = temp,
                            RegistrationId = RegistrationId,
                        };
                        return View("SearchStudentList", model);
                    }
                    else
                    {
                        var model = new IndexSearchStudentListVM()
                        {
                            Students = null,
                            RegistrationId = RegistrationId,
                        };
                        return View("SearchStudentList", model);
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> SearchPaymentDetailById(Int64 StudentId, string RegistrationId)
        {
            try
            {
                var result = new SearchPaymentDetailById()
                {
                    StudentId = StudentId,
                    RegistrationId = RegistrationId
                };
                var searchPaymentById = await Task.Run(() => _StudentPaymentsServ.SearchPaymentDetailById(result));
                var list = new List<IndexPaymentDetailByIdVM_StudentPayments>();
                ViewBag.ddlClasses = _classesServ.dropdown_Class();
                ViewBag.ddlGenders = _GendersServ.Dropdown_Genders();
                if (searchPaymentById._StudentPayments == null)
                {
                    ViewBag.Message = "Need to insert all pre required items- Such as: Fee Types, Fee Structure";
                    var model = new IndexPaymentDetailByIdVM()
                    {
                        ClassId = searchPaymentById.ClassId,
                        _StudentPayments = null,
                        StudentId = StudentId,
                        RegistrationId = RegistrationId,
                        StudentSearchName = searchPaymentById.StudentSearchName
                    };
                    return View("SearchPaymentDetailById", model);
                }
                else
                {
                    foreach (var item in searchPaymentById._StudentPayments.ToList())
                    {
                        var temp = new IndexPaymentDetailByIdVM_StudentPayments()
                        {
                            Id = item.Id,
                            ClassId = item.ClassId,
                            FeeYearDate = item.FeeYearDate,
                            ClassName = item.ClassName,
                            PaymentDate = item.PaymentDate,
                            StudentId = item.StudentId,
                            StudentName = item.StudentName,
                            FeeTypeId = item.FeeTypeId,
                            TermNo = item.TermNo,
                            TermName = item.TermName,
                            FeeType = item.FeeType,
                            Amount = item.FeeAmount,
                            Discount = item.Discount,
                            Fine = item.Fine,
                            PaidAmount = item.PaidAmount,
                            Remarks = item.Remarks
                        };
                        list.Add(temp);
                    };
                    var model = new IndexPaymentDetailByIdVM()
                    {
                        TotalFine = searchPaymentById.TotalFine,
                        TotalPaid = searchPaymentById.TotalPaid,
                        TotalHavetoPay = searchPaymentById.TotalHavetoPay,
                        ClassId = searchPaymentById.ClassId,
                        _StudentPayments = list,
                        StudentId = StudentId,
                        RegistrationId = RegistrationId,
                        StudentSearchName = searchPaymentById.StudentSearchName
                    };
                    return View("SearchPaymentDetailById", model);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> SearchPaymentDetailById2()
        {
            try
            {
               
                var p = _oeUsersServ.GetUserByID(Convert.ToInt64(HttpContext.Session.GetString("session_CurrentActiveUserId")), he.WebRootPath);

                if (p!=null) { 
                    var result = new SearchPaymentDetailById()
                {
                    //StudentId = StudentId,
                    RegistrationId =  p.Users.RegistrationNo
                };
                var searchPaymentById = await Task.Run(() => _StudentPaymentsServ.SearchPaymentDetailById2(result));
                var list = new List<IndexPaymentDetailByIdVM_StudentPayments>();
                ViewBag.ddlClasses = _classesServ.dropdown_Class();
                ViewBag.ddlGenders = _GendersServ.Dropdown_Genders();
                if (searchPaymentById._StudentPayments == null)
                {
                    ViewBag.Message = "Need to insert all pre required items- Such as: Fee Types, Fee Structure";
                    var model = new IndexPaymentDetailByIdVM()
                    {
                        ClassId = searchPaymentById.ClassId,
                        _StudentPayments = null,
                        StudentId = 0,
                        RegistrationId = p.Users.RegistrationNo,
                        StudentSearchName = searchPaymentById.StudentSearchName
                    };
                    return View("SearchPaymentDetailById", model);
                }
                else
                {
                    foreach (var item in searchPaymentById._StudentPayments.ToList())
                    {
                        var temp = new IndexPaymentDetailByIdVM_StudentPayments()
                        {
                            Id = item.Id,
                            ClassId = item.ClassId,
                            FeeYearDate = item.FeeYearDate,
                            ClassName = item.ClassName,
                            PaymentDate = item.PaymentDate,
                            StudentId = item.StudentId,
                            StudentName = item.StudentName,
                            FeeTypeId = item.FeeTypeId,
                            TermNo = item.TermNo,
                            TermName = item.TermName,
                            FeeType = item.FeeType,
                            Amount = item.FeeAmount,
                            Discount = item.Discount,
                            Fine = item.Fine,
                            PaidAmount = item.PaidAmount,
                            Remarks = item.Remarks
                        };
                        list.Add(temp);
                    };
                    var model = new IndexPaymentDetailByIdVM()
                    {
                        TotalFine = searchPaymentById.TotalFine,
                        TotalPaid = searchPaymentById.TotalPaid,
                        TotalHavetoPay = searchPaymentById.TotalHavetoPay,
                        ClassId = searchPaymentById.ClassId,
                        _StudentPayments = list,
                        //StudentId = StudentId,
                        RegistrationId = p.Users.RegistrationNo,
                        StudentSearchName = searchPaymentById.StudentSearchName
                    };
                    return View("SearchPaymentDetailById2", model);
                }

                }
                else
                {
                    var model = new IndexPaymentDetailByIdVM()
                    {
                        TotalFine =0,
                        TotalPaid = 0,
                        TotalHavetoPay = 0,
                        ClassId = 0,
                        _StudentPayments = null,
                        //StudentId = StudentId,
                        RegistrationId = "",
                        StudentSearchName = ""
                    };
                    return View("SearchPaymentDetailById2", model);
                }

            }
            catch
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> StudentPaymentSheet(Int64 StudentId, string RegistrationId, Int64 ClassId, Int64 ClassYear = 0)
        {
            try
            {
                ViewBag.ddlFeeType = _FeeTypesServ.dropdown_FeeType(ClassId);
                ViewBag.ddlYear = _StudentPaymentsServ.dropdown_Year(StudentId);
                //[NOTE : get default classyear if parameter is empty]
                if (ClassYear == 0)
                {
                    var classyears = _StudentPaymentsServ.dropdown_Year(StudentId).FirstOrDefault();
                    if (classyears != null) { ClassYear = classyears.Year; }
                }
                var FeeStructureList = await Task.Run(() => _FeeStructuresServ.GetFeeStructuresByClass(StudentId, ClassId, ClassYear));
                var listOfFee = new List<IndexPaymentDetailByIdVM_FeeStructure>();
                foreach (var feeStructure in FeeStructureList._FeeStructures)
                {
                    var temp = new IndexPaymentDetailByIdVM_FeeStructure()
                    {
                        Id = feeStructure.Id,
                        ClassId = feeStructure.ClassId,
                        Amount = feeStructure.Amount,
                        FeeTypeId = feeStructure.FeeTypeId,
                        IsActive = feeStructure.IsActive,
                        TermNo = feeStructure.TermNo,
                        TermName = feeStructure.TermName,
                        FeeTermDescriptionId = feeStructure.FeeTermDescriptionId,
                        DiscountAmount = feeStructure.DiscountAmount,
                        Fine = feeStructure.Fine,
                        PaidAmount = feeStructure.PaidAmount,
                        Remarks = feeStructure.Remarks,
                        FeeType = feeStructure.FeeType
                    };
                    listOfFee.Add(temp);
                };
                var model = new IndexPaymentDetailByIdVM()
                {
                    ClassId = ClassId,
                    ClassName = FeeStructureList.ClassName,
                    FeeYear = FeeStructureList.FeeYear,
                    _FeeStructure = listOfFee,
                    StudentId = StudentId,
                    RegistrationId = RegistrationId,
                };
                return View("StudentPaymentSheet", model);
            }
            catch
            {
                return BadRequest();
            }
        }

        //[Rahul - update 27Apr21]
        public async Task<IActionResult> MakePayments()
        {
            return View();
        }
        //[~Rahul - update 27Apr21]
        #endregion "Get methods"
       
        #region "Post_Methods" 

        [HttpPost]
        public JsonResult InsertStudentPayment(IndexPaymentDetailByIdVM obj)
        {
            var result = (dynamic)null;
            string message = (dynamic)null;
            try
            {
                if (obj.StudentPayments != null)
                {
                    var paymentLists = new List<InsertStudentPayment_StudentPayments>();
                    foreach (var item in obj._FeeStructure)
                    {
                        var payment = new InsertStudentPayment_StudentPayments()
                        {
                            PaymentDate = obj.StudentPayments.PaymentDate,
                            StudentId = obj.StudentPayments.StudentId,
                            FeeTypeId = item.FeeTypeId,
                            ClassId = obj.StudentPayments.ClassId,
                            FeeTermDescriptionId = item.TermNo,
                            FeeYear = obj.StudentPayments.FeeYear,
                            Fine = item.Fine,
                            PaidAmount = item.PaidAmount,
                            Remarks = item.Remarks
                        };
                        paymentLists.Add(payment);
                    }
                    var model = new InsertStudentPayment()
                    {
                        _StudentPayments = paymentLists
                    };
                    message = _StudentPaymentsServ.InsertStudentPayment(model);
                    result = Json(new { success = true, Message = message });
                }
            }
            catch (Exception ex)
            {
                result = Json(new { success = false, Message = "ERROR101:StudentPayment/InsertStudentPayment - " + ex.Message });
            }
            return result;
        }
        [HttpPost]
        public JsonResult UpdateStudentPayment(IndexPaymentDetailByIdVM obj)
        {
            var result = (dynamic)null;
            string message = (dynamic)null;
            try
            {
                if (obj.StudentPayments != null)
                {
                    var StudentPayments = new UpdateStudentPayment_StudentPayments()
                    {
                        Id = obj.StudentPayments.Id,
                        PaymentDate = obj.StudentPayments.PaymentDate,
                        StudentId = obj.StudentPayments.StudentId,
                        ClassId = obj.StudentPayments.ClassId,
                        FeeYear = obj.StudentPayments.FeeYear,
                        FeeTypeId = obj.StudentPayments.FeeTypeId,
                        Fine = obj.StudentPayments.Fine,
                        PaidAmount = obj.StudentPayments.PaidAmount,
                        Remarks = obj.StudentPayments.Remarks
                    };
                    var model = new UpdateStudentPayment()
                    {
                        StudentPayments = StudentPayments
                    };
                    message = _StudentPaymentsServ.UpdateStudentPayment(model);
                    result = Json(new { success = true, Message = message });
                }
            }
            catch (Exception ex)
            {
                result = Json(new { success = false, Message = "ERROR101:StudentPayments/UpdateStudentPayment - " + ex.Message });
            }
            return result;
        }
        [HttpPost]
        public JsonResult DeleteStudentPayment(long StudentPaymentId)
        {
            var result = (dynamic)null;
            string message = (dynamic)null;
            try
            {
                var model = new DeleteStudentPayment()
                {
                    StudentPaymentId = StudentPaymentId
                };
                message = _StudentPaymentsServ.DeleteStudentPayment(model);
                result = Json(new { success = true, Message = message });
            }
            catch (Exception ex)
            {
                result = Json(new { success = false, Message = "ERROR101:StudentPayments/UpdateStudentPayment - " + ex.Message });
            }
            return result;
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
        public JsonResult DropDown_StudentDiscount(long ddlFeeType)
        {
            var result = (dynamic)null;
            if (ddlFeeType != 0)
            {
                var discount = _StudentDiscountsServ.dropdown_StudentDiscounts(ddlFeeType);
                var model = new dropdown_StudentDiscounts()
                {
                    Id = discount.Id != 0 ? discount.Id : 0,
                    Amount = discount.Amount != 0 ? discount.Amount : 0
                };
                result = Json(new { id = model.Id, name = model.Amount });
            }
            return result;
        }
        public JsonResult DropDown_FeeAmount(long ddlFeeType)
        {
            var result = (dynamic)null;
            if (ddlFeeType != 0)
            {
                var discount = _FeeStructuresServ.dropdown_FeeStructures(ddlFeeType);
                result = Json(new { id = discount.Id, amount = discount.Amount });
            }
            return result;
        }
        public JsonResult DropDown_Class(long year, long studentId)
        {
            var result = (dynamic)null;
            if (year != 0)
            {
                var classes = _StudentPaymentsServ.ClassByYear(year, studentId);
                var model = new ClassByYear()
                {
                    Id = classes.Id,
                    Name = classes.Name
                };
                result = Json(new { id = model.Id, name = model.Name });
            }
            return result;
        }
        #endregion "Post Methods- dropdown"    

        #region "Report Methods"       
        public IActionResult PrintStudentPaymentsList()
        {
            ViewBag.OeErrorMessage = null;
            var model = new PrintIndexStudentPaymentsListVM();
            try
            {
                string footer = "--footer-center \"  Printed Date: " +
                      DateTime.Now.Date.ToString("dd/MM/yyyy") + " - " + "  Page: [page] to [toPage]\"" +
                      " --footer-line --footer-font-size \"10\" --footer-spacing 1 --footer-font-name \"Courier New\"";
                var result = _StudentPaymentsServ.PrintGetStudentPaymentsList();
                var list = new List<PrintIndexStudentPaymentsListVM_StudentPayments>();
                foreach (var item in result._StudentPayments.ToList())
                {
                    var temp = new PrintIndexStudentPaymentsListVM_StudentPayments()
                    {
                        Id = item.Id,
                        ClassId = item.ClassId,
                        FeeYearDate = item.FeeYearDate,
                        PaymentDate = item.PaymentDate,
                        StudentId = item.StudentId,
                        StudentName = item.StudentName,
                        FeeTypeId = item.FeeTypeId,
                        FeeType = item.FeeType,
                        Amount = item.Amount,
                        Fine = item.Fine,
                        PaidAmount = item.PaidAmount,
                        Remarks = item.Remarks
                    };
                    list.Add(temp);
                };
                //[NOTE: map institutions]
                var currentInstitution = new PrintIndexStudentPaymentsListVM_Institutions()
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
                model = new PrintIndexStudentPaymentsListVM()
                {
                    _StudentPayments = list,
                    Institution = currentInstitution
                };
                return new ViewAsPdf("PrintStudentPaymentsList", model)
                {
                    CustomSwitches = footer
                };

            }
            catch (Exception ex)
            {
                ViewBag.OeErrorMessage = "ERROR101:ExamTypes/PrintExamTypes -" + ex.Message;
                return View("PrintStudentPaymentsList");
            }
        }
        #endregion "Report Methods"        
    }
}
