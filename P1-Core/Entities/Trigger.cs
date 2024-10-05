using System.ComponentModel.DataAnnotations;

namespace P1_Core.Entities
{
    public class Trigger : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsEnabled { get; set; } = true;
        public virtual ICollection<Rule>? Rules { get; set; }
    }
}