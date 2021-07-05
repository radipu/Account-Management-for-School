using OE.Data;
using OE.Repo;
using OE.Service.ServiceModels.StudentDiscountsServ;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OE.Service
{
    public class StudentDiscountsServ : IStudentDiscountsServ
    {
        #region "Variables"
        private readonly IStudentDiscountsRepo<StudentDiscounts> _StudentDiscountsRepo;
        private readonly IFeeTypesRepo<FeeTypes> _FeeTypesRepo;
        private readonly IStudentsRepo<Students> _studentsRepo;       
        private readonly IInstitutionsRepo<Institutions> _InstitutionsRepo;        
        private readonly IClassesRepo<Classes> _classesRepo;       
        #endregion "Variables"

        #region "Constructor"
        public StudentDiscountsServ(IStudentDiscountsRepo<StudentDiscounts> StudentDiscountsRepo,         
            IInstitutionsRepo<Institutions> InstitutionsRepo,            
            IClassesRepo<Classes> classesRepo,           
            IFeeTypesRepo<FeeTypes> FeeTypesRepo, IStudentsRepo<Students> studentsRepo)
        {
            _StudentDiscountsRepo = StudentDiscountsRepo;
            _FeeTypesRepo = FeeTypesRepo;
            _studentsRepo = studentsRepo;           
            _classesRepo = classesRepo;           
            _InstitutionsRepo = InstitutionsRepo;         
        }


        #endregion "Constructor"

        #region "Get Methods"  
        public getStudentDiscountsList getStudentDiscountsList()
        {
            var model = new getStudentDiscountsList();
            try
            {
                var StudentDiscountsList = _StudentDiscountsRepo.GetAll().ToList();
                var FeeTypesList = _FeeTypesRepo.GetAll().ToList();
                var studentsList = _studentsRepo.GetAll().ToList();              
                var classList = _classesRepo.GetAll().ToList();               
                var query = (from _StudentDiscounts in StudentDiscountsList
                             join _FeeTypes in FeeTypesList on _StudentDiscounts?.FeeTypeId equals _FeeTypes?.Id
                             join _students in studentsList on _StudentDiscounts?.StudentId equals _students?.Id
                             join _class in classList on _students?.ClassId equals _class?.Id
                             select new { _StudentDiscounts, _FeeTypes, _students, _class });                           

                var list = new List<getStudentDiscountsList_StudentDiscounts>();
                foreach (var item in query)
                {
                    var temp = new getStudentDiscountsList_StudentDiscounts()
                    {
                        Id = item._StudentDiscounts.Id,                        
                        RegistrationNo=item._students.RegistrationNo,                       
                        StudentId = item._StudentDiscounts.StudentId,
                        StudentName = item._students.FirstName + " " + item._students.LastName,
                        ClassId = item._students.ClassId,
                        ClassName=item._class.Name,
                        FeeTypeId = item._StudentDiscounts.FeeTypeId,
                        FeeType = item._FeeTypes.Name,
                        DiscountAmout = item._StudentDiscounts.DiscountAmout
                    };
                    list.Add(temp);
                };

                model = new getStudentDiscountsList()
                {
                    _StudentDiscounts = list
                };

            }
            catch (Exception)
            {

            }
            return model;
        }
        
        public dropdown_StudentDiscounts dropdown_StudentDiscounts(long feeTypeId)
        {
            var queryAll = _StudentDiscountsRepo.GetAll().ToList();
            var getStudentDiscounts = (from p in queryAll
                                       where p.FeeTypeId == feeTypeId
                                       select p).SingleOrDefault();


            var queryResult = (dynamic)null;
            if (getStudentDiscounts != null)
            {
                queryResult = new dropdown_StudentDiscounts()
                {
                    Id = getStudentDiscounts.Id,
                    Amount = getStudentDiscounts.DiscountAmout
                };
            }

            else
            {
                queryResult = new dropdown_StudentDiscounts()
                {
                    Id = 0,
                    Amount = 0
                };
            }

            return queryResult;

        }
        #endregion "Get Methods" 
        
        #region "Insert update and delete Function"  
        public string InsertStudentDiscount(InsertStudentDiscount obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                var studentsList = _studentsRepo.GetAll().ToList();
                var query = (from _student in studentsList
                             where _student.RegistrationNo == obj.StudentDiscounts.RegistrationNo
                             select _student).SingleOrDefault();
                if (obj != null)
                {
                    //[Note: insert 'states' table]
                    if (obj.StudentDiscounts != null)
                    {
                        var StudentDiscounts = new InsertStudentDiscount_StudentDiscounts()
                        {
                            StudentId = query.Id,
                            FeeTypeId = obj.StudentDiscounts.FeeTypeId,
                            DiscountAmout = obj.StudentDiscounts.DiscountAmout
                        };
                        _StudentDiscountsRepo.Insert(StudentDiscounts);
                        returnResult = "Saved";
                    }
                }
            }
            catch (Exception ex)
            {
                returnResult = "ERROR102:ClassesServ/InsertClassessList - " + ex.Message;
            }
            return returnResult;
        }
        public string UpdateStudentDiscount(UpdateStudentDiscount obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                var studentsList = _studentsRepo.GetAll().ToList();
                var query = (from _student in studentsList
                             where _student.RegistrationNo == obj.StudentDiscounts.RegistrationNo
                             select _student).SingleOrDefault();
                if (obj != null)
                {
                    if (obj.StudentDiscounts != null)
                    {
                        var currentItem = _StudentDiscountsRepo.Get(obj.StudentDiscounts.Id);
                        currentItem.Id = obj.StudentDiscounts.Id;
                        currentItem.StudentId = query.Id;
                        currentItem.FeeTypeId = obj.StudentDiscounts.FeeTypeId;
                        currentItem.DiscountAmout = obj.StudentDiscounts.DiscountAmout;
                        _StudentDiscountsRepo.Update(currentItem);
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
        public DeleteStudentDiscount DeleteStudentDiscount(DeleteStudentDiscount obj)
        {
            var returnModel = new DeleteStudentDiscount();
            var StudentDiscounts = _StudentDiscountsRepo.Get(obj.StudentDiscountId);
            if (StudentDiscounts != null)
            {
                _StudentDiscountsRepo.Delete(StudentDiscounts);
                returnModel.Message = "Delete Successful.";
            }
            return returnModel;
        }
        #endregion "Insert update and delete Function"  

        #region "Report Method"
        public PrintGetStudentDiscountsList PrintGetStudentDiscountsList()
        {
            var model = new PrintGetStudentDiscountsList();
            try
            {
                var institution = _InstitutionsRepo.GetAll().FirstOrDefault();
                var StudentDiscountsList = _StudentDiscountsRepo.GetAll().ToList();
                var FeeTypesList = _FeeTypesRepo.GetAll().ToList();
                var studentsList = _studentsRepo.GetAll().ToList();
                var query = (from _StudentDiscounts in StudentDiscountsList
                             join _FeeTypes in FeeTypesList on _StudentDiscounts?.FeeTypeId equals _FeeTypes?.Id
                             join _students in studentsList on _StudentDiscounts?.StudentId equals _students?.Id
                             select new { _StudentDiscounts, _FeeTypes, _students });
                var list = new List<PrintGetStudentDiscountsList_StudentDiscounts>();
                foreach (var item in query)
                {
                    var temp = new PrintGetStudentDiscountsList_StudentDiscounts()
                    {
                        Id = item._StudentDiscounts.Id,
                        StudentId = item._StudentDiscounts.StudentId,
                        StudentName = item._students.FirstName + " " + item._students.LastName,
                        FeeTypeId = item._StudentDiscounts.FeeTypeId,
                        FeeType = item._FeeTypes.Name,
                        DiscountAmout = item._StudentDiscounts.DiscountAmout
                    };
                    list.Add(temp);
                };

                //[NOTE: map institutions]
                var currentInstitution = new PrintGetStudentDiscountsList_Institutions()
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
                model = new PrintGetStudentDiscountsList()
                {
                    _StudentDiscounts = list,
                    Institution = currentInstitution
                };
            }
            catch (Exception)
            {

            }
            return model;
        }
        #endregion "Report Method"
        
    }
}
