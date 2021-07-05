
using Microsoft.AspNetCore.Mvc;
using OE.Service;
using System.Threading.Tasks;

namespace OE.Web.Areas.Institution.Controllers
{
    [Area("Institution")]
    public class GendersController : Controller
    {
        #region "Variables"
        private readonly IGendersServ _GendersServ;
        #endregion "Variables"

        #region "Constructor"
        public GendersController(
            IGendersServ GendersServ
        )
        {
            _GendersServ = GendersServ;
        }
        #endregion "Constructor"

        #region "Get methods"
        //public async Task<IActionResult> GendersList()
        //{
        //    try
        //    {

        //        var GendersList = Task.Run(() => _GendersServ.getGendersList());
        //        var result = await GendersList;

        //        var list = new List<Vm_Genders>();
        //        foreach (var item in result._Genders.ToList())
        //        {
        //            var temp = new Vm_Genders()
        //            {
        //                Id = item.Id,
        //                Name = item.Name,
        //                IsActive = item.IsActive,
        //                AddedBy = item.AddedBy,
        //                AddedDate = item.AddedDate,
        //                ModifiedBy = item.ModifiedBy,
        //                ModifiedDate = item.ModifiedDate,
        //                DataType = item.DataType

        //            };
        //            list.Add(temp);
        //        };

        //        var model = new IndexGendersListVM()
        //        {
        //            _Genders = list
        //        };
        //        return View("GendersList", model);

        //    }
        //    catch (Exception)
        //    {
        //        return BadRequest();
        //    }

        //}
        #endregion "Get methods"
    }
}