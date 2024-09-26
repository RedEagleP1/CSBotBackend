using System.ComponentModel.DataAnnotations;
using P1_Core.Entities.Interfaces;

namespace P1_Core.Entities
{

    public class Condition : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public virtual ICollection<Rule>? Rules { get; set; }

    }
}