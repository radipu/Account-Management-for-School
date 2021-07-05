using System;
using System.ComponentModel.DataAnnotations;

namespace OE.Data
{
    public class BaseEntity
    {
        [Key]
        public Int64 Id { get; set; }      
    }
}
