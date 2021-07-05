
using OE.Data;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.GendersVM
{
    public class IndexGendersListVM
    {
        public IList<Vm_Genders> _Genders { get; set; }
        public Vm_Genders Genders { get; set; }
    }
    public class Vm_Genders : Genders
    {

    }
}