using System;

namespace OE.Web.Models
{
    public class InstitutionLinksListVM
    {
        public Int64 Id { get; set; }
        public string Name { get; set; }
        public string IP24X24 { get; set; }
        public string Url { get; set; }
        public Int64 InstitutionId { get; set; }

        public bool? IsActive { get; set; }

    }
}
