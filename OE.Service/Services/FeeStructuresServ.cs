using OE.Data;
using OE.Repo;
using OE.Service.ServiceModels.FeeStructuresServ;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OE.Service
{
    public class FeeStructuresServ : IFeeStructuresServ
    {

        #region "Variables"
        private readonly IStudentsRepo<Students> _studentsRepo;
        private readonly IFeeStructuresRepo<FeeStructures> _FeeStructuresRepo;
        private readonly IFeeTypesRepo<FeeTypes> _FeeTypesRepo;
        private readonly IStudentDiscountsRepo<StudentDiscounts> _StudentDiscountsRepo;
        private readonly IStudentPaymentsRepo<StudentPayments> _StudentPaymentsRepo;
        private readonly IStudentPromotionsRepo<StudentPromotions> _StudentPromotionsRepo;
        private readonly IClassesRepo<Classes> _classesRepo;       
        private readonly IFeeTermDescriptionsRepo<FeeTermDescriptions> _FeeTermDescriptions;       
        private readonly IInstitutionsRepo<Institutions> _InstitutionsRepo;
        #endregion "Variables"

        #region "Constructor"   
        public FeeStructuresServ(
             IStudentsRepo<Students> studentsRepo,
             IFeeStructuresRepo<FeeStructures> FeeStructuresRepo,
            IInstitutionsRepo<Institutions> InstitutionsRepo,
            IStudentDiscountsRepo<StudentDiscounts> StudentDiscountsRepo,
            IStudentPaymentsRepo<StudentPayments> StudentPaymentsRepo,
             IStudentPromotionsRepo<StudentPromotions> StudentPromotionsRepo,           
            IFeeTermDescriptionsRepo<FeeTermDescriptions> FeeTermDescriptions,            
            IFeeTypesRepo<FeeTypes> FeeTypesRepo, IClassesRepo<Classes> classesRepo)
        {
            _studentsRepo = studentsRepo;
            _FeeStructuresRepo = FeeStructuresRepo;
            _StudentDiscountsRepo = StudentDiscountsRepo;
            _StudentPaymentsRepo = StudentPaymentsRepo;
            _StudentPromotionsRepo = StudentPromotionsRepo;            
            _FeeTermDescriptions = FeeTermDescriptions;           
            _FeeTypesRepo = FeeTypesRepo;
            _classesRepo = classesRepo;
            _InstitutionsRepo = InstitutionsRepo;
        }


        #endregion "Constructor"

        #region "Get Methods"  
        public getFeeStructuresList getFeeStructuresList()
        {
            var model = new getFeeStructuresList();
            try
            {
                var FeeStructuresList = _FeeStructuresRepo.GetAll().ToList();
                var FeeTypesList = _FeeTypesRepo.GetAll().ToList();
                var classList = _classesRepo.GetAll().ToList();
                var query = (from _FeeStructure in FeeStructuresList
                             join _FeeTypes in FeeTypesList on _FeeStructure?.FeeTypeId equals _FeeTypes?.Id
                             join _class in classList on _FeeStructure?.ClassId equals _class?.Id
                             select new { _FeeStructure, _FeeTypes, _class });
                var list = new List<getFeeStructuresList_FeeStructures>();
                foreach (var item in query)
                {
                    var temp = new getFeeStructuresList_FeeStructures()
                    {
                        Id = item._FeeStructure.Id,
                        ClassId = item._FeeStructure.ClassId,
                        Class = item._class.Name,
                        FeeTypeId = item._FeeStructure.FeeTypeId,
                        FeeType = item._FeeTypes.Name,
                        FeeTypeMood = item._FeeStructure.YearlyTermNo,
                        Amount = item._FeeStructure.Amount,
                        StartingYear = item._FeeStructure.StartingYear,
                        EndingYear = item._FeeStructure.EndingYear,
                        IsActive = item._FeeStructure.IsActive
                    };
                    list.Add(temp);
                };
                model = new getFeeStructuresList()
                {
                    _FeeStructures = list
                };
            }
            catch (Exception)
            {

            }
            return model;
        }
        public GetFeeStructuresByClass GetFeeStructuresByClass(long StudentId, long ClassId, long ClassYear)
        {           
            var model = new GetFeeStructuresByClass();
            try
            {
                var StudentPaymentsList = _StudentPaymentsRepo.GetAll().ToList();
                var studentsList = _studentsRepo.GetAll().ToList();
                var FeeTypesList = _FeeTypesRepo.GetAll().ToList();
                var classes = _classesRepo.GetAll().ToList();
                var feeStructure = _FeeStructuresRepo.GetAll().ToList();
                var studentPromotion = _StudentPromotionsRepo.GetAll().ToList();
                var studentDiscount = _StudentDiscountsRepo.GetAll().ToList();
                var feeTermDescription = _FeeTermDescriptions.GetAll().ToList();
                var StudentDetails = (from c in studentsList
                                      where c.Id == StudentId
                                      select c).SingleOrDefault();
                var getClass = (from cls in classes
                                where cls.Id == ClassId
                                select cls).SingleOrDefault();
                var getStuFeeYear = (from sp in studentPromotion
                                     where sp.StudentId == StudentId && sp.ClassId == ClassId
                                     select sp).SingleOrDefault();

                //[Note: Step 1- Get Student from promotion table for all class ]
                var query = (from sp in studentPromotion
                             where sp.StudentId == StudentId
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
                studentDiscount = studentDiscount.Where(s => s.StudentId == StudentId).ToList();
                if (query != null)
                {
                    //var list = new List<SearchPaymentDetailById_StudentPayments>();
                    var list = new List<GetFeeStructuresByClass_FeeStructures>();
                    //decimal? totalPaid = 0;
                    //decimal? totalDiscount = 0;
                    //decimal? totalFeeAmount = 0;
                    //decimal? totalFine = 0;

                    foreach (var item in query)
                    {
                        var getFeeTerm = from ft in feeTermDescription
                                         join fs in feeStructure on ft.FeeStructureId equals fs.Id
                                         //where fs.ClassId == ClassId && fs.FeeTypeId == item.StuFeeType && fs.StartingYear <= item.StuFeeYear && fs.EndingYear >= item.StuFeeYear
                                         where fs.ClassId == ClassId && fs.FeeTypeId == item.StuFeeType 
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
                                                              && (p.FeeYearDate.Value.Year == ClassYear)
                                                              select p).FirstOrDefault();                           
                            var temp = new GetFeeStructuresByClass_FeeStructures()
                            {
                                Id = item.Id,
                                ClassId = item.StuClassId,                                
                                FeeTypeId = item.StuFeeType,
                                FeeType = item.FeeTypeName,
                                FeeTypeMood = item2.ft.TermNo,
                                Amount = item.FeeAmount != null ? (dynamic) item.FeeAmount : 0,
                                Fine = GetPaymentListOfTheStudent != null ? GetPaymentListOfTheStudent.Fine : 0,
                                FeeTermDescriptionId = item2.ft.Id,
                                TermNo = item2.ft.TermNo,
                                TermName = item2.ft.TermName,
                                PaidAmount = GetPaymentListOfTheStudent != null ? GetPaymentListOfTheStudent.PaidAmount : 0,
                                Remarks = item.StuRemarks,
                                StartingYear = item2.fs.StartingYear,
                                EndingYear = item2.fs.EndingYear,
                                DiscountAmount = (dynamic) currentTypeDiscountAmount,
                                IsActive = item2.fs.IsActive
                            };
                            list.Add(temp);
                        }                       
                    };
                    model = new GetFeeStructuresByClass()
                    {
                        ClassName = getClass.Name,
                        FeeYear = getStuFeeYear.ClassYear.Value.Year,
                        _FeeStructures = list
                    };
                }               
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }            
            return model;
        }

        public SearchFeeStructures SearchFeeStructures(SearchFeeStructures obj)
        {
            var model = (dynamic)null;
            try
            {
                Int64 SearchClassId = Convert.ToInt64(obj.SearchClassId);
                var FeeStructuresList = _FeeStructuresRepo.GetAll().ToList();
                var FeeTypesList = _FeeTypesRepo.GetAll().ToList();
                var classList = _classesRepo.GetAll().ToList();

                var query = (from _FeeStructure in FeeStructuresList
                             join _FeeType in FeeTypesList on _FeeStructure?.FeeTypeId equals _FeeType?.Id
                             join _class in classList on _FeeStructure?.ClassId equals _class?.Id
                             where _FeeStructure.ClassId == SearchClassId
                             select new { _FeeStructure, _FeeType, _class }).ToList();
                var getAmount = (from p in FeeStructuresList
                                 where p.ClassId == SearchClassId
                                 select p.Amount);
                var allGetAmount = getAmount.Sum();
                var SearchClassName = (from c in classList
                                       where c.Id == SearchClassId
                                       select c).SingleOrDefault();
                var list = new List<SearchFeeStructures_FeeStructures>();
                foreach (var item in query)
                {
                    var temp = new SearchFeeStructures_FeeStructures()
                    {
                        Id = item._FeeStructure.Id,
                        ClassId = item._FeeStructure.ClassId,
                        Class = item._class.Name,
                        FeeTypeId = item._FeeStructure.FeeTypeId,
                        FeeType = item._FeeType.Name,
                        FeeTypeMood = item._FeeStructure.YearlyTermNo,
                        Amount = item._FeeStructure.Amount,
                        StartingYear = item._FeeStructure.StartingYear,
                        EndingYear = item._FeeStructure.EndingYear,
                        IsActive = item._FeeStructure.IsActive
                    };
                    list.Add(temp);
                };
                model = new SearchFeeStructures()
                {
                    _FeeStructures = list,
                    DateRangeAmount = allGetAmount,
                    SearchClassName = SearchClassName.Name
                };
            }
            catch (Exception)
            {

            }
            return model;
        }

        
        public dropdown_FeeStructures dropdown_FeeStructures(long feeTypeId)
        {
            var queryAll = _FeeStructuresRepo.GetAll().ToList();
            var getFeeStructures = (from p in queryAll
                                    where p.FeeTypeId == feeTypeId
                                    select p).SingleOrDefault();
            var queryResult = new dropdown_FeeStructures()
            {
                Id = getFeeStructures.Id,
                Amount = getFeeStructures.Amount
            };
            return queryResult;
        }
        
        #endregion "Get Methods" 

       
        #region "Insert update and delete Function"  
        public string InsertFeeStructure(InsertFeeStructure obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    //[Note: insert 'states' table]
                    if (obj.FeeStructures != null)
                    {
                        DateTime sDate = DateTime.ParseExact(obj.FeeStructures.StartYear, "yyyy", null);
                        DateTime eDate = DateTime.ParseExact(obj.FeeStructures.EndYear, "yyyy", null);
                        //var FeeStructures = new InsertFeeStructure_FeeStructures()
                        var FeeStructures = new FeeStructures()
                        {
                            ClassId = obj.FeeStructures.ClassId,
                            FeeTypeId = obj.FeeStructures.FeeTypeId,
                            Amount = obj.FeeStructures.Amount,
                            YearlyTermNo = obj.FeeStructures.YearlyTermNo,
                            StartingYear = sDate,
                            EndingYear = eDate,
                            IsActive = obj.FeeStructures.IsActive
                        };
                        _FeeStructuresRepo.Insert(FeeStructures);
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
        public string UpdateFeeStructure(UpdateFeeStructure obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    DateTime sDate = DateTime.ParseExact(obj.FeeStructures.StartYear, "yyyy", null);
                    DateTime eDate = DateTime.ParseExact(obj.FeeStructures.EndYear, "yyyy", null);
                    if (obj.FeeStructures != null)
                    {
                        var currentItem = _FeeStructuresRepo.Get(obj.FeeStructures.Id);
                        currentItem.Id = obj.FeeStructures.Id;
                        currentItem.ClassId = obj.FeeStructures.ClassId;
                        currentItem.FeeTypeId = obj.FeeStructures.FeeTypeId;
                        currentItem.Amount = obj.FeeStructures.Amount;
                        currentItem.YearlyTermNo = obj.FeeStructures.YearlyTermNo;
                        currentItem.StartingYear = sDate;
                        currentItem.EndingYear = eDate;
                        currentItem.IsActive = obj.FeeStructures.IsActive;
                        _FeeStructuresRepo.Update(currentItem);
                        returnResult = "Saved";
                    }
                }
            }
            catch (Exception ex)
            {
                returnResult = "ERROR102:FeeTypesServ/UpdateFeeTypes - " + ex.Message;
            }
            return returnResult;
        }
        public DeleteFeeStructure DeleteFeeStructure(DeleteFeeStructure obj)
        {
            var returnModel = new DeleteFeeStructure();
            var FeeStructures = _FeeStructuresRepo.Get(obj.FeeStructureId);
            if (FeeStructures != null)
            {
                _FeeStructuresRepo.Delete(FeeStructures);
                returnModel.Message = "Delete Successful.";
            }
            return returnModel;
        }
        #endregion "Insert update and delete Function"  

        #region "Dropdown Methods"
        public IEnumerable<dropdown_TermNo> dropdown_TermNo(long feeTypeId, long classId)
        {
            var queryAll = _FeeStructuresRepo.GetAll().ToList();
            var getFeeTypes = from p in queryAll
                              where p.ClassId == classId && p.FeeTypeId == feeTypeId && p.StartingYear.Value.Year <= DateTime.Now.Year && p.EndingYear.Value.Year >= DateTime.Now.Year
                              select p.YearlyTermNo;

            var queryResult = new List<dropdown_TermNo>();
            foreach (var item in getFeeTypes)
            {
                for (int j = 1; j <= item; j++)
                {
                    var d = new dropdown_TermNo()
                    {
                        Id = j,
                        Number = j
                    };
                    queryResult.Add(d);
                }
            }
            return queryResult;
        }
        #endregion "Dropdown Methods"

        #region "Report Method"
        public PrintGetFeeStructuresList PrintGetFeeStructuresList()
        {
            var model = new PrintGetFeeStructuresList();
            try
            {
                var institution = _InstitutionsRepo.GetAll().FirstOrDefault();
                var FeeStructuresList = _FeeStructuresRepo.GetAll().ToList();
                var FeeTypesList = _FeeTypesRepo.GetAll().ToList();
                var classList = _classesRepo.GetAll().ToList();
                var query = (from _FeeStructure in FeeStructuresList
                             join _FeeTypes in FeeTypesList on _FeeStructure?.FeeTypeId equals _FeeTypes?.Id
                             join _class in classList on _FeeStructure?.ClassId equals _class?.Id
                             select new { _FeeStructure, _FeeTypes, _class });


                var list = new List<PrintGetFeeStructuresList_FeeStructures>();
                foreach (var item in query)
                {
                    var temp = new PrintGetFeeStructuresList_FeeStructures()
                    {
                        Id = item._FeeStructure.Id,
                        ClassId = item._FeeStructure.ClassId,
                        Class = item._class.Name,
                        FeeTypeId = item._FeeStructure.FeeTypeId,
                        FeeType = item._FeeTypes.Name,
                        FeeTypeMood = item._FeeStructure.YearlyTermNo,
                        Amount = item._FeeStructure.Amount,
                        StartingYear = item._FeeStructure.StartingYear,
                        EndingYear = item._FeeStructure.EndingYear,
                        IsActive = item._FeeStructure.IsActive
                    };
                    list.Add(temp);
                };

                //[NOTE: map institutions]
                var currentInstitution = new PrintGetFeeStructuresList_Institutions()
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
                model = new PrintGetFeeStructuresList()
                {
                    _FeeStructures = list,
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
