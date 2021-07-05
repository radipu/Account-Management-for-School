using System.ComponentModel.DataAnnotations;

namespace OE.Data
{
    public class Classes : BaseEntity
    {
        [Required(ErrorMessage = "Please enter class name")]
        public string Name { get; set; }
    }
}
