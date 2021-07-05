
using Microsoft.AspNetCore.Mvc;
using OE.Service;
using OE.Service.ServiceModels.StudentPromotionsServ;
using OE.Web.Areas.Institution.Models;
using OE.Web.Areas.Institution.Models.StudentPromotionsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OE.Web.Areas.Institution.Controllers
{
    [Area("Institution")]
    public class StudentPromotionsController : Controller
    {
        #region "Variables"
        private readonly IStudentPromotionsServ _StudentPromotionsServ;
        private readonly IClassesServ _classesServ;
        #endregion "Variables"

        #region "Constructor"
        public StudentPromotionsController(
            IClassesServ classesServ,
            IStudentPromotionsServ StudentPromotionsServ
        )
        {
            _StudentPromotionsServ = StudentPromotionsServ;
            _classesServ = classesServ;
        }
        #endregion "Constructor"

        #region "Get methods"
        public async Task<IActionResult> StudentPromotionsList(int pg = 1)
        {
            try
            {
                var StudentPromotionsList = Task.Run(() => _StudentPromotionsServ.getStudentPromotionsList());
                var result = await StudentPromotionsList;
                ViewBag.ddlClass = _classesServ.dropdown_Class();
                var list = new List<IndexStudentPromotionsVM_StudentPromotions>();
                foreach (var item in result._StudentPromotions.ToList())
                {
                    var temp = new IndexStudentPromotionsVM_StudentPromotions()
                    {
                        Id = item.Id,
                        ClassId = item.ClassId,
                        ClassName = item.ClassName,
                        StudentId = item.StudentId,
                        RegistrationNo = item.RegistrationNo,
                        RollNo = item.RollNo,
                        ClassYear = item.ClassYear,
                        IsActive = item.IsActive,
                        AddedBy = item.AddedBy,
                        AddedDate = item.AddedDate,
                        ModifiedBy = item.ModifiedBy,
                        ModifiedDate = item.ModifiedDate,
                        DataType = item.DataType
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
                var model = new IndexStudentPromotionsVM()
                {
                    _StudentPromotions = data
                };
                #endregion "Paging"
              

                return View("StudentPromotionsList", model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion "Get methods"
        
        #region "Post Method"
        [HttpPost]
        public async Task<IActionResult> InsertPromotion(IndexStudentPromotionsVM obj)
        {

            try
            {
                if(ModelState.IsValid)
                {
                    ViewBag.ddlClass = _classesServ.dropdown_Class();
                    if (obj.StudentPromotions != null)
                    {
                        var StudentPromotions = new InsertStudentPromotions_StudentPromotions()
                        {
                            StudentId = obj.StudentPromotions.StudentId,
                            ClassId = obj.StudentPromotions.ClassId,
                            RollNo = obj.StudentPromotions.RollNo,
                            Year = obj.StudentPromotions.Year,
                            IsActive = obj.StudentPromotions.IsActive,
                            AddedBy = 0,
                            AddedDate = DateTime.Now,
                            ModifiedBy = 0,
                            ModifiedDate = DateTime.Now,
                            DataType = null
                        };

                        var model = new InsertStudentPromotions()
                        {
                            StudentPromotions = StudentPromotions
                        };

                        await Task.Run(() => _StudentPromotionsServ.InsertStudentPromotions(model));

                    }
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return RedirectToAction("StudentPromotionsList");

        }

        [HttpPost]
        public async Task<IActionResult> UpdatePromotion(IndexStudentPromotionsVM obj)
        {

            try
            {
                if (obj.StudentPromotions != null)
                {
                    var StudentPromotions = new UpdateStudentPromotion_StudentPromotions()
                    {
                        Id = obj.StudentPromotions.Id,
                        StudentId = obj.StudentPromotions.StudentId,
                        ClassId = obj.StudentPromotions.ClassId,
                        RollNo = obj.StudentPromotions.RollNo,
                        Year = obj.StudentPromotions.Year,
                        IsActive = obj.StudentPromotions.IsActive,
                        AddedBy = 0,
                        AddedDate = DateTime.Now,
                        ModifiedBy = 0,
                        ModifiedDate = DateTime.Now,
                        DataType = null
                    };

                    var model = new UpdateStudentPromotion()
                    {
                        StudentPromotions = StudentPromotions
                    };

                    await Task.Run(() => _StudentPromotionsServ.UpdateStudentPromotion(model));
                }
            }
            catch (Exception)
            {

                return BadRequest();
            }
            return RedirectToAction("StudentPromotionsList");

        }

        [HttpPost]
        public async Task<IActionResult> DeletePromotion(long StudentPromotionsId)
        {
            try
            {

                var model = new DeleteStudentPromotion()
                {
                    StudentPromotionsId = StudentPromotionsId

                };
                await Task.Run(() => _StudentPromotionsServ.DeleteStudentPromotion(model));

            }
            catch (Exception)
            {

                return BadRequest();
            }
            return RedirectToAction("StudentPromotionsList");
        }
        #endregion "Post Method"
        
    }
}
