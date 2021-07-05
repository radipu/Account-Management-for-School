
using System;
using System.Collections.Generic;
using System.Text;

namespace OE.Data
{
    public class Institutions : BaseEntity
    {
        public string Name { get; set; }
        public string LogoPath { get; set; }
        public string FaviconPath { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Address { get; set; }
        public bool? IsActive { get; set; }
    }
}