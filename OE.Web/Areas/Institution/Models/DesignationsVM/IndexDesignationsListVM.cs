
using OE.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OE.Web.Areas.Institution.Models.DesignationsVM
{
    public class IndexDesignationsListVM
    {
        public IList<IndexDesignationsListVM_Designations> _Designations { get; set; }
        public IndexDesignationsListVM_Designations Designations { get; set; }
    }
    public class IndexDesignationsListVM_Designations : Designations
    {

    }
}
