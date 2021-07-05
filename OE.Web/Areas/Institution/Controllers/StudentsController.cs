using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using OE.Service;
using OE.Service.ServiceModels.StudentsServ;
using OE.Web.Areas.Institution.Models;
using OE.Web.Areas.Institution.Models.StudentsVM;
using Rotativa.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OE.Web.Areas.Institution.Controllers
{
    [Area("Institution")]
    public class StudentsController : Controller
    {
        #region "Variables"
        private readonly IStudentsServ _studentsServ;
        private readonly IClassesServ _classesServ;
        private readonly IGendersServ _GendersServ;
        IWebHostEnvironment _he;
        #endregion "Variables"

        #region "Constructor"
        public StudentsController(
            IStudentsServ studentsServ, IClassesServ classesServ,
            IWebHostEnvironment he,
            IGendersServ GendersServ
        )
        {
            _studentsServ = studentsServ;
            _classesServ = classesServ;
            _GendersServ = GendersServ;
            _he = he;
        }
        #endregion "Constructor"

        #region "Get methods"         
        public async Task<IActionResult> StudentsByAccountant(string SearchStudentClassId, int pg = 1)
        {
            try
            {
                if (String.IsNullOrEmpty(SearchStudentClassId))
                {
                    ViewBag.ddlClasses = _classesServ.dropdown_Class();
                    ViewBag.searchRequest = false;
                    var model = new StudentsByAccountantVM()
                    {
                        _Students = null,
                        SearchStudentClassId = null
                    };
                    return View("StudentsByAccountant", model);
                }
                else
                {
                    var result = new SearchStudentsByClass()
                    {
                        WebRootPath = _he.WebRootPath,
                        SearchStudentClassId = SearchStudentClassId
                    };
                    var SearchStudentsByClass = await Task.Run(() => _studentsServ.SearchStudentsByClass(result));
                    ViewBag.ddlClasses = _classesServ.dropdown_Class();
                    ViewBag.ddlGenders = _GendersServ.Dropdown_Genders();
                    var list = new List<StudentsByAccountantVM_Students>();
                    foreach (var item in SearchStudentsByClass._Students.ToList())
                    {
                        var temp = new StudentsByAccountantVM_Students()
                        {
                            Id = item.Id,
                            ClassId = item.ClassId,
                            ClassName = item.ClassName,
                            GenderId = item.GenderId,
                            GenderName = item.GenderName,
                            RegistrationNo = item.RegistrationNo,
                            FirstName = item.FirstName,
                            LastName = item.LastName,
                            StudentName = item.StudentName,
                            FatherName = item.FatherName,
                            MotherName = item.MotherName,
                            ParentsName = item.ParentsName,
                            CurrentClassName = item.CurrentClassName,
                            CurrentYear = item.CurrentYear,
                            IP300X200 = item.IP300X200,
                            AdmittedYear = item.AdmittedYear,
                            PresentAddress = item.PresentAddress,
                            PermanentAddress = item.PermanentAddress,
                            DOB = item.DOB,
                            IsActive = item.IsActive,
                            AddedBy = item.AddedBy = 0,
                            AddedDate = DateTime.Now,
                            ModifiedBy = 0,
                            ModifiedDate = DateTime.Now,
                            DataType = null
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
                    var model = new StudentsByAccountantVM()
                    {
                        ClassName = SearchStudentsByClass.SearchStudentClassName,
                        _Students = data,
                        SearchStudentClassId = SearchStudentClassId
                    };
                    #endregion "Paging"
                    
                    return View("StudentsByAccountant", model);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> SearchByClass(string SearchStudentClassId, int pg =1)
        {
            try
            {
                if (String.IsNullOrEmpty(SearchStudentClassId))
                {
                    ViewBag.ddlClasses = _classesServ.dropdown_Class();
                    ViewBag.searchRequest = false;
                    var model = new IndexStudentsListVM()
                    {
                        _Students = null,
                        SearchStudentClassId = null
                    };
                    return View("StudentsList", model);
                }
                else if (SearchStudentClassId == "All class")
                {
                    var result = new SearchStudentsByClass()
                    {
                        WebRootPath = _he.WebRootPath,
                        SearchStudentClassId = SearchStudentClassId
                    };
                    var SearchStudentsByClass = await Task.Run(() => _studentsServ.SearchStudentsByClass(result));
                    ViewBag.ddlClasses = _classesServ.dropdown_Class();
                    ViewBag.ddlGenders = _GendersServ.Dropdown_Genders();
                    var list = new List<Vm_Students>();
                    foreach (var item in SearchStudentsByClass._Students.ToList())
                    {
                        var temp = new Vm_Students()
                        {
                            Id = item.Id,
                            ClassId = item.ClassId,
                            ClassName = item.ClassName,
                            GenderId = item.GenderId,
                            GenderName = item.GenderName,
                            RegistrationNo = item.RegistrationNo,
                            RollNO = item.RollNO,
                            CurrentClassId = item.CurrentClassId,
                            CurrentClassName = item.CurrentClassName,
                            CurrentYear = DateTime.Now,
                            FirstName = item.FirstName,
                            LastName = item.LastName,
                            StudentName = item.StudentName,
                            FatherName = item.FirstName,
                            MotherName = item.LastName,
                            ParentsName = item.ParentsName,
                            IP300X200 = item.IP300X200,
                            AdmittedYear = item.AdmittedYear,
                            PresentAddress = item.PresentAddress,
                            PermanentAddress = item.PermanentAddress,
                            DOB = item.DOB,
                            IsActive = item.IsActive,
                            AddedBy = item.AddedBy = 0,
                            AddedDate = DateTime.Now,
                            ModifiedBy = 0,
                            ModifiedDate = DateTime.Now,
                            DataType = null
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
                    var model = new IndexStudentsListVM()
                    {
                        ClassName = SearchStudentsByClass.SearchStudentClassName,
                        _Students = data,
                        SearchStudentClassId = SearchStudentClassId
                    };
                    #endregion "Paging"
                   
                    return View("StudentsList", model);
                }
                else
                {
                    var result = new SearchStudentsByClass()
                    {
                        WebRootPath = _he.WebRootPath,
                        SearchStudentClassId = SearchStudentClassId
                    };
                    var SearchStudentsByClass = await Task.Run(() => _studentsServ.SearchStudentsByClass(result));
                    ViewBag.ddlClasses = _classesServ.dropdown_Class();
                    ViewBag.ddlGenders = _GendersServ.Dropdown_Genders();
                    var list = new List<Vm_Students>();
                    foreach (var item in SearchStudentsByClass._Students.ToList())
                    {
                        var temp = new Vm_Students()
                        {
                            Id = item.Id,
                            ClassId = item.ClassId,
                            ClassName = item.ClassName,
                            GenderId = item.GenderId,
                            GenderName = item.GenderName,
                            RegistrationNo = item.RegistrationNo,
                            RollNO = item.RollNO,
                            CurrentClassId = item.CurrentClassId,
                            CurrentClassName = item.CurrentClassName,
                            CurrentYear = DateTime.Now,
                            FirstName = item.FirstName,
                            LastName = item.LastName,
                            StudentName = item.StudentName,
                            FatherName = item.FatherName,
                            MotherName = item.MotherName,
                            ParentsName = item.ParentsName,
                            IP300X200 = item.IP300X200,
                            AdmittedYear = item.AdmittedYear,
                            PresentAddress = item.PresentAddress,
                            PermanentAddress = item.PermanentAddress,
                            DOB = item.DOB,
                            IsActive = item.IsActive,
                            AddedBy = item.AddedBy = 0,
                            AddedDate = DateTime.Now,
                            ModifiedBy = 0,
                            ModifiedDate = DateTime.Now,
                            DataType = null
                        };
                        list.Add(temp);
                    };
                    var model = new IndexStudentsListVM()
                    {
                        ClassName = SearchStudentsByClass.SearchStudentClassName,
                        _Students = list,
                        SearchStudentClassId = SearchStudentClassId
                    };
                    return View("StudentsList", model);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> StudentsaddDetails(string SearchStudentClassId)
        {
            try
            {
                var result = new SearchStudentsByClass()
                {
                    WebRootPath = _he.WebRootPath,
                    SearchStudentClassId = SearchStudentClassId


                };

                var SearchStudentsByClass = await Task.Run(() => _studentsServ.SearchStudentsByClass(result));
                ViewBag.ddlClasses = _classesServ.dropdown_Class();
                ViewBag.ddlGenders = _GendersServ.Dropdown_Genders();
                var list = new List<Vm_Students>();
                foreach (var item in SearchStudentsByClass._Students.ToList())
                {
                    var temp = new Vm_Students()
                    {
                        Id = item.Id,
                        ClassId = item.ClassId,

                        ClassName = item.ClassName,
                        GenderId = item.GenderId,
                        GenderName = item.GenderName,
                        RegistrationNo = item.RegistrationNo,
                        RollNO = item.RollNO,
                        CurrentClassId = item.CurrentClassId,
                        CurrentClassName = item.CurrentClassName,
                        CurrentYear = DateTime.Now,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        StudentName = item.StudentName,
                        FatherName = item.FatherName,
                        MotherName = item.MotherName,
                        ParentsName = item.ParentsName,
                        IP300X200 = item.IP300X200,
                        AdmittedYear = item.AdmittedYear,
                        PresentAddress = item.PresentAddress,
                        PermanentAddress = item.PermanentAddress,
                        DOB = item.DOB,
                        IsActive = item.IsActive,
                        AddedBy = item.AddedBy = 0,
                        AddedDate = DateTime.Now,
                        ModifiedBy = 0,
                        ModifiedDate = DateTime.Now,
                        DataType = null
                    };
                    list.Add(temp);
                };
                var model = new IndexStudentsListVM()
                {
                    ClassName = SearchStudentsByClass.SearchStudentClassName,
                    _Students = list,
                    SearchStudentClassId = SearchStudentClassId
                };
                return View("StudentsaddDetails", model);
            }

            catch
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> SearchStudentsClassByAccountant(string SearchStudentClassId)
        {
            try
            {
                if (String.IsNullOrEmpty(SearchStudentClassId))
                {
                    var model = new StudentsByAccountantVM()
                    {
                        _Students = null,
                        SearchStudentClassId = null

                    };
                    return View("StudentsByAccountant", model);
                }

                else
                {
                    var result = new SearchStudentsByClass()
                    {
                        SearchStudentClassId = SearchStudentClassId

                    };
                    var SearchStudentsByClass = await Task.Run(() => _studentsServ.SearchStudentsByClass(result));
                    ViewBag.ddlClasses = _classesServ.dropdown_Class();
                    ViewBag.ddlGenders = _GendersServ.Dropdown_Genders();
                    var list = new List<StudentsByAccountantVM_Students>();
                    foreach (var item in SearchStudentsByClass._Students.ToList())
                    {
                        var temp = new StudentsByAccountantVM_Students()
                        {
                            Id = item.Id,
                            ClassId = item.ClassId,

                            ClassName = item.ClassName,
                            GenderId = item.GenderId,
                            GenderName = item.GenderName,
                            RegistrationNo = item.RegistrationNo,
                            FirstName = item.FirstName,
                            LastName = item.LastName,
                            StudentName = item.StudentName,
                            FatherName = item.FatherName,
                            MotherName = item.MotherName,
                            ParentsName = item.ParentsName,
                            IP300X200 = item.IP300X200,
                            AdmittedYear = item.AdmittedYear,
                            PresentAddress = item.PresentAddress,
                            PermanentAddress = item.PermanentAddress,
                            DOB = item.DOB,
                            IsActive = item.IsActive,
                            AddedBy = item.AddedBy = 0,
                            AddedDate = DateTime.Now,
                            ModifiedBy = 0,
                            ModifiedDate = DateTime.Now,
                            DataType = null
                        };
                        list.Add(temp);
                    };
                    var model = new StudentsByAccountantVM()
                    {
                        _Students = list,
                        SearchStudentClassId = SearchStudentClassId
                    };
                    return View("StudentsByAccountant", model);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> StudentDetails(Int64 StudentId)
        {
            try
            {
                var result = new StudentDetails()
                {
                    StudentId = StudentId

                };
                var studentList = await Task.Run(() => _studentsServ.StudentDetails(result));
                var temp = new StudentDetailsVM_Students()
                {
                    Id = studentList.student.Id,
                    ClassId = studentList.student.ClassId,
                    CurrentClassName = studentList.student.CurrentClassName,
                    ClassName = studentList.student.ClassName,
                    GenderId = studentList.student.GenderId,
                    GenderName = studentList.student.GenderName,
                    RegistrationNo = studentList.student.RegistrationNo,
                    FirstName = studentList.student.FirstName,
                    LastName = studentList.student.LastName,
                    StudentName = studentList.student.StudentName,
                    FatherName = studentList.student.FatherName,
                    MotherName = studentList.student.MotherName,
                    ParentsName = studentList.student.ParentsName,
                    IP300X200 = studentList.student.IP300X200,
                    AdmittedYear = studentList.student.AdmittedYear,
                    PresentAddress = studentList.student.PresentAddress,
                    PermanentAddress = studentList.student.PermanentAddress,
                    DOB = studentList.student.DOB,
                    IsActive = studentList.student.IsActive,
                    AddedBy = studentList.student.AddedBy = 0,
                    AddedDate = DateTime.Now,
                    ModifiedBy = 0,
                    ModifiedDate = DateTime.Now,
                    DataType = null
                };
                var model = new StudentDetailsVM()
                {
                    Students = temp
                };
                return View("StudentDetails", model);
            }

            catch
            {
                return BadRequest();
            }
        }
        public async Task<IActionResult> StudentDetailsByAccountant(Int64 StudentId)
        {
            try
            {
                var result = new StudentDetails()
                {
                    StudentId = StudentId

                };
                var studentList = await Task.Run(() => _studentsServ.StudentDetails(result));
                var temp = new StudentDetailsVM_Students()
                {
                    Id = studentList.student.Id,
                    ClassId = studentList.student.ClassId,
                    CurrentClassName = studentList.student.CurrentClassName,
                    ClassName = studentList.student.ClassName,
                    GenderId = studentList.student.GenderId,
                    GenderName = studentList.student.GenderName,
                    RegistrationNo = studentList.student.RegistrationNo,
                    FirstName = studentList.student.FirstName,
                    LastName = studentList.student.LastName,
                    StudentName = studentList.student.StudentName,
                    FatherName = studentList.student.FatherName,
                    MotherName = studentList.student.MotherName,
                    ParentsName = studentList.student.ParentsName,
                    IP300X200 = studentList.student.IP300X200,
                    AdmittedYear = studentList.student.AdmittedYear,
                    PresentAddress = studentList.student.PresentAddress,
                    PermanentAddress = studentList.student.PermanentAddress,
                    DOB = studentList.student.DOB,
                    IsActive = studentList.student.IsActive,
                    AddedBy = studentList.student.AddedBy = 0,
                    AddedDate = DateTime.Now,
                    ModifiedBy = 0,
                    ModifiedDate = DateTime.Now,
                    DataType = null
                };
                var model = new StudentDetailsVM()
                {
                    Students = temp
                };
                return View("StudentDetailsByAccountant", model);
            }

            catch
            {
                return BadRequest();
            }
        }
        #endregion "Get methods"
     
        #region "Post_Methods"        
        [HttpPost]        
        public JsonResult InsertStudent(IndexStudentsListVM obj)
        {            
            var result = (dynamic)null;
            string message = (dynamic)null;
            try
            {
                if(ModelState.IsValid)
                {
                    if (obj.Students != null)
                    {
                        var Students = new InsertStudent_Students()
                        {
                            ClassId = obj.Students.ClassId,
                            GenderId = obj.Students.GenderId,
                            RegistrationNo = obj.Students.RegistrationNo,
                            FirstName = obj.Students.FirstName,
                            LastName = obj.Students.LastName,
                            FatherName = obj.Students.FatherName,
                            MotherName = obj.Students.MotherName,
                            IP300X200 = obj.Students.IP300X200,
                            Year = obj.Students.Year,
                            PresentAddress = obj.Students.PresentAddress,
                            PermanentAddress = obj.Students.PermanentAddress,
                            DOB = obj.Students.DOB,
                            fleImage = obj.Students.fleImage,
                            IsActive = obj.Students.IsActive,
                            AddedBy = 0,
                            AddedDate = DateTime.Now,
                            ModifiedBy = 0,
                            ModifiedDate = DateTime.Now,
                            DataType = null
                        };

                        var StudentPromotions = new InsertStudent_StudentPromotions()
                        {
                            ClassId = obj.Students.ClassId,
                            StudentId = obj.Students.Id,
                            Year = obj.Students.Year,
                            RollNo = obj.StudentPromotions.RollNo,
                            IsActive = obj.Students.IsActive,
                            AddedBy = 0,
                            AddedDate = DateTime.Now,
                            ModifiedBy = 0,
                            ModifiedDate = DateTime.Now,
                            DataType = null
                        };

                        var model = new InsertStudent()
                        {
                            WebRootPath = _he.WebRootPath,
                            Students = Students,
                            StudentPromotions = StudentPromotions
                        };

                        message = _studentsServ.InsertStudent(model);
                        result = Json(new { success = true, Message = message });

                    }
                }

            }
            // catch (Exception)
            catch (Exception ex)
            {
                
                result = Json(new { success = false, Message = "ERROR101:Students/InsertStudent - " + ex.Message });
            }
            
            return result;
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStudent(IndexStudentsListVM obj)
        {

            try
            {
                if (obj.Students != null)
                {

                    var Students = new UpdateStudent_Students()
                    {
                        Id = obj.Students.Id,
                        ClassId = obj.Students.ClassId,
                        GenderId = obj.Students.GenderId,
                        RegistrationNo = obj.Students.RegistrationNo,
                        FirstName = obj.Students.FirstName,
                        LastName = obj.Students.LastName,
                        FatherName = obj.Students.FatherName,
                        MotherName = obj.Students.MotherName,
                        IP300X200 = obj.Students.IP300X200,
                        Year = obj.Students.Year,
                        PresentAddress = obj.Students.PresentAddress,
                        PermanentAddress = obj.Students.PermanentAddress,
                        DOB = obj.Students.DOB,
                        fleImage = obj.Students.fleImage,
                        IsActive = obj.Students.IsActive,
                        AddedBy = 0,
                        AddedDate = DateTime.Now,
                        ModifiedBy = 0,
                        ModifiedDate = DateTime.Now,
                        DataType = null

                    };
                    var StudentPromotions = new UpdateStudent_StudentPromotions()
                    {
                        ClassId = obj.Students.ClassId,
                        StudentId = obj.Students.Id,
                        Year = obj.Students.Year,
                        RollNo = obj.StudentPromotions.RollNo,
                        IsActive = obj.Students.IsActive,
                        AddedBy = 0,
                        AddedDate = DateTime.Now,
                        ModifiedBy = 0,
                        ModifiedDate = DateTime.Now,
                        DataType = null
                    };


                    var model = new UpdateStudent()
                    {
                        WebRootPath = _he.WebRootPath,
                        Students = Students,
                        StudentPromotions = StudentPromotions

                    };

                    await Task.Run(() => _studentsServ.UpdateStudent(model));
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return RedirectToAction("SearchByClass");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteStudent(long StudentId)
        {
            try
            {
                var model = new DeleteStudent()
                {
                    WebRootPath = _he.WebRootPath,
                    StudentId = StudentId

                };
                await Task.Run(() => _studentsServ.DeleteStudent(model));

            }
            catch (Exception)
            {

                return BadRequest();
            }
            return RedirectToAction("SearchByClass");

        }
        #endregion "Post_Methods"

        #region "Report Methods"
        public IActionResult PrintStudentsList()
        {
            ViewBag.OeErrorMessage = null;
            var model = new PrintIndexStudentsListVM();
            try
            {

                string footer = "--footer-center \"  Printed Date: " +
                      DateTime.Now.Date.ToString("dd/MM/yyyy") + " - " + "  Page: [page] to [toPage]\"" +
                      " --footer-line --footer-font-size \"10\" --footer-spacing 1 --footer-font-name \"Courier New\"";


                var result = _studentsServ.PrintGetStudentsList();

                var list = new List<PrintIndexStudentsListVM_Students>();
                foreach (var item in result._Students.ToList())
                {
                    var temp = new PrintIndexStudentsListVM_Students()
                    {
                        Id = item.Id,
                        ClassId = item.ClassId,
                        ClassName = item.ClassName,
                        GenderId = item.GenderId,
                        GenderName = item.GenderName,
                        RegistrationNo = item.RegistrationNo,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        StudentName = item.StudentName,
                        FatherName = item.FatherName,
                        MotherName = item.MotherName,
                        ParentsName = item.ParentsName,
                        IP300X200 = item.IP300X200,
                        AdmittedYear = item.AdmittedYear,
                        PresentAddress = item.PresentAddress,
                        PermanentAddress = item.PermanentAddress,
                        DOB = item.DOB,
                        IsActive = item.IsActive,
                        AddedBy = item.AddedBy = 0,
                        AddedDate = DateTime.Now,
                        ModifiedBy = 0,
                        ModifiedDate = DateTime.Now,
                        DataType = null
                    };
                    list.Add(temp);
                };


                //[NOTE: map institutions]
                var currentInstitution = new PrintIndexStudentsListVM_Institutions()
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

                


                model = new PrintIndexStudentsListVM()
                {
                    _Students = list,
                    Institution = currentInstitution
                };

                return new ViewAsPdf("PrintStudentsList", model)
                {

                    CustomSwitches = footer

                };

            }
            catch (Exception ex)
            {
                ViewBag.OeErrorMessage = "ERROR101:ExamTypes/PrintExamTypes -" + ex.Message;
                return View("PrintStudentsList");
            }
        }
        #endregion "Report Methods"       
    }
}
