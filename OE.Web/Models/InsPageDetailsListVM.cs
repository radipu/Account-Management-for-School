
using System;

namespace OE.Web.Models
{
    public class InsPageDetailsListVM
    {
        public long Id { get; set; }
        public long InsPageId { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public long Sorting { get; set; }
    }
}
