
using OE.Data;
using OE.Repo;
using OE.Service.ServiceModels.StudentPromotionsServ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OE.Service
{
    public class StudentPromotionsServ:IStudentPromotionsServ
    {
        #region "Variables"
        public readonly IStudentPromotionsRepo<StudentPromotions> _StudentPromotionsRepo;
        private readonly IClassesRepo<Classes> _classesRepo;       
        private readonly IStudentsRepo<Students> _studentsRepo;   
        #endregion "Variables"

        #region "Constructor"
        public StudentPromotionsServ(
            IStudentPromotionsRepo<StudentPromotions> StudentPromotionsRepo,            
            IStudentsRepo<Students> studentsRepo,           
            IClassesRepo<Classes> classesRepo
            )
        {
            _StudentPromotionsRepo = StudentPromotionsRepo;
            _classesRepo = classesRepo;            
            _studentsRepo = studentsRepo;          

        }


        #endregion "Constructor"

        #region "Get Methods"  
        public getStudentPromotionsList getStudentPromotionsList()
        {
            var model = new getStudentPromotionsList();
            try
            {
                var StudentPromotionsList = _StudentPromotionsRepo.GetAll().ToList();              
                var studentsList = _studentsRepo.GetAll().ToList();               
                var classList = _classesRepo.GetAll().ToList();
                var query = (from _StudentPromotion in StudentPromotionsList
                             join _Class in classList on _StudentPromotion?.ClassId equals _Class?.Id                             
                             join _student in studentsList on _StudentPromotion?.StudentId equals _student?.Id
                             select new { _StudentPromotion, _Class , _student });                            
                var list = new List<getStudentPromotionsList_StudentPromotions>();
                foreach (var item in query)
                {
                    var temp = new getStudentPromotionsList_StudentPromotions()
                    {
                        Id = item._StudentPromotion.Id,
                        ClassId = item._StudentPromotion.ClassId,
                        ClassName = item._Class.Name,
                        StudentId = item._StudentPromotion.StudentId,
                        RegistrationNo = item._student.RegistrationNo,
                        RollNo = item._StudentPromotion.RollNo,
                        ClassYear = item._StudentPromotion.ClassYear,                        
                        IsActive = item._StudentPromotion.IsActive,
                        AddedBy = item._StudentPromotion.AddedBy,
                        AddedDate = item._StudentPromotion.AddedDate,
                        ModifiedBy = item._StudentPromotion.ModifiedBy,
                        ModifiedDate = item._StudentPromotion.ModifiedDate,
                        DataType = item._StudentPromotion.DataType
                    };
                    list.Add(temp);
                };
               

                model = new getStudentPromotionsList()
                {
                    _StudentPromotions = list,
                    
                };

            }
            catch (Exception)
            {

            }
            return model;
        }
        #endregion "Get method"            

        
        #region "Post method"
        public string InsertStudentPromotions(InsertStudentPromotions obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    var ClassYear = DateTime.ParseExact(obj.StudentPromotions.Year, "yyyy", null);
                    //[Note: insert 'states' table]
                    if (obj.StudentPromotions != null)
                    {
                        var StudentPromotions = new InsertStudentPromotions_StudentPromotions()
                        {

                            StudentId = obj.StudentPromotions.StudentId,
                            ClassId = obj.StudentPromotions.ClassId,
                            RollNo = obj.StudentPromotions.RollNo,
                            ClassYear = ClassYear,
                            IsActive = obj.StudentPromotions.IsActive,
                            AddedBy = 0,
                            AddedDate = DateTime.Now,
                            ModifiedBy = 0,
                            ModifiedDate = DateTime.Now,
                            DataType = null



                        };

                        _StudentPromotionsRepo.Insert(StudentPromotions);
                        returnResult = "Saved";

                    }
                }
            }
            catch (Exception ex)
            {
                returnResult = "ERROR102:PromotionClassesServ/InsertPromotionList - " + ex.Message;
            }

            return returnResult;

        }
        public string UpdateStudentPromotion(UpdateStudentPromotion obj)
        {
            string returnResult = (dynamic)null;
            try
            {
                if (obj != null)
                {
                    var ClassYear = DateTime.ParseExact(obj.StudentPromotions.Year, "yyyy", null);
                    if (obj.StudentPromotions != null)
                    {
                        var currentItem = _StudentPromotionsRepo.Get(obj.StudentPromotions.Id);
                        currentItem.Id = obj.StudentPromotions.Id;
                        currentItem.StudentId = obj.StudentPromotions.StudentId;
                        currentItem.ClassId = obj.StudentPromotions.ClassId;
                        currentItem.RollNo = obj.StudentPromotions.RollNo;
                        currentItem.ClassYear = ClassYear;
                        currentItem.IsActive = obj.StudentPromotions.IsActive;
                        currentItem.AddedBy = 0;
                        currentItem.AddedDate = DateTime.Now;
                        currentItem.ModifiedBy = 0;
                        currentItem.ModifiedDate = DateTime.Now;
                        currentItem.DataType = null;

                        _StudentPromotionsRepo.Update(currentItem);
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
        public DeleteStudentPromotion DeleteStudentPromotion(DeleteStudentPromotion obj)
        {
            var returnModel = new DeleteStudentPromotion();
            var StudentPromotions = _StudentPromotionsRepo.Get(obj.StudentPromotionsId);

            if (StudentPromotions != null)
            {
                _StudentPromotionsRepo.Delete(StudentPromotions);

            }
            return returnModel;
        }
        #endregion "Post Method"
       
    }
}

