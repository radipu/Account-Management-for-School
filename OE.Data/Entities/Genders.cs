
using System;

namespace OE.Data
{
    public class Genders : BaseEntity
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public Int64 AddedBy { get; set; }
        public DateTime? AddedDate { get; set; }
        public Int64 ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string DataType { get; set; }
    }
}
