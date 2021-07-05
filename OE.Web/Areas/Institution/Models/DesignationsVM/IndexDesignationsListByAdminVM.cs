
using OE.Data;
using System.Collections.Generic;

namespace OE.Web.Areas.Institution.Models.DesignationsVM
{
    public class IndexDesignationsListByAdminVM
    {
        public IList<IndexDesignationsListByAdminVM_Designations> _Designations { get; set; }
        public IndexDesignationsListByAdminVM_Designations Designations { get; set; }
    }
    public class IndexDesignationsListByAdminVM_Designations : Designations
    {

    }
}

