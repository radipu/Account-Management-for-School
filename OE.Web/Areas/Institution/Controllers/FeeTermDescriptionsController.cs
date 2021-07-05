
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OE.Service;
using OE.Service.ServiceModels.FeeTermDescriptionsServ;
using OE.Web.Areas.Institution.Models;
using OE.Web.Areas.Institution.Models.FeeTermDescriptionsVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OE.Web.Areas.Institution.Controllers
{
    [Area("Institution")]
    public class FeeTermDescriptionsController : Controller
    {
        #region "Variables"
        private readonly IFeeTermDescriptionsServ _FeeTermDescriptionsServ;
        private readonly IClassesServ _classesServ;
        private readonly IFeeStructuresServ _FeeStructuresServ;
        private readonly IFeeTypesServ _FeeTypesServ;
        #endregion "Variables"

        #region "Constructor"
        public FeeTermDescriptionsController(
            IFeeTermDescriptionsServ FeeTermDescriptionsServ, IFeeTypesServ FeeTypesServ, IFeeStructuresServ FeeStructuresServ, IClassesServ classesServ
        )
        {
            _FeeTermDescriptionsServ = FeeTermDescriptionsServ;
            _FeeStructuresServ = FeeStructuresServ;
            _FeeTypesServ = FeeTypesServ;
            _classesServ = classesServ;
        }
        #endregion "Constructor"

        #region "Get methods"
        public async Task<IActionResult> FeeTermDescriptionsList(int pg = 1)
        {
            try
            {
                var FeeTermDescriptionsList = Task.Run(() => _FeeTermDescriptionsServ.GetFeeTermDescriptionsList());
                var result = await FeeTermDescriptionsList;
                ViewBag.ddlClass = _classesServ.dropdown_Class();
                var list = new List<IndexFeeTermDescriptionsListVM_FeeTermDescriptions>();
                foreach (var item in result._FeeTermDescriptions.ToList())
                {
                    var temp = new IndexFeeTermDescriptionsListVM_FeeTermDescriptions()
                    {
                        Id = item.Id,
                        FeeStructureId = item.FeeStructureId,
                        ClassName = item.ClassName,
                        TermNo = item.TermNo,
                        FeeType = item.FeeType,
                        ClassId = item.ClassId,
                         FeeTypeId = item.FeeTypeId,
                        TermName = item.TermName
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
                var model = new IndexFeeTermDescriptionsListVM()
                {
                    _FeeTermDescriptions = data
                };
                #endregion "Paging"
                
                return View("FeeTermDescriptionsList", model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        #endregion "Get methods"
        
        #region "Post_Methods"
        [HttpPost]
        public async Task<IActionResult> InsertFeeTermDescriptions(IndexFeeTermDescriptionsListVM obj)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if (obj.FeeTermDescriptions != null)
                    {
                        var FeeTermDescriptions = new InsertFeeTermDescriptions_FeeTermDescriptions()
                        {
                            TermName = obj.FeeTermDescriptions.TermName,
                            TermNo = obj.FeeTermDescriptions.TermNo,
                            ClassId = obj.FeeTermDescriptions.ClassId,
                            FeeTypeId = obj.FeeTermDescriptions.FeeTypeId,
                        };
                        var model = new InsertFeeTermDescriptions()
                        {
                            FeeTermDescriptions = FeeTermDescriptions
                        };
                        await Task.Run(() => _FeeTermDescriptionsServ.InsertFeeTermDescriptions(model));
                    }
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("FeeTermDescriptionsList");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateFeeTermDescriptions(IndexFeeTermDescriptionsListVM obj)
        {
            try
            {
                if (obj.FeeTermDescriptions != null)
                {
                    var FeeTermDescriptions = new UpdateFeeTermDescriptions_FeeTermDescriptions()
                    {
                        Id = obj.FeeTermDescriptions.Id,
                        ClassId = obj.FeeTermDescriptions.ClassId,
                        FeeTypeId = obj.FeeTermDescriptions.FeeTypeId,
                        TermNo = obj.FeeTermDescriptions.TermNo,
                        TermName = obj.FeeTermDescriptions.TermName
                    };
                    var model = new UpdateFeeTermDescriptions()
                    {
                        FeeTermDescriptions = FeeTermDescriptions
                    };
                    await Task.Run(() => _FeeTermDescriptionsServ.UpdateFeeTermDescriptions(model));
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("FeeTermDescriptionsList");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteFeeTermDescriptions(long FeeTermDescriptionsId)
        {
            try
            {
                var getFeeTerm = new DeleteFeeTermDescriptions_FeeTermDescriptions()
                {
                    Id = FeeTermDescriptionsId
                };
                var model = new DeleteFeeTermDescriptions()
                {
                    FeeTermDescriptions = getFeeTerm
                };
                await Task.Run(() => _FeeTermDescriptionsServ.DeleteFeeTermDescriptions(model));
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("FeeTermDescriptionsList");
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
        public JsonResult DropDown_TermNo(long ddlFeeTypeId, long ClassId)
        {
            var result = (dynamic)null;
            if (ddlFeeTypeId != 0 && ClassId != 0)
            {
                var ddlTermNo = _FeeStructuresServ.dropdown_TermNo(ddlFeeTypeId, ClassId);
                result = Json(new SelectList(ddlTermNo, "Id", "Number"));
            }
            return result;
        }

        #endregion "Post Methods- dropdown"
       
    }
}
