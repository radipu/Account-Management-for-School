using System;

namespace OE.Data
{
    public class UserAuthentications : BaseEntity
    {
        public Int64 ActorId { get; set; }
        public Int64 UserId { get; set; }
        public bool? IsActive { get; set; }
    }
}
