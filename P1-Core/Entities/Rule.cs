using System.ComponentModel.DataAnnotations;

namespace P1_Core.Interfaces
{
    public class Rule : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        public bool IsEnabled { get; set; } = true;
        public virtual ICollection<Condition>? Conditions { get; set; }
        public virtual ICollection<Result>? Results { get; set; }
        public virtual ICollection<Trigger>? Triggers { get; set; }

    }
}