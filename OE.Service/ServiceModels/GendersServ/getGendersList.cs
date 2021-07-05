
using OE.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Service.ServiceModels.GendersServ
{
    public class getGendersList
    {
        public IEnumerable<getGendersListt_Genders> _Genders { get; set; }
    }
    public class getGendersListt_Genders : Genders
    {

    }
}
