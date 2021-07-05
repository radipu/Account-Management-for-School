
using System.Collections.Generic;

namespace OE.Web.Models
{
    public class IndexInsPageDetailsVM
    {
        public List<InsPageDetailsListVM> InsPageDetailsList { get; set; }       
       
       
        //Extra field from InsPages
        public long InsPageId { get; set; }
        public string InsPageTitle { get; set; }
        public string IP300X200 { get; set; }
        public string IP600X400 { get; set; }
    }
}
