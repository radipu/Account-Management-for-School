
using OE.Data;
using OE.Repo;
using OE.Service.ServiceModels.StudentsServ;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using getStudentsList = OE.Service.ServiceModels.StudentsServ.getStudentsList;

namespace OE.Service
{
    public class StudentsServ : IStudentsServ
    {
        #region "Variables"
        private readonly IStudentsRepo<Students> _studentsRepo;
        private readonly IInstitutionsRepo<Institutions> _InstitutionsRepo;
        private readonly IClassesRepo<Classes> _classesRepo;
        private readonly IGendersRepo<Genders> _GendersRepo;   
        public readonly IStudentPromotionsRepo<StudentPromotions> _StudentPromotionsRepo;       
        private readonly ICommonServ _commonServ;
        //private object ViewBag;
        #endregion "Variables"

        #region "Constructor"
        public StudentsServ(IStudentsRepo<Students> studentsRepo,
            IInstitutionsRepo<Institutions> InstitutionsRepo,    
            IStudentPromotionsRepo<StudentPromotions> StudentPromotionsRepo,            
            ICommonServ commonServ,          
            IClassesRepo<Classes> classesRepo, IGendersRepo<Genders> GendersRepo)
        {
            _studentsRepo = studentsRepo;
            _classesRepo = classesRepo;          
            _StudentPromotionsRepo = StudentPromotionsRepo;         
            _InstitutionsRepo = InstitutionsRepo;
            _GendersRepo = GendersRepo;           
            _commonServ = commonServ;  
        }

        #endregion "Constructor"

