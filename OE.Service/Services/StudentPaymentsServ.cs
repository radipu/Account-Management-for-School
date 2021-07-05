using OE.Data;
using OE.Repo;
using OE.Service.ServiceModels.StudentPaymentsServ;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OE.Service
{
    public class StudentPaymentsServ : IStudentPaymentsServ
    {
        #region "Variables"
        private readonly IStudentPaymentsRepo<StudentPayments> _StudentPaymentsRepo;
        private readonly IStudentPromotionsRepo<StudentPromotions> _StudentPromotions;
        private readonly IFeeStructuresRepo<FeeStructures> _FeeStructures;
        private readonly IStudentDiscountsRepo<StudentDiscounts> _StudentDiscounts;
        private readonly IFeeTermDescriptionsRepo<FeeTermDescriptions> _FeeTermDescriptions;
        private readonly IFeeTypesRepo<FeeTypes> _FeeTypesRepo;
        private readonly IStudentsRepo<Students> _studentsRepo;
        private readonly IClassesRepo<Classes> _classesRepo;
        private readonly IGendersRepo<Genders> _GendersRepo;
        private readonly IInstitutionsRepo<Institutions> _InstitutionsRepo;
        #endregion "Variables"

        #region "Constructor"
        public StudentPaymentsServ(
            IStudentPaymentsRepo<StudentPayments> StudentPaymentsRepo,
            IStudentPromotionsRepo<StudentPromotions> StudentPromotions,
            IFeeTermDescriptionsRepo<FeeTermDescriptions> FeeTermDescriptions,
            IFeeStructuresRepo<FeeStructures> FeeStructures,
            IStudentDiscountsRepo<StudentDiscounts> StudentDiscounts,
            IInstitutionsRepo<Institutions> InstitutionsRepo,
            IFeeTypesRepo<FeeTypes> FeeTypesRepo,
            IClassesRepo<Classes> classesRepo,
            IGendersRepo<Genders> GendersRepo,
             IStudentsRepo<Students> studentsRepo)
        {
            _StudentPaymentsRepo = StudentPaymentsRepo;
            _StudentPromotions = StudentPromotions;
            _FeeStructures = FeeStructures;
            _FeeTermDescriptions = FeeTermDescriptions;
            _StudentDiscounts = StudentDiscounts;
            _FeeTypesRepo = FeeTypesRepo;
            _studentsRepo = studentsRepo;
            _InstitutionsRepo = InstitutionsRepo;
            _classesRepo = classesRepo;
            _GendersRepo = GendersRepo;
        }
        #endregion "Constructor"

        #region "Get Methods"  
        public getStudentPaymentsList getStudentPaymentsList()
        {
            var model = new getStudentPaymentsList();
            try
            {
                var StudentPaymentsList = _StudentPaymentsRepo.GetAll().ToList();
                var FeeTypesList = _FeeTypesRepo.GetAll().ToList();
                var studentsList = _studentsRepo.GetAll().ToList();
                var query = (from _StudentPayments in StudentPaymentsList
                             join _FeeTypes in FeeTypesList on _StudentPayments?.FeeTypeId equals _FeeTypes?.Id
                             join _Students in studentsList on _StudentPayments?.StudentId equals _Students?.Id
                             select new { _StudentPayments, _Students, _FeeTypes });
                var list = new List<getStudentPaymentsList_StudentPayments>();
                foreach (var item in query)
                {
                    var temp = new getStudentPaymentsList_StudentPayments()
                    {
                        Id = item._StudentPayments.Id,
                        ClassId = item._StudentPayments.ClassId,
                        FeeYearDate = item._StudentPayments.FeeYearDate,
                        StudentId = item._StudentPayments.StudentId,
                        StudentName = item._Students.FirstName + " " + item._Students.LastName,
                        FeeTypeId = item._StudentPayments.FeeTypeId,
                        FeeType = item._FeeTypes.Name,
                        Fine = item._StudentPayments.Fine,
                        PaidAmount = item._StudentPayments.PaidAmount,
                        PaymentDate = item._StudentPayments.PaymentDate,
                        Remarks = item._StudentPayments.Remarks
                    };
                    list.Add(temp);
                };
                model = new getStudentPaymentsList()
                {
                    _StudentPayments = list
                };
            }
            catch (Exception)
            {

            }
            return model;
        }
        public SearchStudentList SearchStudentList(SearchStudentList obj)
        {
            var model = (dynamic)null;
            try
            {
                var studentsList = _studentsRepo.GetAll().ToList();
                var ClassList = _classesRepo.GetAll().ToList();
                var GendersList = _GendersRepo.GetAll().ToList();
                var query = (from _students in studentsList
                             where _students.RegistrationNo == obj.RegistrationId
                             join _Classes in ClassList on _students?.ClassId equals _Classes?.Id
                             join _Genders in GendersList on _students?.GenderId equals _Genders?.Id
                             orderby _students.ClassId, _students.FirstName ascending
                             select new { _students, _Classes, _Genders }).SingleOrDefault();
                if (query != null)
                {
                    var temp = new SearchStudentList_Students()
                    {
                        Id = query._students.Id,
                        RegistrationNo = query._students.RegistrationNo,
                        ClassId = query._Classes.Id,
                        ClassName = query._Classes.Name,
                        GenderId = query._Genders.Id,
                        GenderName = query._Genders.Name,
                        FirstName = query._students.FirstName,
                        LastName = query._students.LastName,
                        StudentName = query._students.FirstName + "  " + query._students.LastName,
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
                    model = new SearchStudentList()
                    {
                        Students = temp
                    };
                }
                else
                {
                    model = new SearchStudentList()
                    {
                        Students = null
                    };
                }
               
            }
            catch (Exception)
            {

            }
            return model;
        }
        public SearchPaymentDetailById SearchPaymentDetailById(SearchPaymentDetailById obj)
        {
            var model = new SearchPaymentDetailById();
            try
            {
                var StudentPaymentsList = _StudentPaymentsRepo.GetAll().ToList();
                var studentsList = _studentsRepo.GetAll().ToList();
                var FeeTypesList = _FeeTypesRepo.GetAll().ToList();
                var classes = _classesRepo.GetAll().ToList();
                var feeStructure = _FeeStructures.GetAll().ToList();
                var studentPromotion = _StudentPromotions.GetAll().ToList();
                var studentDiscount = _StudentDiscounts.GetAll().ToList();
                var feeTermDescription = _FeeTermDescriptions.GetAll().ToList();
                var StudentDetails = (from c in studentsList
                                      where c.Id == obj.StudentId
                                      select c).SingleOrDefault();
                //[Note: Step 1- Get Student from promotion table for all class ]
                var query = (from sp in studentPromotion
                             where sp.StudentId == obj.StudentId
                             join s in studentsList on sp.StudentId equals s.Id
                             join c in classes on sp.ClassId equals c.Id
                             join f in FeeTypesList on c?.Id equals f?.ClassId into allFeeTypes
                             from feeTypes in allFeeTypes.DefaultIfEmpty()
                             join fs in feeStructure on feeTypes?.Id equals fs?.FeeTypeId into allfeeStructure
                             from feeStucture in allfeeStructure.DefaultIfEmpty()
                             select new
                             {
                                 Id = sp.Id,
                                 StudentId = obj.StudentId,
                                 StuClassId = sp.ClassId,
                                 StuFeeYear = sp?.ClassYear,
                                 StuFeeType = feeStucture.FeeTypeId,
                                 StuClassName = c.Name,
                                 FeeTypeName = feeTypes?.Name,
                                 FeeAmount = feeStucture?.Amount,
                                 StuPaymentDate = (dynamic)null,
                                 StuPaidAmount = 0,
                                 StuFine = 0,
                                 StuRemarks = "",
                                 StuDiscount = 0
                             }).ToList();

                //[NOTE:Step 2- get discount of the student if exist]
                studentDiscount = studentDiscount.Where(s => s.StudentId == obj.StudentId).ToList();
                if (query != null)
                {
                    var list = new List<SearchPaymentDetailById_StudentPayments>();
                    decimal? totalPaid = 0;
                    decimal? totalDiscount = 0;
                    decimal? totalFeeAmount = 0;
                    decimal? totalFine = 0;
                    foreach (var item in query)
                    {
                        var getFeeTerm = from ft in feeTermDescription
                                         join fs in feeStructure on ft.FeeStructureId equals fs.Id
                                         //[NOTE: temporary solution bellow. Need to investigate comment line]
                                         //where fs.ClassId == item.StuClassId && fs.FeeTypeId == item.StuFeeType && fs.StartingYear <= item.StuFeeYear && fs.EndingYear >= item.StuFeeYear
                                         where fs.ClassId == item.StuClassId && fs.FeeTypeId == item.StuFeeType 

                                         select new { ft, fs };
                        //[NOTE:Step 3- find feetype discount if exist]
                        decimal? currentTypeDiscountAmount = 0;
                        if (studentDiscount.Count() > 0)
                        {
                            currentTypeDiscountAmount = (from s in studentDiscount
                                                         where s.FeeTypeId == item.StuFeeType
                                                         select s.DiscountAmout).FirstOrDefault();
                        }
                        foreach (var item2 in getFeeTerm)
                        {
                            //[NOTE: get existing payment of the student if exist]                            
                            var GetPaymentListOfTheStudent = (from p in StudentPaymentsList
                                                              where p.StudentId == obj.StudentId
                                                              && p.ClassId == item2.fs.ClassId
                                                              && p.FeeTermDescriptionId == item2.ft.Id
                                                              && p.FeeTypeId == item2.fs.FeeTypeId
                                                              //&& (p.FeeYearDate.Value.Year >= item2.fs.StartingYear.Value.Year && p.FeeYearDate.Value.Year <= item2.fs.EndingYear.Value.Year)
                                                              select p).FirstOrDefault();
                            var temp = new SearchPaymentDetailById_StudentPayments()
                            {
                                Id = item.Id,
                                ClassId = item.StuClassId,
                                ClassName = item.StuClassName,
                                FeeYearDate = item.StuFeeYear,
                                PaidAmount = GetPaymentListOfTheStudent != null ? GetPaymentListOfTheStudent.PaidAmount : 0,
                                FeeType = item.FeeTypeName,
                                FeeTypeId = item.StuFeeType,
                                TermNo = item2.ft.TermNo,
                                TermName = item2.ft.TermName,
                                FeeAmount = item.FeeAmount != null ? item.FeeAmount : 0,
                                PaymentDate = GetPaymentListOfTheStudent != null ? GetPaymentListOfTheStudent.PaymentDate : null,
                                Remarks = item.StuRemarks,
                                Fine = GetPaymentListOfTheStudent != null ? GetPaymentListOfTheStudent.Fine : 0,
                                Discount = currentTypeDiscountAmount
                            };
                            list.Add(temp);
                            //[NOTE: total fine ]
                            totalFine += GetPaymentListOfTheStudent != null ? (GetPaymentListOfTheStudent.Fine != null ? GetPaymentListOfTheStudent.Fine : 0) : 0;
                            totalPaid += GetPaymentListOfTheStudent != null ? (GetPaymentListOfTheStudent.PaidAmount != null ? GetPaymentListOfTheStudent.PaidAmount : 0) : 0;
                        }
                        totalDiscount += currentTypeDiscountAmount;
                        totalFeeAmount += item.FeeAmount != null ? item.FeeAmount : 0;
                    };
                    model = new SearchPaymentDetailById()
                    {
                        TotalFine = totalFine,
                        TotalPaid = totalPaid,
                        TotalHavetoPay = totalFeeAmount - totalDiscount,
                        ClassId = StudentDetails.ClassId,
                        _StudentPayments = list,
                        StudentSearchName = StudentDetails.FirstName + " " + StudentDetails.LastName
                    };
                }
                else
                {
                    model = new SearchPaymentDetailById()
                    {
                        TotalFine = null,
                        TotalPaid = null,
                        TotalHavetoPay = null,
                        ClassId = 0,
                        _StudentPayments = null,
                        StudentSearchName = null
                    };
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return model;
        }

        public SearchPaymentDetailById SearchPaymentDetailById2(SearchPaymentDetailById obj)
        {
            var model = new SearchPaymentDetailById();
            try
            {
                var StudentPaymentsList = _StudentPaymentsRepo.GetAll().ToList();
                var studentsList = _studentsRepo.GetAll().Where(s=>s.RegistrationNo==obj.RegistrationId);              

                var FeeTypesList = _FeeTypesRepo.GetAll().ToList();
                var classes = _classesRepo.GetAll().ToList();
                var feeStructure = _FeeStructures.GetAll().ToList();
                var studentPromotion = _StudentPromotions.GetAll().ToList();
                var studentDiscount = _StudentDiscounts.GetAll().ToList();
                var feeTermDescription = _FeeTermDescriptions.GetAll().ToList();
                var StudentDetails = (from c in studentsList                                      
                                      select c).SingleOrDefault();

               var StudentId = (from c in studentsList
                                select c.Id).SingleOrDefault();

                //[Note: Step 1- Get Student from promotion table for all class ]
                var query = (from sp in studentPromotion
                            
                             join s in studentsList on sp.StudentId equals s.Id
                             join c in classes on sp.ClassId equals c.Id
                             join f in FeeTypesList on c?.Id equals f?.ClassId into allFeeTypes
                             from feeTypes in allFeeTypes.DefaultIfEmpty()
                             join fs in feeStructure on feeTypes?.Id equals fs?.FeeTypeId into allfeeStructure
                             from feeStucture in allfeeStructure.DefaultIfEmpty()
                             select new
                             {
                                 Id = sp.Id,
                                 StudentId = StudentId,
                                 StuClassId = sp.ClassId,
                                 StuFeeYear = sp?.ClassYear,
                                 StuFeeType = feeStucture.FeeTypeId,
                                 StuClassName = c.Name,
                                 FeeTypeName = feeTypes?.Name,
                                 FeeAmount = feeStucture?.Amount,
                                 StuPaymentDate = (dynamic)null,
                                 StuPaidAmount = 0,
                                 StuFine = 0,
                                 StuRemarks = "",
                                 StuDiscount = 0
                             }).ToList();

                //[NOTE:Step 2- get discount of the student if exist]
                studentDiscount = studentDiscount.Where(s => s.StudentId == obj.StudentId).ToList();
                if (query != null)
                {
                    var list = new List<SearchPaymentDetailById_StudentPayments>();
                    decimal? totalPaid = 0;
                    decimal? totalDiscount = 0;
                    decimal? totalFeeAmount = 0;
                    decimal? totalFine = 0;
                    foreach (var item in query)
                    {
                        var getFeeTerm = from ft in feeTermDescription
                                         join fs in feeStructure on ft.FeeStructureId equals fs.Id
                                         //[NOTE: temporary solution bellow. Need to investigate comment line]
                                         //where fs.ClassId == item.StuClassId && fs.FeeTypeId == item.StuFeeType && fs.StartingYear <= item.StuFeeYear && fs.EndingYear >= item.StuFeeYear
                                         where fs.ClassId == item.StuClassId && fs.FeeTypeId == item.StuFeeType

                                         select new { ft, fs };
                        //[NOTE:Step 3- find feetype discount if exist]
                        decimal? currentTypeDiscountAmount = 0;
                        if (studentDiscount.Count() > 0)
                        {
                            currentTypeDiscountAmount = (from s in studentDiscount
                                                         where s.FeeTypeId == item.StuFeeType
                                                         select s.DiscountAmout).FirstOrDefault();
                        }
                        foreach (var item2 in getFeeTerm)
                        {
                            //[NOTE: get existing payment of the student if exist]                            
                            var GetPaymentListOfTheStudent = (from p in StudentPaymentsList
                                                              where p.StudentId == StudentId
                                                              && p.ClassId == item2.fs.ClassId
                                                              && p.FeeTermDescriptionId == item2.ft.Id
                                                              && p.FeeTypeId == item2.fs.FeeTypeId
                                                              //&& (p.FeeYearDate.Value.Year >= item2.fs.StartingYear.Value.Year && p.FeeYearDate.Value.Year <= item2.fs.EndingYear.Value.Year)
                                                              select p).FirstOrDefault();
                            var temp = new SearchPaymentDetailById_StudentPayments()
                            {
                                Id = item.Id,
                                ClassId = item.StuClassId,
                                ClassName = item.StuClassName,
                                FeeYearDate = item.StuFeeYear,
                                PaidAmount = GetPaymentListOfTheStudent != null ? GetPaymentListOfTheStudent.PaidAmount : 0,
                                FeeType = item.FeeTypeName,
                                FeeTypeId = item.StuFeeType,
                                TermNo = item2.ft.TermNo,
                                TermName = item2.ft.TermName,
                                FeeAmount = item.FeeAmount != null ? item.FeeAmount : 0,
                                PaymentDate = GetPaymentListOfTheStudent != null ? GetPaymentListOfTheStudent.PaymentDate : null,
                                Remarks = item.StuRemarks,
                                Fine = GetPaymentListOfTheStudent != null ? GetPaymentListOfTheStudent.Fine : 0,
                                Discount = currentTypeDiscountAmount
                            };
                            list.Add(temp);
                            //[NOTE: total fine ]
                            totalFine += GetPaymentListOfTheStudent != null ? (GetPaymentListOfTheStudent.Fine != null ? GetPaymentListOfTheStudent.Fine : 0) : 0;
                            totalPaid += GetPaymentListOfTheStudent != null ? (GetPaymentListOfTheStudent.PaidAmount != null ? GetPaymentListOfTheStudent.PaidAmount : 0) : 0;
                        }
                        totalDiscount += currentTypeDiscountAmount;
                        totalFeeAmount += item.FeeAmount != null ? item.FeeAmount : 0;
                    };
                    model = new SearchPaymentDetailById()
                    {
                        TotalFine = totalFine,
                        TotalPaid = totalPaid,
                        TotalHavetoPay = totalFeeAmount - totalDiscount,
                        ClassId = StudentDetails.ClassId,
                        _StudentPayments = list,
                        StudentSearchName = StudentDetails.FirstName + " " + StudentDetails.LastName
                    };
                }
                else
                {
                    model = new SearchPaymentDetailById()
                    {
                        TotalFine = null,
                        TotalPaid = null,
                        TotalHavetoPay = null,
                        ClassId = 0,
                        _StudentPayments = null,
                        StudentSearchName = null
                    };
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return model;
        }
        public ClassByYear ClassByYear(long year, long studentId)
        {
            var queryAll = _classesRepo.GetAll().ToList();
            var StudentPromotion = _StudentPromotions.GetAll().ToList();
            var getClasses = (from sp in StudentPromotion
                              join c in queryAll on sp.ClassId equals c.Id
                              where sp.ClassYear.Value.Year == year && sp.StudentId == studentId
                              select new { sp, c }).SingleOrDefault();
            var queryResult = new ClassByYear()
            {
                Id = getClasses.c.Id,
                Name = getClasses.c.Name
            };
            return queryResult;
        }
        #endregion "Get Methods" 
        
        #region "Insert update and delete Function"  
        public string InsertStudentPayment(InsertStudentPayment obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    //[Note: insert 'states' table]                   
                    if (obj._StudentPayments != null)
                    {
                        var getPayment = _StudentPaymentsRepo.GetAll().ToList();
                        foreach (var item in obj._StudentPayments)
                        {
                            DateTime feeYear = DateTime.ParseExact(item.FeeYear, "yyyy", null);
                            var isExist = (from sp in getPayment
                                           where sp.ClassId == item.ClassId && sp.FeeTypeId == item.FeeTypeId && sp.StudentId == item.StudentId && sp.FeeTermDescriptionId == item.FeeTermDescriptionId && sp.FeeYearDate.Value.Year == feeYear.Year
                                           select sp).SingleOrDefault();
                            if (isExist != null)
                            {
                          
                                isExist.ClassId = item.ClassId;
                                isExist.FeeYearDate = feeYear;
                                isExist.PaymentDate = item.PaymentDate;
                                isExist.StudentId = item.StudentId;
                                isExist.FeeTypeId = item.FeeTypeId;
                                isExist.FeeTermDescriptionId = item.FeeTermDescriptionId;
                                isExist.Fine = item.Fine;
                                isExist.PaidAmount = item.PaidAmount;
                                isExist.Remarks = item.Remarks!=null ? item.Remarks:"";
                                _StudentPaymentsRepo.Update(isExist);
                            }
                            else
                            {
                                var StudentPayments = new InsertStudentPayment_StudentPayments()
                                {
                                    ClassId = item.ClassId,
                                    FeeTypeId = item.FeeTypeId,
                                    FeeTermDescriptionId = item.FeeTermDescriptionId,
                                    FeeYearDate = feeYear,
                                    PaymentDate = item.PaymentDate,
                                    StudentId = item.StudentId,
                                    Fine = item.Fine,
                                    PaidAmount = item.PaidAmount,
                                    Remarks = item.Remarks
                                };
                                _StudentPaymentsRepo.Insert(StudentPayments);
                            }
                        }
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
        public string UpdateStudentPayment(UpdateStudentPayment obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    if (obj.StudentPayments != null)
                    {
                        DateTime feeYear = DateTime.ParseExact(obj.StudentPayments.FeeYear, "yyyy", null);
                        var currentItem = _StudentPaymentsRepo.Get(obj.StudentPayments.Id);
                        currentItem.PaymentDate = obj.StudentPayments.PaymentDate;
                        currentItem.ClassId = obj.StudentPayments.ClassId;
                        currentItem.FeeYearDate = feeYear;
                        currentItem.FeeTypeId = obj.StudentPayments.FeeTypeId;
                        currentItem.Fine = obj.StudentPayments.Fine;
                        currentItem.PaidAmount = obj.StudentPayments.PaidAmount;
                        currentItem.Remarks = obj.StudentPayments.Remarks;
                        _StudentPaymentsRepo.Update(currentItem);
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
        public string DeleteStudentPayment(DeleteStudentPayment obj)
        {
            var returnModel = (dynamic)null;
            var StudentPayment = _StudentPaymentsRepo.Get(obj.StudentPaymentId);
            if (StudentPayment != null)
            {
                _StudentPaymentsRepo.Delete(StudentPayment);
                returnModel = "Delete Successful.";
            }
            return returnModel;
        }
        #endregion "Insert update and delete Function"  

        #region "Report Method"
        public PrintGetStudentPaymentsList PrintGetStudentPaymentsList()
        {
            var model = new PrintGetStudentPaymentsList();
            try
            {
                var institution = _InstitutionsRepo.GetAll().FirstOrDefault();
                var StudentPaymentsList = _StudentPaymentsRepo.GetAll().ToList();
                var studentsList = _studentsRepo.GetAll().ToList();
                var FeeTypesList = _FeeTypesRepo.GetAll().ToList();
                var query = (from _StudentPayments in StudentPaymentsList
                             join _Students in studentsList on _StudentPayments?.StudentId equals _Students?.Id
                             join _FeeTypes in FeeTypesList on _StudentPayments?.FeeTypeId equals _FeeTypes?.Id
                             select new { _StudentPayments, /*_StudentDiscounts,*/ _Students, _FeeTypes });
                var list = new List<PrintGetStudentPaymentsList_StudentPayments>();
                foreach (var item in query)
                {
                    var temp = new PrintGetStudentPaymentsList_StudentPayments()
                    {
                        Id = item._StudentPayments.Id,
                        ClassId = item._StudentPayments.ClassId,
                        FeeYearDate = item._StudentPayments.FeeYearDate,
                        StudentId = item._StudentPayments.StudentId,
                        StudentName = item._Students.FirstName + " " + item._Students.LastName,
                        FeeTypeId = item._StudentPayments.FeeTypeId,
                        FeeType = item._FeeTypes.Name,
                        Fine = item._StudentPayments.Fine,
                        PaidAmount = item._StudentPayments.PaidAmount,
                        PaymentDate = item._StudentPayments.PaymentDate,
                        Remarks = item._StudentPayments.Remarks
                    };
                    list.Add(temp);
                };

                //[NOTE: map institutions]
                var currentInstitution = new PrintGetStudentPaymentsList_Institutions()
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
                model = new PrintGetStudentPaymentsList()
                {
                    _StudentPayments = list,
                    Institution = currentInstitution
                };
            }
            catch (Exception)
            {

            }
            return model;
        }
        #endregion "Report Method"
        

        #region "Dropdown Methods"
        public IEnumerable<dropdown_Year> dropdown_Year(long studentId)
        {
            var queryAll = _StudentPromotions.GetAll().ToList();
            var getYear = from p in queryAll
                          where p.StudentId == studentId
                          select p;
            var queryResult = new List<dropdown_Year>();
            foreach (var item in getYear)
            {
                var d = new dropdown_Year()
                {
                    Id = item.ClassYear.Value.Year,
                    Year = item.ClassYear.Value.Year
                };
                queryResult.Add(d);
            }
            return queryResult;
        }
        #endregion "Dropdown Methods"        
    }
}
