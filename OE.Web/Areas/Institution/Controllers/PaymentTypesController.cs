
using Microsoft.AspNetCore.Mvc;
using OE.Service;
using OE.Service.ServiceModels.PaymentTypesServ;
using OE.Web.Areas.Institution.Models;
using OE.Web.Areas.Institution.Models.PaymentTypesVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OE.Web.Areas.Institution.Controllers
{
    [Area("Institution")]
    public class PaymentTypesController : Controller
    {
        #region "Variables"
        private readonly IPaymentTypesServ _PaymentTypesServ;
        #endregion "Variables"

        #region "Constructor"
        public PaymentTypesController(
            IPaymentTypesServ PaymentTypesServ
        )
        {
            _PaymentTypesServ = PaymentTypesServ;
        }
        #endregion "Constructor"

        #region "Get methods"
        public async Task<IActionResult> PaymentTypesList(int pg = 1)
        {
            try
            {
                var PaymentTypesList = Task.Run(() => _PaymentTypesServ.getPaymentTypesList());
                var result = await PaymentTypesList;
                var list = new List<Vm_PaymentTypes>();
                foreach (var item in result._PaymentTypes.ToList())
                {
                    var temp = new Vm_PaymentTypes()
                    {
                        Id = item.Id,
                        Name = item.Name
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
                var model = new IndexPaymentTypesListVM()
                {
                    _PaymentTypes = data
                };
                #endregion "Paging"
                
                return View("PaymentTypesList", model);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion "Get methods"

        #region "Post_Methods"
        [HttpPost]
        public async Task<IActionResult> InsertPaymentType(IndexPaymentTypesListVM obj)
        {
            try
            {
                if (obj.PaymentTypes != null)
                {
                    var PaymentTypes = new InsertPaymentTypet_PaymentTypes()
                    {
                        Name = obj.PaymentTypes.Name
                    };
                    var model = new InsertPaymentType()
                    {
                        PaymentTypes = PaymentTypes
                    };
                    await Task.Run(() => _PaymentTypesServ.InsertPaymentType(model));
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("PaymentTypesList");
        }
        [HttpPost]
        public async Task<IActionResult> UpdatePaymentType(IndexPaymentTypesListVM obj)
        {
            try
            {
                if (obj.PaymentTypes != null)
                {
                    var PaymentTypes = new Vm_PaymentTypes()
                    {
                        Id = obj.PaymentTypes.Id,
                        Name = obj.PaymentTypes.Name
                    };
                    var model = new UpdatePaymentType()
                    {
                        PaymentTypes = PaymentTypes
                    };
                    await Task.Run(() => _PaymentTypesServ.UpdatePaymentType(model));
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("PaymentTypesList");
        }
        [HttpPost]
        public async Task<IActionResult> DeletePaymentType(long PaymentTypeId)
        {
            try
            {
                var model = new DeletePaymentType()
                {
                    PaymentTypeId = PaymentTypeId
                };
                await Task.Run(() => _PaymentTypesServ.DeletePaymentType(model));
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return RedirectToAction("PaymentTypesList");
        }
        #endregion "Post_Methods"       
    }
}