        #region "Get Methods" 
        public getStudentsList.getStudentsList getStudentList(getStudentsList.getStudentsList obj)
        {
            var model = (dynamic)null;
            try
            {
                var studentsList = _studentsRepo.GetAll().ToList();
                var StudentPromotionsList = _StudentPromotionsRepo.GetAll().ToList();
                var thisYear = DateTime.Now.Year;
                var ClassList = _classesRepo.GetAll().ToList();
                var GendersList = _GendersRepo.GetAll().ToList();
                var query = (from _students in studentsList
                             join _Classes in ClassList on _students?.ClassId equals _Classes?.Id
                             join _Genders in GendersList on _students?.GenderId equals _Genders?.Id
                             join _studentPromotion in StudentPromotionsList on _students.Id equals _studentPromotion.StudentId
                             join _promotionClass in ClassList on _studentPromotion.ClassId equals _promotionClass.Id
                             where _studentPromotion.StudentId == _students.Id && _studentPromotion.ClassYear.Value.Year == thisYear
                             orderby _students.ClassId, _students.FirstName ascending
                             select new { _students, _Classes, _Genders, _studentPromotion, _promotionClass });
                var list = new List<getStudentsList.getStudentsList_Students>();
                foreach (var item in query)
                {
                    string path = string.IsNullOrEmpty(item._students.IP300X200) ? "" : item._students.IP300X200;
                    var temp = new getStudentsList.getStudentsList_Students()
                    {
                        Id = item._students.Id,
                        ClassId = item._students.ClassId,
                        RollNO = item._studentPromotion.RollNo,
                        CurrentClassId = item._studentPromotion.ClassId,
                        CurrentYear = item._studentPromotion.ClassYear,
                        ClassName = item._Classes.Name,
                        GenderId = item._students.GenderId,
                        RegistrationNo = item._students.RegistrationNo,
                        GenderName = item._Genders.Name,
                        FirstName = item._students.FirstName,
                        LastName = item._students.LastName,
                        StudentName = item._students.FirstName + "  " + item._students.LastName,
                        IP300X200 = _commonServ.CommImage_WrapperDefaultImage(path, obj.WebRootPath, item._students.GenderId),
                        AdmittedYear = item._students.AdmittedYear,
                        PresentAddress = item._students.PresentAddress,
                        PermanentAddress = item._students.PermanentAddress,
                        DOB = item._students.DOB,
                        IsActive = item._students.IsActive,
                        AddedBy = 0,
                        AddedDate = DateTime.Now,
                        ModifiedBy = 0,
                        ModifiedDate = DateTime.Now,
                        DataType = null
                    };
                    list.Add(temp);
                };
                model = new getStudentsList.getStudentsList()
                {
                    _Students = list
                };
            }
            catch (Exception)
            {

            }
            return model;
        }
        public GetStudentsByAccountant GetStudentsByAccountant()
        {
            var model = (dynamic)null;
            try
            {
                var studentsList = _studentsRepo.GetAll().ToList();
                var ClassList = _classesRepo.GetAll().ToList();
                var GendersList = _GendersRepo.GetAll().ToList();
                var query = (from _students in studentsList
                             join _Classes in ClassList on _students?.ClassId equals _Classes?.Id
                             join _Genders in GendersList on _students?.GenderId equals _Genders?.Id
                             orderby _students.ClassId, _students.FirstName ascending
                             select new { _students, _Classes, _Genders });

                var list = new List<GetStudentsByAccountant_Students>();
                foreach (var item in query)
                {
                    var temp = new GetStudentsByAccountant_Students()
                    {
                        Id = item._students.Id,
                        ClassId = item._students.ClassId,
                        ClassName = item._Classes.Name,
                        GenderId = item._students.GenderId,
                        RegistrationNo = item._students.RegistrationNo,
                        GenderName = item._Genders.Name,
                        FirstName = item._students.FirstName,
                        LastName = item._students.LastName,
                        StudentName = item._students.FirstName + "  " + item._students.LastName,
                        IP300X200 = item._students.IP300X200,
                        AdmittedYear = item._students.AdmittedYear,
                        PresentAddress = item._students.PresentAddress,
                        PermanentAddress = item._students.PermanentAddress,
                        DOB = item._students.DOB,
                        IsActive = item._students.IsActive,
                        AddedBy = 0,
                        AddedDate = DateTime.Now,
                        ModifiedBy = 0,
                        ModifiedDate = DateTime.Now,
                        DataType = null
                    };

                    list.Add(temp);
                };
                model = new GetStudentsByAccountant()
                {
                    _Students = list
                };

            }
            catch (Exception)
            {

            }
            return model;
        }
        public SearchStudentsByClass SearchStudentsByClass(SearchStudentsByClass obj)
        {
            var model = (dynamic)null;
            try
            {
                var studentsList = _studentsRepo.GetAll().ToList();
                var ClassList = _classesRepo.GetAll().ToList();
                var GendersList = _GendersRepo.GetAll().ToList();
                var StudentPromotionsList = _StudentPromotionsRepo.GetAll().ToList();
                // if (obj.SearchStudentCurrentClassId== "All class")
                if (obj.SearchStudentClassId == "All class")
                {
                    var query = (from _students in studentsList
                                 join _studentPrmotion in StudentPromotionsList on _students.Id equals _studentPrmotion?.StudentId
                                 join _Classes in ClassList on _students?.ClassId equals _Classes?.Id
                                 where _studentPrmotion.ClassId == _students.ClassId
                                 join _Genders in GendersList on _students?.GenderId equals _Genders?.Id
                                 select new { _studentPrmotion, _Classes, _Genders, _students }).ToList();
                    var list = new List<SearchStudentsByClass_Students>();
                    foreach (var item in query)
                    {
                        var getStudent = (from stu in studentsList
                                          where stu.RegistrationNo == item._students.RegistrationNo
                                          join cls in ClassList on stu.ClassId equals cls.Id
                                          select new { stu, cls }).SingleOrDefault();
                        string path = string.IsNullOrEmpty(item._students.IP300X200) ? "" : item._students.IP300X200;
                        var temp = new SearchStudentsByClass_Students()
                        {
                            Id = item._students.Id,
                            ClassId = item._students.ClassId,
                            ClassName = getStudent.cls.Name,
                            GenderId = item._students.GenderId,
                            RegistrationNo = item._students.RegistrationNo,
                            CurrentYear = DateTime.Now,
                            CurrentClassName = currentYearClassName(item._students.Id),
                            GenderName = item._Genders.Name,
                            FirstName = item._students.FirstName,
                            RollNO = item._studentPrmotion.RollNo,
                            LastName = item._students.LastName,
                            StudentName = item._students.FirstName + "  " + item._students.LastName,
                            FatherName = item._students.FatherName,
                            MotherName = item._students.MotherName,
                            ParentsName = item._students.FatherName + "  " + item._students.MotherName,
                            IP300X200 = _commonServ.CommImage_WrapperDefaultImage(path, obj.WebRootPath, item._students.GenderId),
                            AdmittedYear = item._students.AdmittedYear,
                            PresentAddress = item._students.PresentAddress,
                            PermanentAddress = item._students.PermanentAddress,
                            DOB = item._students.DOB,
                            IsActive = item._studentPrmotion.IsActive,
                            AddedBy = 0,
                            AddedDate = DateTime.Now,
                            ModifiedBy = 0,
                            ModifiedDate = DateTime.Now,
                            DataType = null
                        };
                        list.Add(temp);
                    };
                    model = new SearchStudentsByClass()
                    {
                        _Students = list,
                        // SearchStudentClassName = obj.SearchStudentClassId
                        SearchStudentClassName = obj.SearchStudentClassId
                    };
                }
                else
                {
                    Int64 SearchStudentClassId = Convert.ToInt64(obj.SearchStudentClassId);
                    var query = (from _students in studentsList
                                 join _studentPrmotion in StudentPromotionsList on _students.Id equals _studentPrmotion?.StudentId
                                 join _Classes in ClassList on _students?.ClassId equals _Classes?.Id
                                 where _students.ClassId == SearchStudentClassId && _studentPrmotion.ClassId == _students.ClassId
                                 join _Genders in GendersList on _students?.GenderId equals _Genders?.Id
                                 select new { _studentPrmotion, _Classes, _Genders, _students }).ToList();
                    var test = (from c in ClassList
                                where c.Id == SearchStudentClassId
                                select c).SingleOrDefault();
                    var list = new List<SearchStudentsByClass_Students>();
                    foreach (var item in query)
                    {
                        var getStudent = (from stu in studentsList
                                          where stu.RegistrationNo == item._students.RegistrationNo
                                          join cls in ClassList on stu.ClassId equals cls.Id
                                          select new { stu, cls }).SingleOrDefault();
                        string path = string.IsNullOrEmpty(item._students.IP300X200) ? "" : item._students.IP300X200;
                        var temp = new SearchStudentsByClass_Students()
                        {
                            Id = item._students.Id,
                            ClassId = item._students.ClassId,
                            ClassName = getStudent.cls.Name,
                            GenderId = item._students.GenderId,
                            RegistrationNo = item._students.RegistrationNo,
                            CurrentYear = DateTime.Now,
                            CurrentClassName = currentYearClassName(item._students.Id),
                            GenderName = item._Genders.Name,
                            FirstName = item._students.FirstName,
                            LastName = item._students.LastName,
                            StudentName = item._students.FirstName + "  " + item._students.LastName,
                            FatherName = item._students.FatherName,
                            MotherName = item._students.MotherName,
                            ParentsName = item._students.FatherName + "  " + item._students.MotherName,
                            IP300X200 = _commonServ.CommImage_WrapperDefaultImage(path, obj.WebRootPath, item._students.GenderId),
                            AdmittedYear = item._students.AdmittedYear,
                            PresentAddress = item._students.PresentAddress,
                            PermanentAddress = item._students.PermanentAddress,
                            DOB = item._students.DOB,
                            IsActive = item._studentPrmotion.IsActive,
                            AddedBy = 0,
                            AddedDate = DateTime.Now,
                            ModifiedBy = 0,
                            ModifiedDate = DateTime.Now,
                            DataType = null
                        };
                        list.Add(temp);
                    };
                    model = new SearchStudentsByClass()
                    {
                        _Students = list,
                        SearchStudentClassName = test.Name
                    };
                }
            }
            catch (Exception e)
            {
                var test = e.Message;
            }
            return model;
        }
        public StudentDetails StudentDetails(StudentDetails obj)
        {
            var model = (dynamic)null;
            var query = (dynamic)null;
            var studentList = _studentsRepo.GetAll().ToList();
            var ClassList = _classesRepo.GetAll().ToList();
            var GendersList = _GendersRepo.GetAll().ToList();
            query = (from _students in studentList
                     where _students.Id == obj.StudentId
                     join _Classes in ClassList on _students?.ClassId equals _Classes?.Id
                     join _Genders in GendersList on _students?.GenderId equals _Genders?.Id
                     select new { _students, _Classes, _Genders }).SingleOrDefault();
            var students = new StudentDetails_students()
            {
                Id = query._students.Id,
                ClassId = query._students.ClassId,
                ClassName = query._Classes.Name,
                GenderId = query._students.GenderId,
                CurrentClassName = currentYearClassName(query._students.Id),
                RegistrationNo = query._students.RegistrationNo,
                GenderName = query._Genders.Name,
                FirstName = query._students.FirstName,
                LastName = query._students.LastName,
                StudentName = query._students.FirstName + " " + query._students.LastName,
                FatherName = query._students.FatherName,
                MotherName = query._students.MotherName,
                ParentsName = query._students.FatherName + " " + query._students.MotherName,
                IP300X200 = query._students.IP300X200,
                AdmittedYear = query._students.AdmittedYear,
                PresentAddress = query._students.PresentAddress,
                PermanentAddress = query._students.PermanentAddress,
                DOB = query._students.DOB,
                IsActive = query._students.IsActive,
                AddedBy = 0,
                AddedDate = DateTime.Now,
                ModifiedBy = 0,
                ModifiedDate = DateTime.Now,
                DataType = null
            };
            model = new StudentDetails()
            {
                student = students
            };

            return model;
        }
        #endregion "Get Methods" 

        
        #region "Insert update and delete Function"  
        public string InsertStudent(InsertStudent obj)
        {
            string returnResult = (dynamic)null;
            try
            {                
                var studentsList = _studentsRepo.GetAll().ToList();
                var getregistration = (from stu in studentsList
                                       where stu.RegistrationNo == obj.Students.RegistrationNo
                                       select stu).SingleOrDefault();
                //var Studentlist = _studentsRepo.Get(obj.Students.Id);
                //var query=(from stu)
                
                if (getregistration == null)
                {
                    if (obj != null)
                    {
                        var AdmittedYear = DateTime.ParseExact(obj.Students.Year, "yyyy", null);
                        //[Note: insert 'states' table]
                        if (obj.Students != null)
                        {
                            var Students = new InsertStudent_Students()
                            {
                                ClassId = obj.Students.ClassId,
                                GenderId = obj.Students.GenderId,
                                RegistrationNo = obj.Students.RegistrationNo,
                                FirstName = obj.Students.FirstName,
                                LastName = obj.Students.LastName,
                                IP300X200 = obj.Students.IP300X200,
                                AdmittedYear = AdmittedYear,
                                PresentAddress = obj.Students.PresentAddress,
                                PermanentAddress = obj.Students.PermanentAddress,
                                DOB = obj.Students.DOB,
                                IsActive = obj.Students.IsActive,
                                AddedBy = obj.Students.AddedBy = 0,
                                AddedDate = DateTime.Now,
                                ModifiedBy = 0,
                                ModifiedDate = DateTime.Now,
                                FatherName = obj.Students.FatherName,
                                MotherName = obj.Students.MotherName,
                                DataType = null
                            };
                            //[NOTE: Student table]
                            _studentsRepo.Insert(Students);
                            if (obj.Students.fleImage != null)
                            {
                                string imagePathIP300X200 = "ClientDictionary/Students/IP300X200/";
                                string extension = Path.GetExtension(obj.Students.fleImage.FileName);
                                var lastAddingRecord = _studentsRepo.GetAll().Last();
                                if (_commonServ.CommImage_ImageFormat(lastAddingRecord.Id.ToString(), obj.Students.fleImage, obj.WebRootPath, imagePathIP300X200, 200, 300, extension).Equals(true))
                                {
                                    //[NOTE:Update image file]
                                    var imgStudent = _studentsRepo.Get(lastAddingRecord.Id);
                                    imgStudent.IP300X200 = imagePathIP300X200 + lastAddingRecord.Id + extension;
                                    _studentsRepo.Update(imgStudent);
                                }
                            }
                        }
                        Int64 getLastId = _studentsRepo.GetLastId();

                        //[NOTE: Student promotion table table]                   
                        if (obj.StudentPromotions != null)
                        {
                            var StudentPromotions = new InsertStudent_StudentPromotions()
                            {
                                StudentId = getLastId,
                                ClassId = obj.Students.ClassId,
                                RollNo = obj.StudentPromotions.RollNo,
                                ClassYear = AdmittedYear,
                                IsActive = obj.Students.IsActive,
                                AddedBy = 0,
                                AddedDate = DateTime.Now,
                                ModifiedBy = 0,
                                ModifiedDate = DateTime.Now,
                                DataType = null
                            };

                            _StudentPromotionsRepo.Insert(StudentPromotions);
                        }
                    }
                    returnResult = "Saved";
                }
                else
                {
                    returnResult = "this registration number already exist";
                }
            }
            catch (Exception ex)
            {
                returnResult = "ERROR102:Insert all required Info - " + ex.Message;
            }
            return returnResult;
        }
        public string UpdateStudent(UpdateStudent obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    var AdmittedYear = DateTime.ParseExact(obj.Students.Year, "yyyy", null);
                    if (obj.Students != null)
                    {
                        var currentItem = _studentsRepo.Get(obj.Students.Id);
                        currentItem.ClassId = obj.Students.ClassId;
                        currentItem.GenderId = obj.Students.GenderId;
                        currentItem.RegistrationNo = obj.Students.RegistrationNo;
                        currentItem.FirstName = obj.Students.FirstName;
                        currentItem.LastName = obj.Students.LastName;
                        currentItem.AdmittedYear = AdmittedYear;
                        currentItem.PresentAddress = obj.Students.PresentAddress;
                        currentItem.PermanentAddress = obj.Students.PermanentAddress;
                        currentItem.DOB = obj.Students.DOB;
                        currentItem.IsActive = obj.Students.IsActive;
                        currentItem.ModifiedBy = 0;
                        currentItem.ModifiedDate = DateTime.Now;
                        currentItem.FatherName = obj.Students.FatherName;
                        currentItem.MotherName = obj.Students.MotherName;
                        if (obj.Students.fleImage == null)
                        {
                            if (obj.Students.IP300X200 != null)
                            {
                                currentItem.IP300X200 = obj.Students.IP300X200;
                            }
                            else
                            {
                                //[NOTE: delete image from 'ClientDictionary']
                                string targetImageLocation = Path.Combine(obj.WebRootPath, currentItem.IP300X200);
                                _commonServ.DelFileFromLocation(targetImageLocation);
                            }
                        }
                        else
                        {
                            //[NOTE: delete image from 'ClientDictionary-if extensions are different']
                            if (currentItem.IP300X200 != null)
                            {
                                string targetImageLocation = Path.Combine(obj.WebRootPath, currentItem.IP300X200);
                                _commonServ.DelFileFromLocation(targetImageLocation);
                            }

                            //[NOTE: Upddate image]
                            string imagePathIP300X200 = "ClientDictionary/Students/IP300X200/";
                            string extension = Path.GetExtension(obj.Students.fleImage.FileName);
                            if (_commonServ.CommImage_ImageFormat(obj.Students.Id.ToString(), obj.Students.fleImage, obj.WebRootPath, imagePathIP300X200, 200, 300, extension).Equals(true))
                            {
                                currentItem.IP300X200 = imagePathIP300X200 + obj.Students.Id + extension;
                            }
                        }
                        _studentsRepo.Update(currentItem);
                        returnResult = "Saved";
                    }
                    //[NOTE: Student promotion table table]

                    if (obj.StudentPromotions != null)
                    {
                        var promotion = _StudentPromotionsRepo.GetAll().ToList();
                        var getStuPromotion = (from sp in promotion
                                               where sp.StudentId == obj.Students.Id
                                               select sp).FirstOrDefault();
                        getStuPromotion.ClassId = obj.Students.ClassId;
                        getStuPromotion.RollNo = obj.StudentPromotions.RollNo;
                        getStuPromotion.ClassYear = AdmittedYear;
                        getStuPromotion.IsActive = obj.Students.IsActive;
                        getStuPromotion.ModifiedBy = 0;
                        getStuPromotion.ModifiedDate = DateTime.Now;
                        _StudentPromotionsRepo.Update(getStuPromotion);
                        returnResult = "Saved";
                    }
                }
            }
            catch (Exception ex)
            {
                returnResult = "ERROR102:AddressesServ/UpdateAddress - " + ex.Message;
            }
            return returnResult;
        }
        public DeleteStudent DeleteStudent(DeleteStudent obj)
        {
            var returnModel = new DeleteStudent();
            var Student = _studentsRepo.Get(obj.StudentId);
            var studentsList = _studentsRepo.GetAll().ToList();
            var StudentPromotionsList = _StudentPromotionsRepo.GetAll().ToList();
            var query = (from p in StudentPromotionsList
                         where p.StudentId == obj.StudentId
                         select p);
            foreach (var item in query)
            {
                var StudentPromotion = _StudentPromotionsRepo.Get(item.Id);
                if (StudentPromotion != null)
                {
                    _StudentPromotionsRepo.Delete(StudentPromotion);
                    returnModel.Message = "Delete Successful.";
                }
            }
            if (Student != null)
            {
                _studentsRepo.Delete(Student);
                if (Student.IP300X200 != null)
                {
                    string DelImgofIP300X200 = Path.Combine(obj.WebRootPath, Student.IP300X200);
                    _commonServ.DelFileFromLocation(DelImgofIP300X200);
                }
                returnModel.Message = "Delete Successful.";
            }
            return returnModel;
        }
        #endregion "Insert update and delete Function"   

        #region "Report Method"
        public PrintGetStudentsList PrintGetStudentsList()
        {
            var model = new PrintGetStudentsList();
            try
            {
                var studentsList = _studentsRepo.GetAll().ToList();
                var institution = _InstitutionsRepo.GetAll().FirstOrDefault();
                var ClassList = _classesRepo.GetAll().ToList();
                var GendersList = _GendersRepo.GetAll().ToList();
                var query = (from _students in studentsList
                             join _Classes in ClassList on _students?.ClassId equals _Classes?.Id
                             join _Genders in GendersList on _students?.GenderId equals _Genders?.Id
                             select new { _students, _Classes, _Genders });
                var list = new List<PrintGetStudentsList_Students>();
                foreach (var item in query)
                {
                    var temp = new PrintGetStudentsList_Students()
                    {
                        Id = item._students.Id,
                        ClassId = item._students.ClassId,
                        ClassName = item._Classes.Name,
                        GenderId = item._students.GenderId,
                        RegistrationNo = item._students.RegistrationNo,
                        GenderName = item._Genders.Name,
                        FirstName = item._students.FirstName,
                        LastName = item._students.LastName,
                        StudentName = item._students.FirstName + "  " + item._students.LastName,
                        IP300X200 = item._students.IP300X200,
                        AdmittedYear = item._students.AdmittedYear,
                        PresentAddress = item._students.PresentAddress,
                        PermanentAddress = item._students.PermanentAddress,
                        DOB = item._students.DOB,
                        IsActive = item._students.IsActive,
                        AddedBy = 0,
                        AddedDate = DateTime.Now,
                        ModifiedBy = 0,
                        ModifiedDate = DateTime.Now,
                        FatherName = item._students.FatherName,
                        MotherName = item._students.MotherName,
                        ParentsName = item._students.FatherName + "  " + item._students.MotherName,
                        DataType = null
                    };
                    list.Add(temp);
                };

                //[NOTE: map institutions]
                var currentInstitution = new PrintGetStudentsList_Institutions()
                {
                    Id = institution.Id,
                    Name = institution.Name,
                    IsActive = institution.IsActive,
                    LogoPath = institution.LogoPath,
                    FaviconPath = institution.FaviconPath,
                    Email = institution.Email,
                    ContactNo = institution.ContactNo,
                    Address = institution.Address
                };
                model = new PrintGetStudentsList()
                {
                    _Students = list,
                    Institution = currentInstitution
                };
            }
            catch (Exception)
            {

            }
            return model;
        }
        #endregion "Report Method"
        

        #region "dropdown Methods" 
        public IEnumerable<dropdown_Students> dropdown_Students()
        {
            var queryAll = _studentsRepo.GetAll().ToList();
            var getStudents = from p in queryAll
                              select p;
            var queryResult = new List<dropdown_Students>();
            foreach (var item in getStudents)
            {
                var d = new dropdown_Students()
                {
                    Id = item.Id
                };
                queryResult.Add(d);
            }
            return queryResult;
        }
        #endregion "dropdown Methods" 

        #region "private method"
        private string currentYearClassName(long StudentId)
        {
            var model = (dynamic)null;
            var studentsList = _studentsRepo.GetAll().ToList();
            var StudentPromotionsList = _StudentPromotionsRepo.GetAll().ToList();
            var ClassList = _classesRepo.GetAll().ToList();
            var Year = DateTime.Now.Year;
            var query = (from _studentPromotion in StudentPromotionsList
                         join _class in ClassList on _studentPromotion?.ClassId equals _class?.Id
                         where _studentPromotion.StudentId == StudentId && _studentPromotion.ClassYear.Value.Year == Year
                         select _class).LastOrDefault();
            if (query != null)
            {
                var className = query.Name;
                model = className;
            }
            else
            {
                var className = "Not Promoted";
                model = className;
            }
            return model;
        }
        #endregion "private method"
    }
}

