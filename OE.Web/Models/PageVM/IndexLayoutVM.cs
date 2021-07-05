using OE.Data;

using System.Collections.Generic;

namespace OE.Web.Models
{
    public class IndexLayoutVM
    {
        public string InstitutionName { get; set; }
        public string Logo { get; set; }
        public string Favicon { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
        public List<InstitutionLinksListVM> _insLinksVM { get; set; }        
        //public GetLicenceDetails LicenceDetails { get; set; }       
        //public List<InsPages> _insPagesVM { get; set; }
    }
}

